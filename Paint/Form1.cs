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



        }

        ~Form1 () {
            z.Dispose(); g.Dispose(); b.Dispose();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)                 
            {
                
                b.DrawImage(paint, 0, 0, myBuffer.Width, myBuffer.Height);
                if (radioLinie.Checked)
                    b.DrawLine(myPen, oldPoint, new Point(e.X, e.Y));
                else if (radioRecht.Checked)
                    b.DrawRectangle(myPen, oldPoint.X, oldPoint.Y, (e.X - oldPoint.X), (e.Y - oldPoint.Y));
                //else if (radioFrei.Checked)

                //else if (radioText.Checked)
                g.DrawImage(myBuffer, 0, 0, myBuffer.Width, myBuffer.Height);
                

            }

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            oldPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            z = Graphics.FromImage(paint);
            if (radioLinie.Checked) 
                z.DrawLine(myPen, oldPoint, new Point(e.X, e.Y));
            else if (radioRecht.Checked)
                z.DrawRectangle(myPen, oldPoint.X, oldPoint.Y, (e.X - oldPoint.X), (e.Y - oldPoint.Y));
            //else if (radioText.Checked)

            //else if (radioFrei.Checked)


           
           
        }

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
                }
        }

        private void fontButton_Click(object sender, EventArgs e)
        {
           

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