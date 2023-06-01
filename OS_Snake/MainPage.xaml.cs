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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window {
        public MainPage() {
            InitializeComponent();
        }

        private void OnePlayer_Game_Click(object sender, RoutedEventArgs e) {

            SpeedLevelScreen SLS = new SpeedLevelScreen();
            SLS.ShowDialog();
            if (Levels.CloseWindow) {

                GamePlayScreen GPS = new GamePlayScreen();
                GPS.Show();
                Close();

            }

        }

        private void MultiPlayer_Game_Click(object sender, RoutedEventArgs e) {

            MessageBox.Show("Bakımda...","Bakım Mesajı", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Settings_Click(object sender, RoutedEventArgs e) {

            MessageBox.Show("Bakımda...", "Bakım Mesajı", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        public static bool Exit = true;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {

            if (Exit) {

            Application.Current.Shutdown();

            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            Exit = true;

        }
    }
}
