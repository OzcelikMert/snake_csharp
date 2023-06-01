using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Snake.classes.Coordinate {
    class Coord {

        private double x = 0;
        private double y = 0;
        public Coord(double x, double y) { this.x = x; this.y = y; }
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public double CanvasX { get { return x * 30; } }
        public double CanvasY { get { return y * 30; } }

    }
}
