using alinamagazinteh.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using alinamagazinteh.Entities.PartialClass;
using System.Windows.Controls;
using alinamagazinteh.pages;

namespace alinamagazinteh
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static magazintehnikiEntities2 db = new magazintehnikiEntities2();
        public static bool isAdmin = false;
        public static MainWindow mainWindow;
        public static pages.AddReadact servicePage;
        public static WrapPanel KorzinaWp;
        public static Page1 ProdListPage;
    }
}
