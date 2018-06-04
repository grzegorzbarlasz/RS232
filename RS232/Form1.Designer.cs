namespace RS232
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxComPorts = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.comboBoxHandshake = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.richTextBoxIncomingData = new System.Windows.Forms.RichTextBox();
            this.labelConnected = new System.Windows.Forms.Label();
            this.DLRadio = new System.Windows.Forms.RadioButton();
            this.PHYRadio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // comboBoxComPorts
            // 
            this.comboBoxComPorts.FormattingEnabled = true;
            this.comboBoxComPorts.Location = new System.Drawing.Point(13, 13);
            this.comboBoxComPorts.Name = "comboBoxComPorts";
            this.comboBoxComPorts.Size = new System.Drawing.Size(90, 21);
            this.comboBoxComPorts.TabIndex = 0;
            this.comboBoxComPorts.Text = "COM";
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Location = new System.Drawing.Point(109, 13);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(90, 21);
            this.comboBoxBaudrate.TabIndex = 1;
            this.comboBoxBaudrate.Text = "BAUDRATE";
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Location = new System.Drawing.Point(205, 13);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(90, 21);
            this.comboBoxDataBits.TabIndex = 2;
            this.comboBoxDataBits.Text = "DATA BITS";
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new System.Drawing.Point(301, 12);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(90, 21);
            this.comboBoxParity.TabIndex = 3;
            this.comboBoxParity.Text = "PARITY";
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Location = new System.Drawing.Point(398, 13);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(90, 21);
            this.comboBoxStopBits.TabIndex = 4;
            this.comboBoxStopBits.Text = "STOP BITS";
            // 
            // comboBoxHandshake
            // 
            this.comboBoxHandshake.FormattingEnabled = true;
            this.comboBoxHandshake.Location = new System.Drawing.Point(495, 13);
            this.comboBoxHandshake.Name = "comboBoxHandshake";
            this.comboBoxHandshake.Size = new System.Drawing.Size(90, 21);
            this.comboBoxHandshake.TabIndex = 5;
            this.comboBoxHandshake.Text = "HANDSHAKE";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(13, 41);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(90, 23);
            this.buttonConnect.TabIndex = 6;
            this.buttonConnect.Text = "CONNECT";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxSend
            // 
            this.textBoxSend.Location = new System.Drawing.Point(13, 71);
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(186, 20);
            this.textBoxSend.TabIndex = 7;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(206, 71);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(89, 23);
            this.buttonSend.TabIndex = 8;
            this.buttonSend.Text = "SEND";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(495, 70);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(90, 23);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "RESET";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // richTextBoxIncomingData
            // 
            this.richTextBoxIncomingData.Location = new System.Drawing.Point(13, 97);
            this.richTextBoxIncomingData.Name = "richTextBoxIncomingData";
            this.richTextBoxIncomingData.Size = new System.Drawing.Size(573, 223);
            this.richTextBoxIncomingData.TabIndex = 10;
            this.richTextBoxIncomingData.Text = "";
            // 
            // labelConnected
            // 
            this.labelConnected.AutoSize = true;
            this.labelConnected.BackColor = System.Drawing.Color.Yellow;
            this.labelConnected.Location = new System.Drawing.Point(109, 46);
            this.labelConnected.Name = "labelConnected";
            this.labelConnected.Size = new System.Drawing.Size(100, 13);
            this.labelConnected.TabIndex = 11;
            this.labelConnected.Text = "NOT CONNECTED";
            // 
            // DLRadio
            // 
            this.DLRadio.AutoSize = true;
            this.DLRadio.Location = new System.Drawing.Point(449, 74);
            this.DLRadio.Name = "DLRadio";
            this.DLRadio.Size = new System.Drawing.Size(39, 17);
            this.DLRadio.TabIndex = 12;
            this.DLRadio.TabStop = true;
            this.DLRadio.Text = "DL";
            this.DLRadio.UseVisualStyleBackColor = true;
            this.DLRadio.CheckedChanged += new System.EventHandler(this.DLRadio_CheckedChanged);
            // 
            // PHYRadio
            // 
            this.PHYRadio.AutoSize = true;
            this.PHYRadio.Location = new System.Drawing.Point(396, 73);
            this.PHYRadio.Name = "PHYRadio";
            this.PHYRadio.Size = new System.Drawing.Size(47, 17);
            this.PHYRadio.TabIndex = 13;
            this.PHYRadio.TabStop = true;
            this.PHYRadio.Text = "PHY";
            this.PHYRadio.UseVisualStyleBackColor = true;
            this.PHYRadio.CheckedChanged += new System.EventHandler(this.PHYRadio_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 332);
            this.Controls.Add(this.PHYRadio);
            this.Controls.Add(this.DLRadio);
            this.Controls.Add(this.labelConnected);
            this.Controls.Add(this.richTextBoxIncomingData);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.comboBoxHandshake);
            this.Controls.Add(this.comboBoxStopBits);
            this.Controls.Add(this.comboBoxParity);
            this.Controls.Add(this.comboBoxDataBits);
            this.Controls.Add(this.comboBoxBaudrate);
            this.Controls.Add(this.comboBoxComPorts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxComPorts;
        private System.Windows.Forms.ComboBox comboBoxBaudrate;
        private System.Windows.Forms.ComboBox comboBoxDataBits;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.ComboBox comboBoxHandshake;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.RichTextBox richTextBoxIncomingData;
        private System.Windows.Forms.Label labelConnected;
        private System.Windows.Forms.RadioButton DLRadio;
        private System.Windows.Forms.RadioButton PHYRadio;
    }
}

