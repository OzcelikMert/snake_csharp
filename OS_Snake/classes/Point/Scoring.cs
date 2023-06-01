using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OS_Snake.classes;
using OS_Snake.classes.Food;

namespace OS_Snake.classes.Point {
    class Scoring {

        public static int Point  { get; set; }
        private static byte AddPoint { get; set; }
        public static bool Eat { get; set; }

        public static void Add(double X, double Y) {

            if (X == Foods.X && Y == Foods.Y) {

                Point += AddPoint;
                Foods.Send();
                Eat = true;

            } else {
                Eat = false;
            }


        }

        public static void ChangePoint(byte NewPoint) {

            AddPoint = NewPoint;

        }

    }
}
