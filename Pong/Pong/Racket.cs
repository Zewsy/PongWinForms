using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Racket
    {
        public double x { get; set; }  //center x
        public double y { get; set; }  //center y
        public int width { get; set; } = 5;
        public int height { get; set; } = 50;
        private const double MAXANGLE = 5 * Math.PI / 12;

        public Racket(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void hitBall(Ball ball)
        {
            var relIntersectY = y - ball.y;
            var normalizedIntersectY = relIntersectY / (height / 2);

            ball.bounceAngle = normalizedIntersectY * MAXANGLE;
            ball.vx = Ball.SPEED_CONST * Math.Cos(ball.bounceAngle);
            ball.vy = Ball.SPEED_CONST * Math.Sin(ball.bounceAngle);
        }
    }
}
