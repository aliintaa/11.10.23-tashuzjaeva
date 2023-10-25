using System;
using System.Collections.Generic;
using System.IO;
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

namespace alinamagazinteh.Entities
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private Product service;
        public UserControl1(Product _service)
        {
            InitializeComponent();
            service = _service;
            photo.Source = GetImageSourse(service.MainImage);
            NameTB.Text = service.Title;
            othovTb.Text = service.AVGFeddbk.ToString();
            chenaTb.Text = service.Cost.ToString();
            chenaTb.Visibility = service.CostVisibility;
            chenaTB.Text = service.CostWithDiscount;
            KolvoOtzv.Text = service.VanushieOtzv;
        }
        private BitmapImage GetImageSourse(byte[] byteImage)
        {
            BitmapImage bitmapImage = new BitmapImage();
            try
            {
                if (service.MainImage != null)
                {
                    MemoryStream byteStream = new MemoryStream(byteImage);
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = byteStream;
                    bitmapImage.EndInit();
                }
                else
                {
                    bitmapImage = new BitmapImage(new Uri(@"\pages\teh.jpg", UriKind.Relative));
                }

            }

            catch
            {
                MessageBox.Show("Error");
            }
            return bitmapImage;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (service != null)
            {
                MessageBox.Show("Удаление запрещенно");
            }
            else
            {
                App.db.Product.Remove(service);
                App.db.SaveChanges();
                //    }

                //}

                //private void CreateBtn_Click(object sender, RoutedEventArgs e)
                //{

                //     Entities.PartialClass.Navigation.NextPage(new PageComponent(new pages.AddReadactPage(service), "Редактировать"));

            }
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Red");
        }
    }
}
    
