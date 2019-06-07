namespace Paint
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioRecht = new System.Windows.Forms.RadioButton();
            this.radioLinie = new System.Windows.Forms.RadioButton();
            this.radioFrei = new System.Windows.Forms.RadioButton();
            this.radioText = new System.Windows.Forms.RadioButton();
            this.Stifte = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numStift = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fontButton = new System.Windows.Forms.Button();
            this.colorButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numStift)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(15, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1180, 542);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Freihand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Linie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Rechteck";
            // 
            // radioRecht
            // 
            this.radioRecht.AutoSize = true;
            this.radioRecht.Location = new System.Drawing.Point(186, 32);
            this.radioRecht.Name = "radioRecht";
            this.radioRecht.Size = new System.Drawing.Size(14, 13);
            this.radioRecht.TabIndex = 5;
            this.radioRecht.TabStop = true;
            this.radioRecht.UseVisualStyleBackColor = true;
            // 
            // radioLinie
            // 
            this.radioLinie.AutoSize = true;
            this.radioLinie.Location = new System.Drawing.Point(125, 32);
            this.radioLinie.Name = "radioLinie";
            this.radioLinie.Size = new System.Drawing.Size(14, 13);
            this.radioLinie.TabIndex = 6;
            this.radioLinie.TabStop = true;
            this.radioLinie.UseVisualStyleBackColor = true;
            // 
            // radioFrei
            // 
            this.radioFrei.AutoSize = true;
            this.radioFrei.Location = new System.Drawing.Point(74, 32);
            this.radioFrei.Name = "radioFrei";
            this.radioFrei.Size = new System.Drawing.Size(14, 13);
            this.radioFrei.TabIndex = 6;
            this.radioFrei.TabStop = true;
            this.radioFrei.UseVisualStyleBackColor = true;
            // 
            // radioText
            // 
            this.radioText.AutoSize = true;
            this.radioText.Location = new System.Drawing.Point(12, 32);
            this.radioText.Name = "radioText";
            this.radioText.Size = new System.Drawing.Size(14, 13);
            this.radioText.TabIndex = 6;
            this.radioText.TabStop = true;
            this.radioText.UseVisualStyleBackColor = true;
            this.radioText.CheckedChanged += new System.EventHandler(this.radioText_CheckedChanged);
            // 
            // Stifte
            // 
            this.Stifte.FormattingEnabled = true;
            this.Stifte.Location = new System.Drawing.Point(312, 34);
            this.Stifte.Name = "Stifte";
            this.Stifte.Size = new System.Drawing.Size(98, 21);
            this.Stifte.TabIndex = 7;
            this.Stifte.SelectedIndexChanged += new System.EventHandler(this.Stifte_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stift";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(475, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Linienstärke";
            // 
            // numStift
            // 
            this.numStift.Location = new System.Drawing.Point(478, 35);
            this.numStift.Name = "numStift";
            this.numStift.Size = new System.Drawing.Size(61, 20);
            this.numStift.TabIndex = 10;
            this.numStift.ValueChanged += new System.EventHandler(this.numStift_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioText);
            this.groupBox1.Controls.Add(this.radioFrei);
            this.groupBox1.Controls.Add(this.radioLinie);
            this.groupBox1.Controls.Add(this.radioRecht);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(36, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 55);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(603, 14);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(101, 20);
            this.fontButton.TabIndex = 12;
            this.fontButton.Text = "Font wählen";
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(603, 43);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(101, 20);
            this.colorButton.TabIndex = 13;
            this.colorButton.Text = "Farbe wählen";
            this.colorButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Location = new System.Drawing.Point(761, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(58, 49);
            this.panel2.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(875, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 20);
            this.button3.TabIndex = 15;
            this.button3.Text = "Laden";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(875, 43);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 20);
            this.button4.TabIndex = 16;
            this.button4.Text = "Speichern";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1009, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(72, 52);
            this.button5.TabIndex = 17;
            this.button5.Text = "NEU";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1103, 11);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(64, 52);
            this.button6.TabIndex = 18;
            this.button6.Text = "Verbinden";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 625);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.fontButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numStift);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Stifte);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numStift)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioRecht;
        private System.Windows.Forms.RadioButton radioLinie;
        private System.Windows.Forms.RadioButton radioFrei;
        private System.Windows.Forms.RadioButton radioText;
        private System.Windows.Forms.ComboBox Stifte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numStift;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button fontButton;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}

