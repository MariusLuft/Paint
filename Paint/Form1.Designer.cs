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
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numStift)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(20, 94);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1573, 667);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Freihand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Linie";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(227, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Rechteck";
            // 
            // radioRecht
            // 
            this.radioRecht.AutoSize = true;
            this.radioRecht.Location = new System.Drawing.Point(248, 39);
            this.radioRecht.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioRecht.Name = "radioRecht";
            this.radioRecht.Size = new System.Drawing.Size(17, 16);
            this.radioRecht.TabIndex = 5;
            this.radioRecht.TabStop = true;
            this.radioRecht.UseVisualStyleBackColor = true;
            this.radioRecht.CheckedChanged += new System.EventHandler(this.radioRecht_CheckedChanged);
            // 
            // radioLinie
            // 
            this.radioLinie.AutoSize = true;
            this.radioLinie.Location = new System.Drawing.Point(167, 39);
            this.radioLinie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioLinie.Name = "radioLinie";
            this.radioLinie.Size = new System.Drawing.Size(17, 16);
            this.radioLinie.TabIndex = 6;
            this.radioLinie.TabStop = true;
            this.radioLinie.UseVisualStyleBackColor = true;
            this.radioLinie.CheckedChanged += new System.EventHandler(this.radioLinie_CheckedChanged);
            // 
            // radioFrei
            // 
            this.radioFrei.AutoSize = true;
            this.radioFrei.Location = new System.Drawing.Point(99, 39);
            this.radioFrei.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioFrei.Name = "radioFrei";
            this.radioFrei.Size = new System.Drawing.Size(17, 16);
            this.radioFrei.TabIndex = 6;
            this.radioFrei.TabStop = true;
            this.radioFrei.UseVisualStyleBackColor = true;
            this.radioFrei.CheckedChanged += new System.EventHandler(this.radioFrei_CheckedChanged);
            // 
            // radioText
            // 
            this.radioText.AutoSize = true;
            this.radioText.Location = new System.Drawing.Point(16, 39);
            this.radioText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioText.Name = "radioText";
            this.radioText.Size = new System.Drawing.Size(17, 16);
            this.radioText.TabIndex = 6;
            this.radioText.TabStop = true;
            this.radioText.UseVisualStyleBackColor = true;
            this.radioText.CheckedChanged += new System.EventHandler(this.radioText_CheckedChanged);
            // 
            // Stifte
            // 
            this.Stifte.FormattingEnabled = true;
            this.Stifte.Location = new System.Drawing.Point(360, 43);
            this.Stifte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Stifte.Name = "Stifte";
            this.Stifte.Size = new System.Drawing.Size(129, 24);
            this.Stifte.TabIndex = 7;
            this.Stifte.SelectedIndexChanged += new System.EventHandler(this.Stifte_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(407, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stift";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(523, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Linienstärke";
            // 
            // numStift
            // 
            this.numStift.Location = new System.Drawing.Point(527, 43);
            this.numStift.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numStift.Name = "numStift";
            this.numStift.Size = new System.Drawing.Size(81, 22);
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
            this.groupBox1.Location = new System.Drawing.Point(20, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(315, 68);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // fontButton
            // 
            this.fontButton.Location = new System.Drawing.Point(919, 17);
            this.fontButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(135, 25);
            this.fontButton.TabIndex = 12;
            this.fontButton.Text = "Font wählen";
            this.fontButton.UseVisualStyleBackColor = true;
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(919, 53);
            this.colorButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(135, 25);
            this.colorButton.TabIndex = 13;
            this.colorButton.Text = "Farbe wählen";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Location = new System.Drawing.Point(1085, 18);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(77, 60);
            this.panel2.TabIndex = 14;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(1207, 18);
            this.loadButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(135, 25);
            this.loadButton.TabIndex = 15;
            this.loadButton.Text = "Laden";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1207, 54);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(135, 25);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "Speichern";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(1373, 15);
            this.newButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(96, 64);
            this.newButton.TabIndex = 17;
            this.newButton.Text = "NEU";
            this.newButton.UseVisualStyleBackColor = true;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(1492, 15);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(85, 64);
            this.connectButton.TabIndex = 18;
            this.connectButton.Text = "Verbinden";
            this.connectButton.UseVisualStyleBackColor = true;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(652, 16);
            this.textBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(227, 62);
            this.textBox.TabIndex = 19;
            this.textBox.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1616, 769);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.fontButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numStift);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Stifte);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Paint";
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
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox textBox;
    }
}

