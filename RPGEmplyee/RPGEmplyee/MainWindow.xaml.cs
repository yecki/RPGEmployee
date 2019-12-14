using System;
using System.Media;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RPGEmployee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public String gameState = "Menu";

        SoundPlayer menuBlip = new SoundPlayer(RPGEmployee.Properties.Resources.MenuBlip);
        double[] characterDistanceToTheBorders = { 3, 2, 3, 2};
        double movementSpeed = 2d;
        Boolean charAnim = false;

        long time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        

        public MainWindow()
        {
            InitializeComponent();

        }

        public void SwitchGameState(String newGamestate)
        {
            if (newGamestate.Equals("Menu"))
            {
                GameBackground.Visibility = SetVisibility(false);
                Character.Visibility = SetVisibility(false);
                CharacterAnim.Visibility = SetVisibility(false);
                Crate.Visibility = SetVisibility(false);
                Customer.Visibility = SetVisibility(false);

                MenuBackground.Visibility = SetVisibility(true);
                StartGame.Visibility = SetVisibility(true);
                StartGameText.Visibility = SetVisibility(true);
                SettingBut.Visibility = SetVisibility(true);
                SettingText.Visibility = SetVisibility(true);
                CloseBut.Visibility = SetVisibility(true);
                CloseText.Visibility = SetVisibility(true);
                gameState = "Menu";
            } else if (newGamestate.Equals("Game"))
            {
                GameBackground.Visibility = SetVisibility(true);
                Character.Visibility = SetVisibility(!charAnim);
                CharacterAnim.Visibility = SetVisibility(charAnim);
                Crate.Visibility = SetVisibility(true);
                Customer.Visibility = SetVisibility(true);

                MenuBackground.Visibility = SetVisibility(false);
                StartGame.Visibility = SetVisibility(false);
                StartGameHighlight.Visibility = SetVisibility(false);
                StartGameText.Visibility = SetVisibility(false);
                SettingBut.Visibility = SetVisibility(false);
                SettingText.Visibility = SetVisibility(false);
                CloseBut.Visibility = SetVisibility(false);
                CloseText.Visibility = SetVisibility(false);
                gameState = "Game";
            }
        }

        public System.Windows.Visibility SetVisibility(Boolean isNowVisible)
        {
            if (isNowVisible) return System.Windows.Visibility.Visible;
            else return System.Windows.Visibility.Hidden;
        }

        public void MoveImage(Image[] toMove, int speedRight, int speedDown)
        { if ((speedRight <= 1 || speedRight >= -1) && (speedDown <= 1 || speedDown >= -1)){

                foreach (Image pic in toMove)
                {
                    double left = pic.Margin.Left + (movementSpeed * speedRight);
                    double up = pic.Margin.Top + (movementSpeed * speedDown);
                    double right = pic.Margin.Right - (movementSpeed * speedRight);
                    double down = pic.Margin.Bottom - (movementSpeed * speedDown);

                    pic.Margin = new Thickness(left, up, right, down);
                    if (pic.Visibility.Equals(System.Windows.Visibility.Visible))
                    {
                        pic.Visibility = SetVisibility(false);
                    } else
                    {
                        pic.Visibility = SetVisibility(true);
                    }
                }
            }
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            switch (gameState)
            {
                case "Menu":
                    {
                        if (e.Source.Equals(StartGameText))
                        {
                            StartGameHighlight.Visibility = System.Windows.Visibility.Visible;
                            menuBlip.Play();
                        }

                        // if (e.Source.Equals(SettingText)) SettingHighlight.Visibility = System.Windows.Visibility.Visible;
                        if (e.Source.Equals(CloseText))
                        {
                            CloseHighlight.Visibility = System.Windows.Visibility.Visible;
                            menuBlip.Play();
                        }

                    }
                    break;

                case "Game": { } break;

            }






        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            switch (gameState)
            {
                case "Menu":
                    {
                        if (e.Source.Equals(StartGameText)) StartGameHighlight.Visibility = System.Windows.Visibility.Hidden;
                        //   if (e.Source.Equals(SettingText)) SettingHighlight.Visibility = System.Windows.Visibility.Hidden;
                        if (e.Source.Equals(CloseText)) CloseHighlight.Visibility = System.Windows.Visibility.Hidden;
                    }
                    break;

                case "Game": { } break;

            }


        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            switch (gameState)
            {
                case "Menu":
                    {
                        if (e.Source.Equals(CloseText)) Close();
                        if (e.Source.Equals(StartGameText))
                        {

                            SwitchGameState("Game");
                        }
                    }
                    break;

                case "Game": { } break;

            }


        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (gameState)
            {
                case "Menu":
                    {
                        if (e.Key.Equals(Key.Escape)) Close();
                    }
                    break;

                case "Game":
                    {
                        switch (e.Key)
                        {
                            case Key.A:
                                {
                                    Image[] player = { Character, CharacterAnim };
                                    MoveImage(player,-1,0);
                                }
                                break;
                            case Key.D:
                                {
                                    Image[] player = { Character, CharacterAnim };
                                    MoveImage(player, 1, 0);
                                }
                                break;
                            case Key.W:
                                {
                                    Image[] player = { Character, CharacterAnim };
                                    MoveImage(player, 0, -1);
                                }
                                break;
                            case Key.S:
                                {
                                    Image[] player = { Character, CharacterAnim };
                                    MoveImage(player, 0, 1);
                                }
                                break;
                        }
                        
                    }
                    break;

            }
            
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (gameState)
            {
                case "Menu":
                    {
                        if (e.Key.Equals(Key.Escape)) Close();
                    }
                    break;

                case "Game":
                    {
                        if (e.Key.Equals(Key.Escape)) SwitchGameState("Menu");
                    }
                    break;

            }
            

        }

    }
}

