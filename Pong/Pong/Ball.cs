using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Ball
    {
        public int x { get; set; }
        public int y { get; set; }

        public Ball(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
