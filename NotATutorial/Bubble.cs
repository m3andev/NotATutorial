using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotATutorial
{
    internal class Bubble
    {
        private Point Center;
        private int Radius;
        private int Thickness;
        private Color BubbleColor;
        private bool growing = true;
        private int growth = 0;

        private static Color[] BubbleColors =
        {
            Color.Red,
            Color.Orange,
            Color.Yellow,
            Color.Green,
            Color.Blue,
            Color.Indigo,
            Color.Violet
        };

        public int BubbleRadius
        {
            get { return Radius; }
        }

        private Random R = new Random();

        public Bubble(Panel p)
        {
            Center = new Point(R.Next(p.Width), R.Next(p.Height));
            Radius = R.Next(30, 100);
            Thickness = R.Next(1, 10);
            BubbleColor = BubbleColors[R.Next(BubbleColors.Length)];
        }

        public void DrawBubble(Graphics g)
        {
            Rectangle rc = new Rectangle(Center, new Size(1, 1));
            rc.Inflate(Radius, Radius);
            using (Pen p = new Pen(BubbleColor, Thickness))
            {
                using (SolidBrush b = new SolidBrush(Color.FromArgb(128, BubbleColor)))
                {
                    g.FillEllipse(b, rc);
                }
                g.DrawEllipse(p, rc);
            }
        }

        public void GrowAndShrink()
        {
            if (growing)
            {
                Radius = Radius + 5;
                growth++;
                if (growth == 5)
                {
                    growing = false;
                }
            }
            else
            {
                Radius = Radius - 2;
                if (Radius < 1)
                {
                    Radius = 1;
                }
                Thickness = Thickness / 2;
            }
        }
    }
}
