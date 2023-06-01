using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OS_Snake.classes.Coordinate;

namespace OS_Snake.classes.Tail {
    class TailControl {


        public static double oldX { get; set; }
        public static double oldY { get; set; }
        public static void Control(Coord CoordName,int TailNumber) {

            CoordName.X = oldX;
            CoordName.Y = oldY;
            Canvas.SetLeft(AddTail.Ellipses[TailNumber], CoordName.CanvasX);
            Canvas.SetTop(AddTail.Ellipses[TailNumber], CoordName.CanvasY);

        }



    }
}
