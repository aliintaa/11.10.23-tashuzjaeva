using alinamagazinteh.Entities;
using Microsoft.Win32;
using System;
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
using System.IO;
using System.Data.Entity.Migrations;

namespace alinamagazinteh.pages
{
    /// <summary>
    /// Логика взаимодействия для AddReadact.xaml
    /// </summary>
    public partial class AddReadact : Page
    {
        private Product service;
        public AddReadact(Product _service)
        {
            InitializeComponent();
            service = _service;
            this.DataContext = service;
        }


     

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                service.MainImage = File.ReadAllBytes(openFile.FileName);
                Image.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

     

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        { if (service.Id == 0)
            {
                App.db.Product.Add(service);
            }
            App.db.Product.AddOrUpdate(service);
            App.db.SaveChanges();
            alinamagazinteh.Entities.PartialClass.Navigation.NextPage(new Entities.PartialClass.Navigation.PageComponent(new Catalog(), "Список админов"));

        }
    }
}
