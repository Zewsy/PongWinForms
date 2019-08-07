using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Form1 : Form
    {
        Racket racket;
        Ball ball;
        public Form1()
        {
            racket = new Racket();
            ball = new Ball();
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(Brushes.Gray, new Rectangle(20, 150, 5, 50));
            e.Graphics.FillRectangle(Brushes.Gray, new Rectangle(550, 150, 5, 50));
            e.Graphics.FillEllipse(Brushes.White, new RectangleF(280, 150, 15, 15));
        }
    }
}
