using alinamagazinteh.Entities.PartialClass;
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
using static alinamagazinteh.Entities.PartialClass.Navigation;

namespace alinamagazinteh.Entities
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public Product product;

        public UserControl1(Product _product)
        {
            InitializeComponent();
            product = _product;
             if(App.isAdmin == false)
            {
                DeleteBtn.Visibility = Visibility.Collapsed;
                CreateBtn.Visibility = Visibility.Collapsed;
            }
            else
            {
                CreateBtn.Visibility = Visibility.Visible;
                DeleteBtn.Visibility = Visibility.Visible;
            }
            
            photo.Source = GetImageSourse(product.MainImage);
            NameTB.Text = product.Title;
            othovTb.Text = product.AVGFeddbk.ToString();
            chenaTb.Text = product.Cost.ToString();
            chenaTb.Visibility = product.CostVisibility;
            chenaTB.Text = product.CostWithDiscount;
            KolvoOtzv.Text = product.VanushieOtzv;
        }
        private BitmapImage GetImageSourse(byte[] byteImage)
        {
            BitmapImage bitmapImage = new BitmapImage();
            try
            {
                if (product.MainImage != null)
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
            if (product != null)
            {
                MessageBox.Show("Удаление запрещенно");
            }
            else
            {
                App.db.Product.Remove(product);
                App.db.SaveChanges();
            }

        }


        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent(new pages.AddReadact(product), "Редактировать"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(ProductZakazUc productZakazUc in App.KorzinaWp.Children)
            { 
                if(productZakazUc.product == product)
                {
                    productZakazUc.KolvoTb.Text = (productZakazUc.Kolvo + 1).ToString();
                    return;
                }

            }
            App.KorzinaWp.Children.Add(new ProductZakazUc(product));
            App.ProdListPage.CalculateItog();
                    
        }
    }
}
    
