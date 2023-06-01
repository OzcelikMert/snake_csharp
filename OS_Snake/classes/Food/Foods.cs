using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Snake.classes.Food {
    class Foods {

        static Random xy_Random = new Random();
        private static void FoodDefine() {

           X = Convert.ToInt32(xy_Random.Next(0,26));
           Y = Convert.ToInt32(xy_Random.Next(0,18));
        }

        public static void Send() {

            FoodDefine();

        }

        public static double X { get; set; }
        public static double Y { get; set; }


    }
}
