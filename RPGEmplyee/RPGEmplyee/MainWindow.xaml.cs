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
        SoundPlayer step = new SoundPlayer("../../Sounds\\MenuBlip.wav");
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.Source.Equals(StartGameText)) StartGameHighlight.Visibility = System.Windows.Visibility.Visible; 
           // if (e.Source.Equals(SettingText)) SettingHighlight.Visibility = System.Windows.Visibility.Visible;
            if (e.Source.Equals(CloseText))
            {
                CloseHighlight.Visibility = System.Windows.Visibility.Visible;
            }
             
            System.Console.WriteLine(System.IO.Path.GetFullPath("../../Sounds\\step.wav"));
            
            step.Play();

        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.Source.Equals(StartGameText)) StartGameHighlight.Visibility = System.Windows.Visibility.Hidden;
         //   if (e.Source.Equals(SettingText)) SettingHighlight.Visibility = System.Windows.Visibility.Hidden;
            if (e.Source.Equals(CloseText)) CloseHighlight.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.Source.Equals(CloseText))
            {
                Close();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Escape)) Close();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
