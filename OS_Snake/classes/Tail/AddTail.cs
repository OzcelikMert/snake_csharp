using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OS_Snake.classes.Coordinate;

namespace OS_Snake.classes.Tail {
    class AddTail {

        public static List<Ellipse> Ellipses = new List<Ellipse>();
        private static void TailDefine(Canvas name) {

            Ellipse Tail = new Ellipse();
            Tail.Height = 25;
            Tail.Width = 25;
            Tail.StrokeThickness = 3;
            Tail.Fill = Brushes.Orange;
            Tail.Stroke = Brushes.Aqua;
            name.Children.Add(Tail);
            Ellipses.Add(Tail);

        }

        public static void Add(Canvas Name) {

            TailDefine(Name);

        }

    }
}
