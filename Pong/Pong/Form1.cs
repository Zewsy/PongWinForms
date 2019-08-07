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
        Racket racket1, racket2;
        Ball ball;
        const int START_X = 20;
        public Form1()
        {
            InitializeComponent();
            racket1 = new Racket(START_X, this.Size.Height / 2 - 50);
            racket2 = new Racket(this.Size.Width - START_X * 2, this.Size.Height / 2 - 50);
            ball = new Ball(this.Size.Width / 2, this.Size.Height / 2 - 35);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Test
            e.Graphics.FillRectangle(Brushes.Gray, new Rectangle(racket1.x, racket1.y, racket1.width, racket1.height));
            e.Graphics.FillRectangle(Brushes.Gray, new Rectangle(racket2.x, racket2.y, racket1.width, racket1.height));
            e.Graphics.FillEllipse(Brushes.White, new RectangleF(ball.x, ball.y, 15, 15));
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            const int MOVEMENT = 10;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    racket1.y -= MOVEMENT;
                    break;
                case Keys.Down:
                    racket1.y += MOVEMENT;
                    break;
                case Keys.W:
                    racket2.y -= MOVEMENT;
                    break;
                case Keys.S:
                    racket2.y += MOVEMENT;
                    break;
            }
            Invalidate();
        }
    }
}
