using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OS_Snake.classes.Point;

namespace OS_Snake.classes.Barrier.Tail {
    class TailBarrier {

        public static char GameStart_Control { get; set; }
        public static void Look(double headX, double headY, double tailX, double tailY) {
            // R: restart , C: close
            if (headX == tailX && headY == tailY) {
                GamePlayScreen.GoMove.Abort();
                if (Scoring.Point > Convert.ToInt32(Properties.Settings.Default.Best_Point)) {

                    Properties.Settings.Default.Best_Point = Scoring.Point.ToString();
                    Properties.Settings.Default.Save();

                }
             MessageBoxResult Reply = MessageBox.Show("Kaybettin! Tekrar oynamak ister misin?","Oyun Bitti", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                switch (Reply) {

                    case MessageBoxResult.None:
                        GameStart_Control = 'C';
                        break;
                    case MessageBoxResult.Yes:
                        GameStart_Control = 'R';
                        break;
                    case MessageBoxResult.No:
                        GameStart_Control = 'C';
                        break;

                }

            }



        }



    }
}
