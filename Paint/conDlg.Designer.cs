namespace Paint
{
    partial class conDlg
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
            this.conButton = new System.Windows.Forms.Button();
            this.disConButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.socketBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.statusField = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // conButton
            // 
            this.conButton.Location = new System.Drawing.Point(130, 108);
            this.conButton.Name = "conButton";
            this.conButton.Size = new System.Drawing.Size(232, 58);
            this.conButton.TabIndex = 0;
            this.conButton.Text = "Verbinden";
            this.conButton.UseVisualStyleBackColor = true;
            this.conButton.Click += new System.EventHandler(this.conButton_Click);
            // 
            // disConButton
            // 
            this.disConButton.Location = new System.Drawing.Point(130, 181);
            this.disConButton.Name = "disConButton";
            this.disConButton.Size = new System.Drawing.Size(232, 57);
            this.disConButton.TabIndex = 1;
            this.disConButton.Text = "Verbindung trennen";
            this.disConButton.UseVisualStyleBackColor = true;
            this.disConButton.Click += new System.EventHandler(this.disConButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Socket - Nr:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port - Nr:";
            // 
            // socketBox
            // 
            this.socketBox.Location = new System.Drawing.Point(130, 25);
            this.socketBox.Name = "socketBox";
            this.socketBox.Size = new System.Drawing.Size(232, 20);
            this.socketBox.TabIndex = 4;
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(130, 73);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(232, 20);
            this.portBox.TabIndex = 5;
            // 
            // statusField
            // 
            this.statusField.Location = new System.Drawing.Point(264, 244);
            this.statusField.Name = "statusField";
            this.statusField.Size = new System.Drawing.Size(57, 52);
            this.statusField.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Status: ";
            // 
            // conDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 308);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusField);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.socketBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.disConButton);
            this.Controls.Add(this.conButton);
            this.Name = "conDlg";
            this.Text = "conDlg";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button conButton;
        private System.Windows.Forms.Button disConButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox socketBox;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Panel statusField;
        private System.Windows.Forms.Label label3;
    }
}