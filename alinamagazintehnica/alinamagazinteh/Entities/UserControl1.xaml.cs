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
        public UserControl1(Product service)
        {
            InitializeComponent();
            
            photo = _photo;
            NameTB.Text = _name;
            othovTb.Text = _otc.ToString();
            chenaTb.Text = chena.ToString();
            chenaTb.Visibility = chenaVisibility;
            chenaTB.Text = _chena;
            KolvoOtzv.Text= KolOtzv;
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
                    bitmapImage = new BitmapImage(new Uri(@"\pages\teh.jpg.png", UriKind.Relative));
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
            if (service.ClientService != null)
            {
                MessageBox.Show("Удаление запрещенно");
            }
            else
            {
                App.db.Service.Remove(service);
                App.db.SaveChanges();
            }

        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {

            Navigation.NextPage(new PageComponent(new pages.AddReadactPage(service), "Редактировать"));

        }
    }
}
}