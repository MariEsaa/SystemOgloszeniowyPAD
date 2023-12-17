using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using SystemOgloszeniowyPAD.Classes;

namespace SystemOgloszeniowyPAD
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static User LoggedUser;
        App()
        {
            this.InitializeComponent();
            DataBase.Connection();
        }
    }
}
