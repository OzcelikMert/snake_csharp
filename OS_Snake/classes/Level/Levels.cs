using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OS_Snake.classes.Point;

namespace OS_Snake.classes.Level {
    class Levels {
       public static short MoveSpeed { get; set; }
       public static void SpeedControl(byte Speed_Level) {

            switch (Speed_Level) {

                case 0: MoveSpeed = 280; Scoring.ChangePoint(15); break;
                case 1: MoveSpeed = 180; Scoring.ChangePoint(10); break;
                case 2: MoveSpeed = 90; Scoring.ChangePoint(15); break;
                case 3: MoveSpeed = 60; Scoring.ChangePoint(20); break;
                case 4: MoveSpeed = 40; Scoring.ChangePoint(25); break;
                case 5: MoveSpeed = 20; Scoring.ChangePoint(35); break;

            }

        }


        // Hassle in Start Play Window
        public static bool CloseWindow { get; set; }

    }
}
