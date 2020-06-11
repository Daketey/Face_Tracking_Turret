namespace detect2
{
    partial class Form1
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
            this.button = new System.Windows.Forms.Button();
            this.picbox = new System.Windows.Forms.PictureBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(549, 552);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 30);
            this.button.TabIndex = 0;
            this.button.Text = "Switch";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // picbox
            // 
            this.picbox.Location = new System.Drawing.Point(12, 0);
            this.picbox.Name = "picbox";
            this.picbox.Size = new System.Drawing.Size(1159, 546);
            this.picbox.TabIndex = 1;
            this.picbox.TabStop = false;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM8";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 615);
            this.Controls.Add(this.picbox);
            this.Controls.Add(this.button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button;
        private System.Windows.Forms.PictureBox picbox;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

