using alinamagazinteh.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace alinamagazinteh
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static magazintehnikiEntities1 db = new magazintehnikiEntities1();
        public static bool isAdmin = false;
    }
}
