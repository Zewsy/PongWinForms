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

        public void hitBall(Ball ball)
        {
            var relIntersectY = y - ball.y;
            var normalizedIntersectY = relIntersectY / (height / 2);

            ball.bounceAngle = normalizedIntersectY * MAXANGLE;
            ball.vx = Ball.SPEED_CONST * Math.Cos(ball.bounceAngle);
            ball.vy = Ball.SPEED_CONST * Math.Sin(ball.bounceAngle);
        }

        public bool checkCollosion(Ball ball)
        {
            if (ball.y <= y + height / 2 && ball.y >= y - height / 2)
            {
                hitBall(ball);
                return true;
            }
            else
                return false;
        }
    }
}
