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

namespace alinamagazinteh.Entities.PartialClass
{
    /// <summary>
    /// Логика взаимодействия для PhotoUserControl.xaml
    /// </summary>
    public partial class PhotoUserControl : UserControl
    {
        ProductPhoto produtPhoto;
        public PhotoUserControl(ProductPhoto _produtPhoto)
        {
            InitializeComponent();
            produtPhoto = _produtPhoto;
            this.DataContext = productPhoto;
        }

        private void MainBtn_Click(object sender, RoutedEventArgs e)
        {
            var selPhoto = productPhoto.PhotoByte;
            productPhoto.PhotoByte = productPhoto.Service.MainImage;
            productPhoto.Service.MainImage = selPhoto;
            App.servicePage.RefreshPhoto();
            App.db.SaveChanges();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.ProductPhoto.Remove(productPhoto);
            App.db.SaveChanges();
            App.servicePage.RefreshPhoto();
        }
    }
}
