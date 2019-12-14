using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RPGEmployee
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindow mwd;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            mwd = new MainWindow
            {        
            Visibility = System.Windows.Visibility.Visible
            };
            
                ;

        }
      

    }
}
