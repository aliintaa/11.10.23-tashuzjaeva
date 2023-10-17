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

namespace alinamagazinteh.Entities
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1(Image _photo, string _name, decimal _otc, decimal chena, Visibility chenaVisibility, string _chena, string KolOtzv)
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
    }
}