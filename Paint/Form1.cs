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

namespace Paint
{
    public partial class Form1 : Form
    {
        Point oldPoint;
        Point myPoint;
        Bitmap myBuffer;                Bitmap paint;
        Graphics g;
        Graphics b;    
        Graphics z;
        Font myFont;
        Pen myPen;
        Brush myBrush;
        FontFamily fontFamily;
        Color myColor;

        public Form1()
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
            myBrush = Brushes.Black;


        }

        ~Form1 () {
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
                else if (radioRecht.Checked)
                    z.DrawRectangle(myPen, e.X, e.Y, (myPoint.X - e.X), (myPoint.Y - e.Y));
                //else if (radioFrei.Checked)
           
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
            z = Graphics.FromImage(paint);
            if (radioLinie.Checked) 
                z.DrawLine(myPen, oldPoint, new Point(e.X, e.Y));
            else if (radioRecht.Checked)
                z.DrawRectangle(myPen, e.X, e.Y, ( myPoint.X - e.X ), ( myPoint.Y - e.Y));
            //else if (radioFrei.Checked)


           
           
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


        }

        private void colorButton_Click(object sender, EventArgs e)
        {

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
                z.DrawString(textBox.Text, myFont, myBrush, e.X, e.Y);
        }
    }
}


//myFont = new Font(
//               fontFamily,
//               (float) numStift.Value,
//               FontStyle.Regular,
//               GraphicsUnit.Pixel);

//tooltips
//server
//datei
//DB


//fix text
//fix triangle