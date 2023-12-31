﻿using alinamagazinteh.Entities;
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

namespace alinamagazinteh.pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
     
    public partial class Page1 : Page
    { 
        public Zakaz_zakaz zakaz;
        public Page1()
        {
            InitializeComponent();
            App.ProdListPage = this;
            App.KorzinaWp = KorzinaWp;
            if (App.isAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
            }
            Refresh();
        }
        private void Refresh()
        {
            IEnumerable<Product> services = App.db.Product;
            if (SortCb.SelectedIndex != 0)
            {
                if (SortCb.SelectedIndex == 1)
                    services = services.OrderBy(x => x.TotalCost);
                else
                    services = services.OrderByDescending(x => x.TotalCost);
            }

            if (DiscountFilterCb.SelectedIndex != 0)
            {
                if (DiscountFilterCb.SelectedIndex == 1)
                {
                    services = services.Where(x => x.Discount < 5 | x.Discount == null);
                }
                else if (DiscountFilterCb.SelectedIndex == 2)
                {
                    services = services.Where(x => (int)x.Discount > 5 & (int)x.Discount < 15);
                }
                else if (DiscountFilterCb.SelectedIndex == 3)
                {
                    services = services.Where(x => (int)x.Discount > 15 & (int)x.Discount < 30);
                }
                else if (DiscountFilterCb.SelectedIndex == 4)
                {
                    services = services.Where(x => (int)x.Discount > 30 & (int)x.Discount < 70);
                }
                else if (DiscountFilterCb.SelectedIndex == 5)
                {
                    services = services.Where(x => (int)x.Discount > 70 & (int)x.Discount < 100);
                }
            }
            if (SearchTb.Text != null)
            {
                services = services.Where(x => x.Title.ToLower().Contains(SearchTb.Text.ToLower()) ||
                x.Description.ToLower().Contains(SearchTb.Text.ToLower()));
            }
            ServiceWp.Children.Clear();
            foreach (var service in services)
            {
                ServiceWp.Children.Add(new UserControl1(service));
            }
        }

        private void DiscountFilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }



        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }




        private void SortCb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }



        //private void AddBtn_Click(object sender, RoutedEventArgs e)
        //{

        //    Entities.PartialClass.Navigation.NextPage(new PageContent(new pages.Page1(new Product()), "Добавить услугу"));

        //}
        public void CalculateItog()
        {
            double itog = 0;
            foreach (ProductZakazUc ProdZakUC in KorzinaWp.Children)
            {
                itog += ProdZakUC.Summ;
            }
            ItogTb.Text = $"Итог: {itog}";
        }
        private void ClearZakaz()
        {
            zakaz = new Zakaz_zakaz();
            KorzinaWp.Children.Clear();
        }
        private bool CheckZakaz()
        {
            if (KorzinaWp.Children.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы 1 товар!");
                return false;
            }

            foreach (ProductZakazUc ProdZakUC in KorzinaWp.Children)
            {
                if (ProdZakUC.Kolvo == 0)
                {
                    MessageBox.Show("Введите количество для всех товаров!");
                    return false;
                }
            }
            return true;
        }
        private void ZakazBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckZakaz())
                return;

            zakaz.ZakazDate = DateTime.Now;
            zakaz = App.db.Zakaz_zakaz.Add(zakaz);

            Product_Zakaz prodZak;
            foreach (ProductZakazUc ProdZakUC in KorzinaWp.Children)
            {
                prodZak = new Product_Zakaz();
                prodZak.ZakazId = zakaz.Id;
                prodZak.ProductId = ProdZakUC.product.Id;
                prodZak.Kolvo_zakaz = ProdZakUC.Kolvo;
                App.db.Product_Zakaz.Add(prodZak);
            }
            App.db.SaveChanges();
            MessageBox.Show("Заказ успешно оформлен!");
            ClearZakaz();
        }
    }
}
    
