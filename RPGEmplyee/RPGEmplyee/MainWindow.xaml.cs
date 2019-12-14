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

        public MainWindow()
        {
            InitializeComponent();

        }

        public void SwitchGameState(String newGamestate)
        {
            if (newGamestate.Equals("Menu"))
            {
                GameBackground.Visibility = SetVisibility(false);
                MenuBackground.Visibility = SetVisibility(true);
                StartGame.Visibility = SetVisibility(true);
                StartGameText.Visibility = SetVisibility(true);
                SettingBut.Visibility = SetVisibility(true);
                SettingText.Visibility = SetVisibility(true);
                CloseBut.Visibility = SetVisibility(true);
                CloseText.Visibility = SetVisibility(true);
                gameState = "Menu";
            }else if (newGamestate.Equals("Game"))
            {
                GameBackground.Visibility = SetVisibility(true);
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
                        
                    }break;

                case "Game": { }break; 

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
        { }

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
                            if(e.Key.Equals(Key.Escape)) SwitchGameState("Menu");
                        }
                        break;

                }
            
        }
    }
}
