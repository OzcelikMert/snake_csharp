using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OS_Snake.classes.Level;

namespace OS_Snake {
    /// <summary>
    /// Interaction logic for SpeedLevelScreen.xaml
    /// </summary>
    public partial class SpeedLevelScreen : Window {
        public SpeedLevelScreen() {
            InitializeComponent();
        }

        private void EasySelect_Checked(object sender, RoutedEventArgs e) {

            MessageLevel("Kolay", 0, EasySelect);

        }

        private void NormalSelect_Checked(object sender, RoutedEventArgs e) {

            MessageLevel("Normal", 1, NormalSelect);

        }

        private void HardSelect_Checked(object sender, RoutedEventArgs e) {

            MessageLevel("Zor", 2, HardSelect);

        }

        private void Hard2Select_Checked(object sender, RoutedEventArgs e) {

            MessageLevel("Çok Zor", 3, Hard2Select);

        }

        private void LegendarySelect_Checked(object sender, RoutedEventArgs e) {

            MessageLevel("Efsanevi", 4, LegendarySelect);

        }

        private void ImpossibleSelect_Checked(object sender, RoutedEventArgs e) {

            MessageLevel("İmkansız", 5, ImpossibleSelect);

        }

        private void CloseIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {

            Levels.CloseWindow = false;
            Close();

        }


        private void MessageLevel(string LevelName, byte LevelValue, RadioButton RBName) {

           MessageBoxResult MessageQuestion = MessageBox.Show("\""+LevelName+"\" Oyun modunu seçtiniz.\rOynamak istediğinize emin misiniz?","Mod Seçim Mesajı", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (MessageQuestion) {

                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.No:
                    RBName.IsChecked = false;
                    break;
                case MessageBoxResult.Yes:
                    Levels.SpeedControl(LevelValue);
                    Levels.CloseWindow = true;
                    MainPage.Exit = false;
                    Close();
                    break;

            }

        }

    }
}
