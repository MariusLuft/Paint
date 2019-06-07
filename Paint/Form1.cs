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
        public Form1()
        {
            InitializeComponent();
            myBuffer = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format24bppRgb);
            paint = new Bitmap(ClientSize.Width, ClientSize.Height, PixelFormat.Format24bppRgb);
            Graphics z = Graphics.FromImage(paint);
            z.FillRectangle(new SolidBrush(Color.White), 0, 0, ClientSize.Width, ClientSize.Height);
            z.Dispose();
           
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = CreateGraphics();
                Graphics b = Graphics.FromImage(myBuffer);
                b.DrawImage(paint, 0, 0, myBuffer.Width, myBuffer.Height);
                b.DrawLine(Pens.Black, oldPoint, new Point(e.X, e.Y));
                g.DrawImage(myBuffer, 0, 0, myBuffer.Width, myBuffer.Height);
                g.Dispose(); b.Dispose();
            }


        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            oldPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics z = Graphics.FromImage(paint);
            z.DrawLine(Pens.Black, oldPoint, new Point(e.X, e.Y));
            z.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(paint, 0, 0, paint.Width, paint.Height);
        }
    }
}
