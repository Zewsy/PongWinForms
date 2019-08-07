using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Racket
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; } = 5;
        public int height { get; set; } = 50;

        public Racket(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
