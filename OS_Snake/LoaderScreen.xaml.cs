using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OS_Snake
{
    /// <summary>
    /// Interaction logic for LoaderScreen.xaml
    /// </summary>
    public partial class LoaderScreen : Window
    {
        public LoaderScreen()
        {
            InitializeComponent();
        }

        Thread LoaderTH;
        private void Window_Loaded(object sender, RoutedEventArgs e) {

            classes.Loader.LoaderScreen.LoadControl();
            THStart = true;
            LoaderTH = new Thread(LoaderTH_Void);
            LoaderTH.Start();

        }

        private bool THStart = false;
        private void LoaderTH_Void() {

            while (THStart) {

                Thread.Sleep(500);
                this.Dispatcher.BeginInvoke(new Action(() => {

                    Loader.Value += classes.Loader.LoaderScreen.LoadingValue;
                    if (Loader.Value == Loader.Maximum) {
                        THStart = false;
                        LoaderTH.Abort();
                        MainPage MP = new MainPage();
                        MP.Show();
                        Hide();

                    }

                }));

            }


        }

    }
}
