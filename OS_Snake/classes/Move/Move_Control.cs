using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Snake.classes.Move {
    class Move_Control {

        public static char Direct_X = 'X';
        public static char Direct_Y = 'Y';
        private static bool oneStart = false;
        private static void Move(char Key) {

            switch (Key) {

                case 'W':
                    Move_Point = -1;
                    Direction = Direct_Y;
                    break;
                case 'S':
                    Move_Point = 1;
                    Direction = Direct_Y;
                    break;
                case 'A':
                    Move_Point = -1;
                    Direction = Direct_X;
                    break;
                case 'D':
                    Move_Point = 1;
                    Direction = Direct_X;
                    break;

            }
            // Old values control
            if (Direction == oldDirection && oneStart != false) {
                Move_Point = oldMove_Point;
            } else {
                oldMove_Point = Move_Point;
            }
            oneStart = true;
            oldDirection = Direction;
            


        }
        public static sbyte Move_Point { get; set; }
        public static char Direction { get; set; }
        private static char oldDirection { get; set; }
        private static sbyte oldMove_Point { get; set; }

        public static void Go(char Key) {

            Move(Key);

        }


    }
}
