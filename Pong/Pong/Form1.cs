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
        Racket upFrame, downFrame;
        Ball ball;
        Timer timer;
        const int START_X = 20;
        const int MOVEMENT = 10;
        public Form1()
        {
            InitializeComponent();
            //Hard-coded locations for fix form size
            racket1 = new Racket(START_X, this.Size.Height / 2 - 50);
            racket2 = new Racket(this.Size.Width - START_X * 2, this.Size.Height / 2 - 50);

            upFrame = new Racket(0, 0, this.Size.Width, 5);
            downFrame = new Racket(0, this.Size.Height, this.Size.Width, 5);

            ball = new Ball(this.Size.Width / 2, this.Size.Height / 2 - 35);
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 25;
            timer.Start();
        }

        private void endGame()
        {
            timer.Stop();
            MessageBox.Show("Game Over :(");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ball.Move();
            if (ball.x <= racket1.x + 0.01)
            {
                if (!racket1.checkCollosion(ball))
                    endGame();
            }
            else if(ball.x >= racket2.x - 0.01)
            {
                if (!racket2.checkCollosion(ball))
                    endGame();
            }
            else if (ball.y <= upFrame.y + 0.01)
                upFrame.hitBall(ball);
            else if (ball.y >= downFrame.y - 0.01)
                downFrame.hitBall(ball);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(Brushes.Gray, new RectangleF((float)(racket1.x), (float)racket1.y, racket1.width, racket1.height));
            e.Graphics.FillRectangle(Brushes.Gray, new RectangleF((float)racket2.x, (float)racket2.y, racket1.width, racket1.height));
            e.Graphics.FillEllipse(Brushes.White, new RectangleF((float)ball.x, (float)ball.y, 15, 15));
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
