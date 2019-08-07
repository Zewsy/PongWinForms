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
        Timer timer;
        const int START_X = 20;
        const int MOVEMENT = 10;
        bool ballIsGoingToLeft = true;
        public Form1()
        {
            InitializeComponent();
            //Hard-coded locations for fix form size
            racket1 = new Racket(START_X, this.Size.Height / 2 - 50);
            racket2 = new Racket(this.Size.Width - START_X * 2, this.Size.Height / 2 - 50);
            ball = new Ball(this.Size.Width / 2, this.Size.Height / 2 - 35);
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 25;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (ballIsGoingToLeft)
            {
                if (ball.x <= racket1.x + racket1.width * 2)
                    ballIsGoingToLeft = false;
                ball.x -= 5;
            }
            else
            {
                if (ball.x >= racket2.x - racket2.width * 2)
                    ballIsGoingToLeft = true;
                ball.x += 5;
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(Brushes.Gray, new Rectangle(racket1.x, racket1.y, racket1.width, racket1.height));
            e.Graphics.FillRectangle(Brushes.Gray, new Rectangle(racket2.x, racket2.y, racket1.width, racket1.height));
            e.Graphics.FillEllipse(Brushes.White, new RectangleF(ball.x, ball.y, 15, 15));
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
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
