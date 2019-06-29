using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Sockets;


namespace Paint
{
    public partial class Paint : Form
    {
        Point oldPoint;
        Point myPoint;
        Bitmap myBuffer;        
        Bitmap paint;
        Graphics g;
        Graphics b;    
        Graphics z;
        Font myFont;
        Pen myPen;
        SolidBrush myBrush;
        FontFamily fontFamily;
        Color myColor;
        conDlg cd = new conDlg();
        const int BufferSize = 256;            // Size of buffer.
        byte[] buffer = new byte[BufferSize];  // read buffer.
 
        struct puffer
        {
            int id;
            int x1, y1, x2, y2;
            //int 
        }

        public Paint()
        {
            InitializeComponent();
            myBuffer = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format24bppRgb);
            paint = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format24bppRgb);
            z = Graphics.FromImage(paint);
            z.FillRectangle(new SolidBrush(Color.White), 0, 0, ClientSize.Width, ClientSize.Height);
            g = panel1.CreateGraphics();
            b = Graphics.FromImage(myBuffer);
            myPen = Pens.Black;
            Stifte.Items.Add("Schwarz");
            Stifte.Items.Add("Blau");
            Stifte.Items.Add("Rot");
            Stifte.Items.Add("Grün");
            Stifte.Items.Add("Gelb");
            fontFamily = new FontFamily("Arial");
            myFont = new Font(
               fontFamily,
               16,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
            textBox.Text = "Text bitte hier eingeben.";
            myBrush = new SolidBrush(Color.Black);
            panel2.BackColor = Color.Black;

            //tooltips
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for itmes
            toolTip1.SetToolTip(this.radioText, "Schreibe etwas Text...");
            toolTip1.SetToolTip(this.radioLinie, "Zeichne ein paar Linien...");
            toolTip1.SetToolTip(this.radioRecht, "Zeichne ein paar Rechtecke...");
            toolTip1.SetToolTip(this.radioFrei, "Zeichne einfach freihand...");
            toolTip1.SetToolTip(this.Stifte, "Wähle deinn Lieblingsstift...");
            toolTip1.SetToolTip(this.numStift, "Wie stark soll dein Stift zeichnen?");
            toolTip1.SetToolTip(this.fontButton, "Du kannst hier deine Schriftart wählen...");
            toolTip1.SetToolTip(this.colorButton, "Du kannst hier deine Schriftfarbe wählen...");
            toolTip1.SetToolTip(this.loadButton, "Hier kannst du dein Bild laden...");
            toolTip1.SetToolTip(this.saveButton, "Hier kannst du ein Bild speichern...");
            toolTip1.SetToolTip(this.newButton, "Fange ein neues Bild an...");
            toolTip1.SetToolTip(this.connectButton, "Male ein Bild mit deinen Freunden...");

        }

        ~Paint () {
            z.Dispose(); g.Dispose(); b.Dispose();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)                 
            {
                //bisheriges auf puffer
                b.DrawImage(paint, 0, 0, myBuffer.Width, myBuffer.Height);
                //neues auf Puffer
                if (radioLinie.Checked)
                    b.DrawLine(myPen, oldPoint, new Point(e.X, e.Y));
                else if (radioRecht.Checked) {
                    if(Math.Min(myPoint.X, e.X) == myPoint.X && Math.Min(myPoint.Y, e.Y) == myPoint.Y)
                        b.DrawRectangle(myPen, myPoint.X, myPoint.Y, Math.Abs((e.X - myPoint.X)), Math.Abs((e.Y - myPoint.Y)));
                    else if (Math.Min(myPoint.X, e.X) == e.X && Math.Min(myPoint.Y, e.Y) == e.Y)
                        b.DrawRectangle(myPen, e.X, e.Y, Math.Abs((e.X - myPoint.X)), Math.Abs((e.Y - myPoint.Y)));
                    else if (Math.Min(myPoint.X, e.X) == e.X && Math.Min(myPoint.Y, e.Y) == myPoint.Y)
                        b.DrawRectangle(myPen, e.X, myPoint.Y, Math.Abs((e.X - myPoint.X)), Math.Abs((e.Y - myPoint.Y)));
                    else if (Math.Min(myPoint.X, e.X) == myPoint.X && Math.Min(myPoint.Y, e.Y) == e.Y)
                        b.DrawRectangle(myPen, myPoint.X, e.Y, Math.Abs((e.X - myPoint.X)), Math.Abs((e.Y - myPoint.Y)));
                }

                else if (radioFrei.Checked)
                {
                    z.DrawLine(myPen, oldPoint, new Point(e.X, e.Y));
                    oldPoint = new Point(e.X, e.Y);                    
                }

                //puffer auf bild
                g.DrawImage(myBuffer, 0, 0, myBuffer.Width, myBuffer.Height);
                

            }

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            oldPoint = new Point(e.X, e.Y);
            if (radioRecht.Checked)
                 myPoint = new Point(e.X,e.Y);
           
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

            if (radioLinie.Checked)
                z.DrawLine(myPen, oldPoint, new Point(e.X, e.Y));
            else if (radioRecht.Checked)
                if (Math.Min(myPoint.X, e.X) == myPoint.X && Math.Min(myPoint.Y, e.Y) == myPoint.Y)
                    z.DrawRectangle(myPen, myPoint.X, myPoint.Y, Math.Abs((e.X - myPoint.X)), Math.Abs((e.Y - myPoint.Y)));
                else if (Math.Min(myPoint.X, e.X) == e.X && Math.Min(myPoint.Y, e.Y) == e.Y)
                    z.DrawRectangle(myPen, e.X, e.Y, Math.Abs((e.X - myPoint.X)), Math.Abs((e.Y - myPoint.Y)));
                else if (Math.Min(myPoint.X, e.X) == e.X && Math.Min(myPoint.Y, e.Y) == myPoint.Y)
                    z.DrawRectangle(myPen, e.X, myPoint.Y, Math.Abs((e.X - myPoint.X)), Math.Abs((e.Y - myPoint.Y)));
                else if (Math.Min(myPoint.X, e.X) == myPoint.X && Math.Min(myPoint.Y, e.Y) == e.Y)
                    z.DrawRectangle(myPen, myPoint.X, e.Y, Math.Abs((e.X - myPoint.X)), Math.Abs((e.Y - myPoint.Y)));
                
        }

        //Altes aktualisiert
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(paint, 0, 0, paint.Width, paint.Height);
        }

        private void Stifte_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((String)Stifte.SelectedItem)
            {
                case "Schwarz":
                    myColor = Color.Black;
                    myPen = new Pen(myColor, (float)numStift.Value);
                    break;
                case "Blau":
                    myColor = Color.Blue;
                    myPen = new Pen(myColor, (float)numStift.Value);
                    break;
                case "Rot":
                   myColor = Color.Red;
                   myPen = new Pen(myColor, (float)numStift.Value);
                    break;
                case "Grün":
                   myColor = Color.Green;
                   myPen = new Pen(myColor, (float)numStift.Value);
                    break;
                case "Gelb":
                    myColor = Color.Yellow;
                    myPen = new Pen(myColor, (float)numStift.Value);
                    break;
                default:
                    myColor = Color.Black;
                    myPen = new Pen(myColor, (float)numStift.Value);
                    break;
            }
        }

        private void numStift_ValueChanged(object sender, EventArgs e)
        {
            myPen = new Pen(myColor, (float) numStift.Value);
        }

        private void radioText_CheckedChanged(object sender, EventArgs e)
        {
            if (radioText.Checked)
                {
                    fontButton.Enabled = true;
                    colorButton.Enabled = true;
                    Stifte.Enabled = false;
                    numStift.Enabled = false;
                }
        }

       

        private void radioFrei_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFrei.Checked) {
                fontButton.Enabled = false;
                colorButton.Enabled = false;
                Stifte.Enabled = true;
                numStift.Enabled = true;
            }
            
        }

        private void radioLinie_CheckedChanged(object sender, EventArgs e)
        {
            if (radioLinie.Checked) {
                fontButton.Enabled = false;
                colorButton.Enabled = false;
                Stifte.Enabled = true;
                numStift.Enabled = true;
            }
      
        }

        private void radioRecht_CheckedChanged(object sender, EventArgs e)
        {
            if (radioRecht.Checked)
            {
                fontButton.Enabled = false;
                colorButton.Enabled = false;
                Stifte.Enabled = true;
                numStift.Enabled = true;
            }
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
            FontDialog dlg = new FontDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                myFont = dlg.Font;
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.FullOpen = true;
            // Sets the initial color
            dlg.Color = Color.Black;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Font color
                myBrush = new SolidBrush(dlg.Color);
                //Color Box
                panel2.BackColor = dlg.Color;
            }
            
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            textBox.Text = "";
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if ( string.Equals(textBox.Text,""))
                textBox.Text = "Text bitte hier eingeben.";
        }

  

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (radioText.Checked)
            {
                z.DrawString(textBox.Text, myFont, myBrush, e.X, e.Y);
                this.Refresh();
            }
               
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "jpg files (*.jpg) | *.jpg ";
            dlg.FilterIndex = 0; // start with Filter *.*
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                z.FillRectangle(new SolidBrush(Color.White), 0, 0, ClientSize.Width, ClientSize.Height);
                String filename = dlg.FileName;
                Bitmap loaded = new Bitmap(filename);                
                z.DrawImage(loaded, 0, 0, paint.Width, paint.Height);
                this.Refresh();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
               int width = Convert.ToInt32(panel1.Width); 
               int height = Convert.ToInt32(panel1.Height); 
               Bitmap bmp = new Bitmap(width,height);        
               panel1.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
               bmp.Save(dialog.FileName, ImageFormat.Jpeg);
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Bist du sicher das du ein neues Bild erstellen und das Alte verwerfen willst?", "Neues Bild", MessageBoxButtons.YesNo)) 
            {           
                case DialogResult.Yes:                    
                    z.FillRectangle(new SolidBrush(Color.White), 0, 0, ClientSize.Width, ClientSize.Height);
                    this.Refresh();
                    break;
                
                case DialogResult.No:
                    break;

                default:
                    break;
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            conDlg cd = new conDlg();
            cd.ShowDialog();
            if(cd.connected)
                cd.s.BeginReceive(buffer, 0, buffer.Length, 0,
                          new AsyncCallback(ReadCallback), cd.s);
        }

        public void ReadCallback(IAsyncResult ar)
        {
            try
            {
                int bytesRead = cd.s.EndReceive(ar);
                if (bytesRead > 0)
                {
                    cd.statusField.BackColor = Color.Blue;
                    //handling of byte message
                    if (cd.connected)
                        cd.s.BeginReceive(buffer, 0, buffer.Length, 0,
                                       new AsyncCallback(ReadCallback), cd.s);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                cd.statusField.BackColor = Color.Red;
                cd.s.Close();
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Complete sending the data to the remote device.
                cd.s.EndSend(ar);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                cd.statusField.BackColor = Color.Red;
                cd.s.Close();
            }
        }
    }
}//localhost = 127.0.0.1

// senden == s.BeginSend(byteData, 0, byteData.Length, SocketFlags.None,new AsyncCallback(SendCallback), cd.s);





//server  -->> übertragung mit int array für zeichenoperationen  -->> bei 2 teilnehmern kein server in der mitte nötig aber bei mehr leuten schon und man muss sonst die adressden kennen
//install connectivity funcionality
//DB


