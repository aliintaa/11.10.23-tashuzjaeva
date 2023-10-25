using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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


namespace alinamagazinteh
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var path = @"C:\Users\222126\Desktop\";
            foreach (var item in App.db.Product.ToArray())
            {
                var fullPath = path + item.Image.Trim();
                var imageByte = File.ReadAllBytes(fullPath);
                item.MainImage = imageByte;


                App.db.SaveChanges();
                Entities.PartialClass.Navigation.mainWindow = this;
                Entities.PartialClass.Navigation.NextPage(new Entities.PartialClass.Navigation.PageComponent(new pages.Page1(), "Список услуг"));
                frams.Navigate(new pages.Catalog());

            }
        }

        private void OnAdminBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (PasswordPb.Password == "0000")
            {
                App.isAdmin = true;
                Entities.PartialClass.Navigation.NextPage(new Entities.PartialClass.Navigation.PageComponent(new pages.Page1(), "Услуги админа"));
                PasswordPb.Clear();
                Entities.PartialClass.Navigation.ClearHistory();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Entities.PartialClass.Navigation.BackPage();
        }

        private void OffAdminBtn_Click_1(object sender, RoutedEventArgs e)
        {
            App.isAdmin = false;
            Entities.PartialClass.Navigation.NextPage(new Entities.PartialClass.Navigation.PageComponent(new pages.Page1(), "Список услуг"));
            Entities.PartialClass.Navigation.ClearHistory();
        }
    }


}
