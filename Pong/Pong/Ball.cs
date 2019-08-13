using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Ball
    {
        //Center coordinates
        public double x { get; set; }
        public double y { get; set; }
        public bool goesLeft { get; set; } = true;

        //Velocities
        public double vy { get; set; } = 0;
        public double vx { get; set; } = 5;
        public double radius { get; set; } = 15;

        public const int SPEED_CONST = 3;

        public double bounceAngle { get; set; } = 0;

        public Ball(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void Move()
        {
            if (goesLeft)
                x -= vx;
            else
                x += vx;
            y += vy;
        }
    }
}
