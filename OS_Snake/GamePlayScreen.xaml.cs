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
using OS_Snake.classes;
using OS_Snake.classes.Coordinate;
using OS_Snake.classes.Food;
using OS_Snake.classes.Move;
using OS_Snake.classes.Point;
using OS_Snake.classes.Barrier.Tail;
using OS_Snake.classes.Tail;
using OS_Snake.classes.Level;

namespace OS_Snake {
    /// <summary>
    /// Interaction logic for GamePlayScreen.xaml
    /// </summary>
    public partial class GamePlayScreen : Window {
        public GamePlayScreen() {
            InitializeComponent();
        }

        Coord headCoord = new Coord(0,8);
        Coord foodCoord = new Coord(0,0);
        private static List<Coord> TailsCoord = new List<Coord>();
        private static short Tail_Long = 0;

       private static void TailAdd(Canvas Name, double X, double Y) {
            // Add Tail Code
            AddTail.Add(Name);
            Coord TailCoord = new Coord(X, Y);
            TailsCoord.Add(TailCoord);
            Canvas.SetLeft(AddTail.Ellipses[Tail_Long - 1], TailCoord.CanvasX);
            Canvas.SetTop(AddTail.Ellipses[Tail_Long - 1], TailCoord.CanvasY);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            BestPointerText.Text ="Skor: "+Properties.Settings.Default.Best_Point;
            Foods.Send();
            foodCoord = new Coord(Foods.X, Foods.Y);
            Canvas.SetTop(foodImage, foodCoord.CanvasY);
            Canvas.SetLeft(foodImage, foodCoord.CanvasX);
            Canvas.SetLeft(headEllipse, headCoord.CanvasX);
            Canvas.SetTop(headEllipse, headCoord.CanvasY);

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {

            if (OneStart) {

                Game_Rest_ShutD(false);

            }
                MainPage MP = new MainPage();
                MP.Show();

        }

        private short TailNumber = -1;
       private double OldX { get; set; }
       private double OldY { get; set; }
       public static Thread GoMove;
        private void Head_Move() {

            while (OneStart) {
                Thread.Sleep(Levels.MoveSpeed);
                this.Dispatcher.BeginInvoke(new Action(() => {
                //Move Direction X
                if (Move_Control.Direction == Move_Control.Direct_X) {

                        TailControl.oldX = headCoord.X;
                        TailControl.oldY = headCoord.Y;
                        headCoord.X += Move_Control.Move_Point;
                        Canvas.SetLeft(headEllipse, headCoord.CanvasX);

                }
                //Move Direction Y
                else if (Move_Control.Direction == Move_Control.Direct_Y) {
                        TailControl.oldX = headCoord.X;
                        TailControl.oldY = headCoord.Y;
                        headCoord.Y += Move_Control.Move_Point;
                        Canvas.SetTop(headEllipse, headCoord.CanvasY);

                    }
                    // Tail Move
                    if (Tail_Long > 0) {

                        TailNumber = 0;

                    }
                    while (Tail_Long > 0 && TailNumber >= 0) {

                        this.OldX = TailsCoord[TailNumber].X;
                        this.OldY = TailsCoord[TailNumber].Y;
                        TailControl.Control(TailsCoord[TailNumber], TailNumber);
                        TailControl.oldX = this.OldX;
                        TailControl.oldY = this.OldY;

                        if (TailNumber >= TailsCoord.Count - 1) {

                            TailNumber = -1;

                        } else {

                            TailNumber++;

                        }

                    }
                    // Barrier Control R = restart , C = close
                    for (int i = 0; i < TailsCoord.Count; i++) {

                    TailBarrier.Look(headCoord.X, headCoord.Y, TailsCoord[i].X, TailsCoord[i].Y);
                        switch (TailBarrier.GameStart_Control) {

                            case 'R':
                                Game_Rest_ShutD(true);
                                break;

                            case 'C':
                                Game_Rest_ShutD(false);
                                Close();
                                break;

                        }

                    }

                    // if Eaten Food 
                    Scoring.Add(headCoord.X, headCoord.Y);
                    if (Scoring.Eat) {

                        scorePointer.Text = "Puan: " + Scoring.Point.ToString();
                        foodCoord = new Coord(Foods.X, Foods.Y);
                        Canvas.SetTop(foodImage, foodCoord.CanvasY);
                        Canvas.SetLeft(foodImage, foodCoord.CanvasX);

                        if (Tail_Long == 0) {

                            TailNumber = 0;
                            Tail_Long++;

                        } else {

                            Tail_Long++;

                        }

                        TailAdd(GameMap, TailControl.oldX, TailControl.oldY);

                    }
                // Return Coord
                    if (headCoord.X >= 26) {

                        headCoord.X = -1;

                    } else if (headCoord.X <= -1) {

                        headCoord.X = 26;

                    }

                    if (headCoord.Y >= 19) {

                        headCoord.Y = -1;

                    } else if (headCoord.Y <= -1) {

                        headCoord.Y = 19;

                    }

                }));
            }

        }

        private bool GoMoveActive = false;
        private bool OneStart = false;
        bool TextVisible = false;
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e) {
            // Starter Text Visibility
            // Start Move and Move Control
            GoMoveActive = true;
            switch (e.Key) {

                case Key.W:
                    Move_Control.Go('W');
                    break;
                case Key.S:
                    Move_Control.Go('S');
                    break;
                case Key.A:
                    Move_Control.Go('A');
                    break;
                case Key.D:
                    Move_Control.Go('D');
                    break;
                default:
                    GoMoveActive = false;
                    break;

            }
            // Image Turn
            Image_Turn();
            // Start Thread Move
            if (GoMoveActive) {
                if (OneStart) {
                    ;
                } else {

            if (TextVisible != true) {
                TextVisible = true;
                StartText.Visibility = Visibility.Hidden;
                        BestPointerText.Visibility = Visibility.Hidden;
            }
                    GoMove = new Thread(Head_Move);
                    GoMove.Start();
                    OneStart = true;

                }
            }

        }

        RotateTransform Direction_Image;
        private void Image_Turn() {
            if (Move_Control.Direction == Move_Control.Direct_X) {

                switch (Move_Control.Move_Point) {

                    case -1:
                        Direction_Image = new RotateTransform(180);
                        break;
                    case 1:
                        Direction_Image = new RotateTransform(360);
                        break;
                }

            } else if (Move_Control.Direction == Move_Control.Direct_Y) {

                switch (Move_Control.Move_Point) {

                    case -1:
                        Direction_Image = new RotateTransform(270);
                        break;
                    case 1:
                        Direction_Image = new RotateTransform(90);
                        break;
                }

            }
            headEllipse.RenderTransform = Direction_Image;

        }

        private void Game_Rest_ShutD(bool Event) {

            switch (Event) {
                case true:
                    // Restart
                    GoMove.Abort();
                    for (int i = 0; i < TailsCoord.Count; i++) {

                        GameMap.Children.Remove(AddTail.Ellipses[i]);

                    }
                    AddTail.Ellipses.Clear();
                    TailsCoord.Clear();
                    Scoring.Point = 0;
                    scorePointer.Text = "Puan: " + Scoring.Point.ToString();
                    TailNumber = -1;
                    Tail_Long = 0;
                    GoMoveActive = false;
                    OneStart = false;
                    TextVisible = false;
                    StartText.Visibility = Visibility.Visible;
                    BestPointerText.Text = "Skor: " + Properties.Settings.Default.Best_Point;
                    BestPointerText.Visibility = Visibility.Visible;
                    headCoord = new Coord(0, 8);
                    Foods.Send();
                    foodCoord = new Coord(Foods.X, Foods.Y);
                    Canvas.SetTop(foodImage, foodCoord.CanvasY);
                    Canvas.SetLeft(foodImage, foodCoord.CanvasX);
                    Canvas.SetLeft(headEllipse, headCoord.CanvasX);
                    Canvas.SetTop(headEllipse, headCoord.CanvasY);
                    Direction_Image = new RotateTransform(360);
                    headEllipse.RenderTransform = Direction_Image;
                    TailBarrier.GameStart_Control = 'F'; //F: free
                    break;

                case false:
                    GoMove.Abort();
                    for (int i = 0; i < TailsCoord.Count; i++) {

                        GameMap.Children.Remove(AddTail.Ellipses[i]);

                    }
                    AddTail.Ellipses.Clear();
                    TailsCoord.Clear();
                    Scoring.Point = 0;
                    scorePointer.Text = "Puan: " + Scoring.Point.ToString();
                    TailNumber = -1;
                    Tail_Long = 0;
                    GoMoveActive = false;
                    OneStart = false;
                    TextVisible = false;
                    headCoord = new Coord(0, 8);
                    Foods.Send();
                    foodCoord = new Coord(Foods.X, Foods.Y);
                    Canvas.SetTop(foodImage, foodCoord.CanvasY);
                    Canvas.SetLeft(foodImage, foodCoord.CanvasX);
                    Canvas.SetLeft(headEllipse, headCoord.CanvasX);
                    Canvas.SetTop(headEllipse, headCoord.CanvasY);
                    Direction_Image = new RotateTransform(360);
                    headEllipse.RenderTransform = Direction_Image;
                    TailBarrier.GameStart_Control = 'F'; //F: free
                    break;

            }

        } 


    }
}
// Kafa kısımı kuyruga veya herhangi bir engele çarparsa GAME OVER olacak