using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Snake.classes.Loader
{
    class LoaderScreen
    {

        public static byte LoadingValue { get; set; }
        public static void LoadControl() {

            Random LoadRandom = new Random();
           // int LoadingRandom_Value = LoadRandom.Next(0, 5);
            switch (LoadRandom.Next(0, 5)) {

                case 0: LoadingValue = 10;
                    break;

                case 1: LoadingValue = 20;
                    break;

                case 2: LoadingValue = 25;
                    break;

                case 3: LoadingValue = 35;
                    break;

                case 4: LoadingValue = 50;
                    break;

            }

        }

    }
}
