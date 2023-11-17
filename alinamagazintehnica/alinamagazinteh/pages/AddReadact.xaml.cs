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
using alinamagazinteh.Entities.PartialClass;

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
            App.servicePage = this;
            RefreshPhoto();
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
        {
            StringBuilder errors = new StringBuilder();
            if (service.Id == 0)
            {
                App.db.Product.Add(service);
            }
            App.db.Product.AddOrUpdate(service);
            App.db.SaveChanges();
            alinamagazinteh.Entities.PartialClass.Navigation.NextPage(new Entities.PartialClass.Navigation.PageComponent(new Catalog(), "Список админов"));

        }
        private void CostTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(char.IsDigit(e.Text[0])))
            {
                e.Handled = true;
            }
        }

        private void AddImageBtn_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
                App.db.ProductPhoto.Add(new ProductPhoto
                {
                    Id_p = service.Id,
                    PhotoByte = File.ReadAllBytes(openFile.FileName)

                });
            RefreshPhoto();
            InitializeComponent();

            App.db.SaveChanges();
        }
        public void RefreshPhoto()
        {
            PhotoWp.Children.Clear();
            foreach (var photo in App.db.ProductPhoto.Where(x => x.Id_p == service.Id))
            {
                PhotoWp.Children.Add(new PhotoUserControl(photo));
            }
            BitmapImage bitmapImage = new BitmapImage();
            MemoryStream byteStream = new MemoryStream(service.MainImage);
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = byteStream;
            bitmapImage.EndInit();
            Image.Source = bitmapImage;
        }
    }
}
