using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotATutorial
{
    public partial class Form1 : Form
    {


        private List<Bubble> bubbles = new List<Bubble>();


        public Form1()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", 
                System.Reflection.BindingFlags.SetProperty | 
                System.Reflection.BindingFlags.Instance | 
                System.Reflection.BindingFlags.NonPublic, 
                null, panel1, new Object[] { true });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            bubbles.ForEach(b => b.DrawBubble(e.Graphics));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (bubbles.Count > 0 && bubbles.Count >= numOfBubbles.Value)
            {
                bubbles.RemoveAt(0);
            }

            if (bubbles.Count < numOfBubbles.Value)
            {
                bubbles.Add(new Bubble(panel1));
            }

            bubbles.ForEach(b => b.GrowAndShrink());
            panel1.Invalidate();
            bubbles.RemoveAll(b => b.BubbleRadius <= 1);
        }
    }
}
