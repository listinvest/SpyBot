namespace SpyBot
{
    partial class RadForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.visualStudio2012DarkTheme1 = new Telerik.WinControls.Themes.VisualStudio2012DarkTheme();
            this.left_trig_value = new Telerik.WinControls.UI.RadTextBox();
            this.connect_wsclient_button = new Telerik.WinControls.UI.RadButton();
            this.wsclient = new nsoftware.IPWorksWS.Wsclient(this.components);
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbEcho = new System.Windows.Forms.TextBox();
            this.bSend = new Telerik.WinControls.UI.RadButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.left_stick_x_value = new Telerik.WinControls.UI.RadTextBox();
            this.left_stick_y_value = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.left_trig_value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.connect_wsclient_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_stick_x_value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_stick_y_value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // left_trig_value
            // 
            this.left_trig_value.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.left_trig_value.Location = new System.Drawing.Point(51, 35);
            this.left_trig_value.Name = "left_trig_value";
            this.left_trig_value.Size = new System.Drawing.Size(70, 28);
            this.left_trig_value.TabIndex = 0;
            this.left_trig_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.left_trig_value.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.left_trig_value.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(136)))), ((int)(((byte)(142)))));
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.left_trig_value.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // connect_wsclient_button
            // 
            this.connect_wsclient_button.Location = new System.Drawing.Point(611, 110);
            this.connect_wsclient_button.Name = "connect_wsclient_button";
            this.connect_wsclient_button.Size = new System.Drawing.Size(110, 24);
            this.connect_wsclient_button.TabIndex = 1;
            this.connect_wsclient_button.Text = "Connect";
            this.connect_wsclient_button.ThemeName = "VisualStudio2012Dark";
            this.connect_wsclient_button.Click += new System.EventHandler(this.connect_wsclient_button_Click);
            // 
            // wsclient
            // 
            this.wsclient.About = "IP*Works! WS V9 [Build 5414]";
            this.wsclient.OnConnected += new nsoftware.IPWorksWS.Wsclient.OnConnectedHandler(this.wsclient_OnConnected);
            this.wsclient.OnDataIn += new nsoftware.IPWorksWS.Wsclient.OnDataInHandler(this.wsclient_OnDataIn);
            this.wsclient.OnDisconnected += new nsoftware.IPWorksWS.Wsclient.OnDisconnectedHandler(this.wsclient_OnDisconnected);
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(51, 110);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(297, 20);
            this.tbServer.TabIndex = 2;
            this.tbServer.Text = "ws://10.10.10.246:8888/ws";
            // 
            // tbEcho
            // 
            this.tbEcho.Location = new System.Drawing.Point(51, 223);
            this.tbEcho.Multiline = true;
            this.tbEcho.Name = "tbEcho";
            this.tbEcho.Size = new System.Drawing.Size(744, 174);
            this.tbEcho.TabIndex = 4;
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(611, 167);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(110, 24);
            this.bSend.TabIndex = 5;
            this.bSend.Text = "Send";
            this.bSend.ThemeName = "VisualStudio2012Dark";
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(465, 39);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "hello";
            // 
            // left_stick_x_value
            // 
            this.left_stick_x_value.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.left_stick_x_value.Location = new System.Drawing.Point(156, 35);
            this.left_stick_x_value.Name = "left_stick_x_value";
            this.left_stick_x_value.Size = new System.Drawing.Size(65, 28);
            this.left_stick_x_value.TabIndex = 7;
            this.left_stick_x_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.left_stick_x_value.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.left_stick_x_value.GetChildAt(0).GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(136)))), ((int)(((byte)(142)))));
            ((Telerik.WinControls.UI.RadTextBoxItem)(this.left_stick_x_value.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            // 
            // left_stick_y_value
            // 
            this.left_stick_y_value.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.left_stick_y_value.Location = new System.Drawing.Point(252, 35);
            this.left_stick_y_value.Name = "left_stick_y_value";
            this.left_stick_y_value.Size = new System.Drawing.Size(76, 28);
            this.left_stick_y_value.TabIndex = 8;
            this.left_stick_y_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.left_stick_y_value.ThemeName = "VisualStudio2012Dark";
            ((Telerik.WinControls.UI.RadTextBoxElement)(this.left_stick_y_value.GetChildAt(0))).ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(136)))), ((int)(((byte)(142)))));
            // 
            // RadForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 425);
            this.Controls.Add(this.left_stick_y_value);
            this.Controls.Add(this.left_stick_x_value);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.tbEcho);
            this.Controls.Add(this.tbServer);
            this.Controls.Add(this.connect_wsclient_button);
            this.Controls.Add(this.left_trig_value);
            this.Name = "RadForm1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "RadForm1";
            this.ThemeName = "VisualStudio2012Dark";
            this.Load += new System.EventHandler(this.RadForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.left_trig_value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.connect_wsclient_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_stick_x_value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left_stick_y_value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.VisualStudio2012DarkTheme visualStudio2012DarkTheme1;
        private Telerik.WinControls.UI.RadTextBox left_trig_value;
        private Telerik.WinControls.UI.RadButton connect_wsclient_button;
        private nsoftware.IPWorksWS.Wsclient wsclient;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TextBox tbEcho;
        private Telerik.WinControls.UI.RadButton bSend;
        private System.Windows.Forms.TextBox textBox1;
        private Telerik.WinControls.UI.RadTextBox left_stick_x_value;
        private Telerik.WinControls.UI.RadTextBox left_stick_y_value;
    }
}