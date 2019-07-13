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
using System.Runtime.InteropServices;


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
        Graphics z2;
        Font myFont;
        Pen myPen;
        Pen myPen2;
        SolidBrush myBrush;
        FontFamily fontFamily;
        Color myColor;
        long count;
        
        const int BufferSize = 256;            // Size of buffer.
        byte[] buffer = new byte[BufferSize];  // read buffer.
        conDlg cd1 = new conDlg();
        puffer puf;
        byte[] byteData;

        
       [StructLayout(LayoutKind.Sequential)]
       public struct puffer
        {            
            public int id;
            
            public int x1, y1, x2, y2;
            
            public int pen, strength;

            //public Font font;
            
            public int color;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 35)]
            public string textmsg;
        }

        public Paint()
        {
            InitializeComponent();
            myBuffer = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format24bppRgb);
            paint = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format24bppRgb);
            z = Graphics.FromImage(paint);
            z2 = Graphics.FromImage(paint);
            z.FillRectangle(new SolidBrush(Color.White), 0, 0, ClientSize.Width, ClientSize.Height);
            g = panel1.CreateGraphics();
            b = Graphics.FromImage(myBuffer);
            myPen = Pens.Black;
            myPen2 = Pens.Black;
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

            /*
             * Struct exlanation: 
             * id 0=new 1=text 2=line 3=rect 4=free
             */
            puf.id = 0; puf.x1 = 0; puf.y1 = 0; puf.x2 = 0;
            puf.y2 = 0; puf.pen = 0; puf.strength = 0;/* puf.font = null;*/ puf.color = 0;
            puf.textmsg = "";

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
                    
                    if (cd1.connected)
                    {
                        this.Text = "Etwas wurde gesendet!";
                        puf.id = 2;
                        
                        //puf.pen = ...
                        //puf.strength = ....
                        puf.x1 = e.X; puf.y1 = e.Y;
                        puf.x2 = oldPoint.X; puf.y2 = oldPoint.Y;
                        byteData = this.getBytes(puf);
                        cd1.s.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), cd1.s);
                    }

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

            if (radioLinie.Checked) {
                z.DrawLine(myPen, oldPoint, new Point(e.X, e.Y));
                if (cd1.connected)
                {
                    this.Text = "Etwas wurde gesendet!";
                    puf.id = 3;

                    //puf.pen = ...
                    //puf.strength = ....
                    puf.x1 = e.X; puf.y1 = e.Y;
                    puf.x2 = oldPoint.X; puf.y2 = oldPoint.Y;
                    byteData = this.getBytes(puf);
                    cd1.s.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), cd1.s);
                }
            }
                
            else if (radioRecht.Checked)
                if (Math.Min(myPoint.X, e.X) == myPoint.X && Math.Min(myPoint.Y, e.Y) == myPoint.Y)
                    { z.DrawRectangle(myPen, myPoint.X, myPoint.Y, Math.Abs((e.X - myPoint.X)), Math.Abs((e.Y - myPoint.Y)));
                    if (cd1.connected)
                    {
                        this.Text = "Etwas wurde gesendet!";
                        puf.id = 4;

                        //puf.pen = ...
                        //puf.strength = ....
                        puf.x1 = myPoint.X; puf.y1 = myPoint.Y;
                        puf.x2 = Math.Abs((e.X - myPoint.X)); puf.y2 = Math.Abs((e.Y - myPoint.Y));
                        byteData = this.getBytes(puf);
                        cd1.s.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), cd1.s);
                    }
                }
                    
                else if (Math.Min(myPoint.X, e.X) == e.X && Math.Min(myPoint.Y, e.Y) == e.Y)
                    { z.DrawRectangle(myPen, e.X, e.Y, Math.Abs((e.X - myPoint.X)), Math.Abs((e.Y - myPoint.Y)));
                    if (cd1.connected)
                    {
                        this.Text = "Etwas wurde gesendet!";
                        puf.id = 4;

                        //puf.pen = ...
                        //puf.strength = ....
                        puf.x1 = e.X; puf.y1 = e.Y;
                        puf.x2 = Math.Abs((e.X - myPoint.X)); puf.y2 = Math.Abs((e.Y - myPoint.Y));
                        byteData = this.getBytes(puf);
                        cd1.s.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), cd1.s);
                    }
                }
                   
                else if (Math.Min(myPoint.X, e.X) == e.X && Math.Min(myPoint.Y, e.Y) == myPoint.Y)
                    { z.DrawRectangle(myPen, e.X, myPoint.Y, Math.Abs((e.X - myPoint.X)), Math.Abs((e.Y - myPoint.Y)));
                    if (cd1.connected)
                    {
                        this.Text = "Etwas wurde gesendet!";
                        puf.id = 4;

                        //puf.pen = ...
                        //puf.strength = ....
                        puf.x1 = e.X; puf.y1 = myPoint.Y;
                        puf.x2 = Math.Abs((e.X - myPoint.X)); puf.y2 = Math.Abs((e.Y - myPoint.Y));
                        byteData = this.getBytes(puf);
                        cd1.s.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), cd1.s);
                    }
                }
                   
                else if (Math.Min(myPoint.X, e.X) == myPoint.X && Math.Min(myPoint.Y, e.Y) == e.Y)
                    { z.DrawRectangle(myPen, myPoint.X, e.Y, Math.Abs((e.X - myPoint.X)), Math.Abs((e.Y - myPoint.Y)));
                    if (cd1.connected)
                    {
                        this.Text = "Etwas wurde gesendet!";
                        puf.id = 4;

                        //puf.pen = ...
                        //puf.strength = ....
                        puf.x1 = myPoint.X; puf.y1 = e.Y;
                        puf.x2 = Math.Abs((e.X - myPoint.X)); puf.y2 = Math.Abs((e.Y - myPoint.Y));
                        byteData = this.getBytes(puf);
                        cd1.s.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), cd1.s);
                    }
                }
                    
                
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

                if (cd1.connected)
                {
                    this.Text = "Etwas wurde gesendet!";
                    puf.id = 1;
                    puf.textmsg = textBox.Text;
                    //puf.font = myFont;
                    //puf.color = myColor.ToArgb();
                    puf.x1 = e.X; puf.y1 = e.Y;
                    byteData = this.getBytes(puf);
                    cd1.s.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), cd1.s);
                }
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
                    if (cd1.connected)
                    {
                        this.Text = "Etwas wurde gesendet!";
                        puf.id = 0;
                        byteData = this.getBytes(puf);
                        cd1.s.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), cd1.s);
                    }
                    break;
                    
                case DialogResult.No:
                    break;

                default:
                    break;
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {            
            cd1.ShowDialog();
            if(cd1.connected)
                cd1.s.BeginReceive(buffer, 0, buffer.Length, 0,
                          new AsyncCallback(ReadCallback), cd1.s);
        }

        public void ReadCallback(IAsyncResult ar)
        {
            try
            {
                int bytesRead = cd1.s.EndReceive(ar);
                if (bytesRead > 0)
                {
                    //handling of byte message
                    puf = this.fromBytes(buffer);
                    switch (puf.id)
                    {
                        case 0:
                            z.FillRectangle(new SolidBrush(Color.White), 0, 0, ClientSize.Width, ClientSize.Height);
                            this.Refresh();
                            this.Text = "Wurde Refreshed!";
                            break;
                        case 1:
                            z.DrawString(puf.textmsg, myFont,/* new SolidBrush(Color.FromArgb(puf.color))*/myBrush, puf.x1, puf.y1);
                            this.Refresh();
                            this.Text = "Text gesetzt!";
                            break;
                        case 2:
                            this.Invoke((MethodInvoker)(() => z.DrawLine(myPen, new Point(puf.x2, puf.y2), new Point(puf.x1, puf.y1))));
                            count++;
                            if (count%20 == 0) { 
                                this.Refresh();
                                this.Text = "Wurde gemalt!";
                            }
                            break;
                        case 3:
                            z.DrawLine(myPen, new Point(puf.x2, puf.y2), new Point(puf.x1, puf.y1));
                            this.Refresh();
                            this.Text = "Linie gezogen!";
                            break;
                        case 4:
                            z.DrawRectangle(myPen, puf.x1, puf.y1, puf.x2, puf.y2);
                            this.Refresh();
                            this.Text = "Rechteck gezogen!!";
                            break;
                    }

                    //End of Byte handling
                    if (cd1.connected)
                        cd1.s.BeginReceive(buffer, 0, buffer.Length, 0,
                                       new AsyncCallback(ReadCallback), cd1.s);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                cd1.statusField.BackColor = Color.Red;
                cd1.s.Close();
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Complete sending the data to the remote device.
                cd1.s.EndSend(ar);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                cd1.statusField.BackColor = Color.Red;
                cd1.s.Close();
            }
        }

        byte[] getBytes(puffer str)
        {
            //create big enough byte array
            int size = Marshal.SizeOf(str);
            byte[] arr = new byte[size];

            //pointer to unorganized memory
            IntPtr ptr = Marshal.AllocHGlobal(size);
            //struct to block of unorganized memory
            Marshal.StructureToPtr(str, ptr, true);
            //copies to organized memory array
            Marshal.Copy(ptr, arr, 0, size);
            //clear unorganized memory space
            Marshal.FreeHGlobal(ptr);
            return arr;
        }

        puffer fromBytes(byte[] arr)
        {
            puffer str = new puffer();

            int size = Marshal.SizeOf(str);
            //pointer to unorganized memory
            IntPtr ptr = Marshal.AllocHGlobal(size);

            //byte array to unorganized ptr memory
            Marshal.Copy(arr, 0, ptr, size);

            //unorganized memory to specified structure
            str = (puffer)Marshal.PtrToStructure(ptr, str.GetType());
            //clear unorganized memory space
            Marshal.FreeHGlobal(ptr);

            return str;
        }
    }
}//localhost = 127.0.0.1

// senden == s.BeginSend(byteData, 0, byteData.Length, SocketFlags.None,new AsyncCallback(SendCallback), cd.s);





//farbe und font für text nachrichten
//pen und stregth für freihand


