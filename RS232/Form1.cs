using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace RS232
{
    public enum Send : int
    {
        Reset, Phy, Dl
    }

    public partial class Form1 : Form
    {
        private SerialPort comPort = new SerialPort();
        private bool isConnected = false;
        public ConcurrentQueue<char> serialDataQueue = new ConcurrentQueue<char>();

        public Boolean statusReceive = true;

        public Form1()
        {
            InitializeComponent(); 

            comboBoxComPorts.Items.AddRange(SerialPort.GetPortNames());
            comboBoxComPorts.SelectedIndex = comboBoxComPorts.Items.Count - 1;
            
            comboBoxBaudrate.Items.Add(57600);
            comboBoxBaudrate.SelectedIndex = comboBoxBaudrate.Items.Count - 1;

            comboBoxDataBits.Items.Add(8);
            comboBoxDataBits.SelectedIndex = comboBoxDataBits.Items.Count - 1;

            comboBoxParity.Items.Add(Parity.None);
            comboBoxParity.SelectedIndex = comboBoxParity.Items.Count - 1;

            comboBoxStopBits.Items.Add(StopBits.One);
            comboBoxStopBits.SelectedIndex = comboBoxStopBits.Items.Count - 1;

            comboBoxHandshake.Items.Add(Handshake.None);
            comboBoxHandshake.SelectedIndex = comboBoxHandshake.Items.Count - 1;

            comPort.DataReceived += new SerialDataReceivedEventHandler(dataReceived);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            richTextBoxIncomingData.Clear();

            if (isConnected == false)
            {
                comPort.PortName = comboBoxComPorts.Text;
                comPort.BaudRate = Convert.ToInt32(comboBoxBaudrate.Text);
                comPort.DataBits = Convert.ToInt32(comboBoxDataBits.Text);
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), comboBoxParity.Text);
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBoxStopBits.Text);
                comPort.Handshake = (Handshake)Enum.Parse(typeof(Handshake), comboBoxHandshake.Text);
              
                comPort.ReadTimeout = 200;
                comPort.WriteTimeout = 200;

                comPort.RtsEnable = false;
                comPort.DtrEnable = true;

                comPort.Open();

                isConnected = true;
                labelConnected.BackColor = Color.Green;
                labelConnected.Text = "CONNECTED";
                buttonConnect.Text = "DISCONNECT";
            }
            else if (isConnected == true)
            {
                isConnected = false;
                labelConnected.Text = "DISCONNECTED";
                labelConnected.BackColor = Color.Red;
                buttonConnect.Text = "CONNECT";
                comPort.Close();
            }
        }

        private void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            int bytesAvailable = comPort.BytesToRead;
            char[] recBuf = new char[bytesAvailable];

            try
            {
                comPort.Read(recBuf, 0, bytesAvailable);

                for (int index = 0; index < bytesAvailable; index++)
                {
                    serialDataQueue.Enqueue(recBuf[index]);
                }

            }
            catch (TimeoutException) { }

            readSerialDataQueue();

        }

        private void readSerialDataQueue()
        {
            String hexVal = String.Empty;

            int stan = 0;
            Int32 begin = 0;
            Int32 length = 0;
            Int32 cmd = 0;
            Int32 data = 0;
            Int32 checksumOne = 0;
            Int32 checksumTwo = 0;

            List<Int32> dataList = new List<Int32>();
            List<Int32> checksumList = new List<Int32>();

            Int32 counter = 0;

            try
            {
                while (serialDataQueue.TryDequeue(out char ch))
                {
                    int val = Convert.ToInt32(ch);
                    hexVal = String.Format("{0:x2}", val);
                    
                    if (stan == 0 && hexVal == "3f") ;
                    {
                        statusReceive = true;
                        continue;
                    }

                    //poczatek ramki 02 lub 03
                    if (stan == 0 && (hexVal == "02" || hexVal == "03"))
                    {
                        dataList.Clear();
                        checksumList.Clear();
                        counter = 0;
                        begin = val;
                        this.richTextBoxIncomingData.Text += hexVal;

                        comPort.Write(new byte[] { 0x06 }, 0, 1);

                        stan = 1;
                        continue;
                    }

                    //length 0-255
                    if (stan == 1)
                    {
                        length = val;
                        this.richTextBoxIncomingData.Text += hexVal;
                        stan = 2;

                        dataList.Add(val);

                        continue;
                    }

                    //command code 0-FFh
                    if (stan == 2)
                    {
                        cmd = val;
                        this.richTextBoxIncomingData.Text += hexVal;
                        stan = 3;

                        dataList.Add(val);

                        continue;
                    }

                    //data 0-255 Bytes
                    if (stan == 3)
                    {
                        data = val;

                        if (length != 0 && length != counter)
                        {
                            this.richTextBoxIncomingData.Text += hexVal;
                            dataList.Add(val);

                            counter++;
                        }
                        else
                        {
                            stan = 4;
                        }

                        continue;
                    }

                    //checksum 2B (B - Byte)
                    if (stan == 4) 
                    {
                        checksumOne = val;
                        checksumList.Add(val);
                        stan = 5;

                        continue;
                    }
                    if (stan == 5)
                    {
                        checksumTwo = val;
                        checksumList.Add(val);
                        stan = 6;

                        continue;
                    }

                    if(stan == 6)
                    {
                        Int32 dataSum = 0;
                        foreach (Int32 d in dataList)
                        {
                            dataSum += d;
                        }
                        Int32 checkSum = 0;
                        foreach (Int32 s in checksumList)
                        {
                            checkSum += s;
                        }

                        if (dataSum == checkSum)
                        {
                            stan = 0;
                            this.richTextBoxIncomingData.Text += Convert.ToString(checksumOne);
                            this.richTextBoxIncomingData.Text += Convert.ToString(checksumTwo);
                        }
                        else
                        {
                            stan = 0;
                            comPort.Write(new byte[] { 0x15 }, 0, 1);
                        }

                        break;
                    }

                }

            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
        }

        private void SendData(Send send)
        {
            comPort.DtrEnable = true;
            comPort.RtsEnable = true;
            Thread.Sleep(15);

            if (statusReceive == true)
            {
                if (send == Send.Reset)
                {
                    comPort.Write(new byte[] { 0x02, 0x00, 0x3c, 0x3c, 0x00 }, 0, 5);
                }
                else if (send == Send.Phy)
                {
                    comPort.Write(new byte[] { 0x02, 0x02, 0x08, 0x00, 0x00, 0x0a, 0x00 }, 0, 7);
                }
                else if (send == Send.Dl)
                {
                    comPort.Write(new byte[] { 0x02, 0x02, 0x08, 0x00, 0x01, 0x0b, 0x00 }, 0, 7);
                }

                statusReceive = false;

            }

            comPort.RtsEnable = false;
            comPort.DtrEnable = true;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            SendData(Send.Reset);
        }

        private void PHYRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (DLRadio.Checked == true)
            {
                PHYRadio.Checked = false;
                SendData(Send.Phy);
            }
        }

        private void DLRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (PHYRadio.Checked == true)
            {
                DLRadio.Checked = false;
                SendData(Send.Dl);
            }
        }
    }

}