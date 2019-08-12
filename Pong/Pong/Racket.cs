using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Racket
    {
        public double x { get; set; }  //upper-left corner x
        public double y { get; set; }  //upper-left corner y
        public int width { get; set; }
        public int height { get; set; }
        private const double MAXANGLE = 5 * Math.PI / 12;

        public Racket(double _x, double _y, int _width = 5, int _height = 50)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
        }

        public void hitBall(Ball ball, bool horizontal)
        {
            if (!horizontal)
            {
                var relIntersectY = (y + height / 2) - ball.y;
                var normalizedIntersectY = relIntersectY / (height / 2);
                ball.bounceAngle = normalizedIntersectY * MAXANGLE;
            }
            else
            {
                var relIntersectX = (x + width / 2) - ball.x;
                var normalizedIntersectX = relIntersectX / (width / 2);
                ball.bounceAngle = normalizedIntersectX * MAXANGLE;
            }
            ball.vx = Ball.SPEED_CONST * Math.Cos(ball.bounceAngle);
            ball.vy = Ball.SPEED_CONST * Math.Sin(ball.bounceAngle);
        }

        public bool checkCollosion(Ball ball)
        {
            if (ball.y >= y && ball.y <= y + height)
            {
                hitBall(ball, false);
                return true;
            }
            else
                return false;
        }
    }
}
