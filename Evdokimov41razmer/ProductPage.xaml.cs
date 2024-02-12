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

namespace Evdokimov41razmer
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {

        List<Product> ProductList;
        public ProductPage(User user)
        {
            InitializeComponent();

           
            if (user != null)
            {
                FIOTB.Text = user.UserSurname + " " + user.UserName + " " + user.UserPatronymic + " ";
                switch (user.UserRole)
                {
                    case 1:
                        RoleTB.Text = "Администратор"; break;
                    case 2:
                        RoleTB.Text = "Клиент"; break;
                    case 3:
                        RoleTB.Text = "Менеджер"; break;
                }

            }
            else
            {
                FIOTB.Text = "Гость";
                RoleTB.Text = "Гость";
            }

            var currentProducts = Evdokimov41Entities.GetContext().Product.ToList();
            ProductListView.ItemsSource = currentProducts;
            
            ComboSort.SelectedIndex = 0;

            ProductList = currentProducts;
        }

        private void UpdateProducts()
        {
            var currentProducts = Evdokimov41Entities.GetContext().Product.ToList();
            int productCount = currentProducts.Count;

            currentProducts = currentProducts.Where(p => (p.ProductName.ToLower().Contains(TBoxSearch.Text.ToLower()))).ToList();
           
            if (RbuttonUp.IsChecked.Value)
            {
                currentProducts = currentProducts.OrderBy(p => p.ProductCost).ToList();
            }

            if (RbuttonDown.IsChecked.Value)
            {
                currentProducts = currentProducts.OrderByDescending(p => p.ProductCost).ToList();
            }

            if (ComboSort.SelectedIndex == 0)
                currentProducts = currentProducts.Where(p => (p.ProductDiscountCurrent >= 0 && p.ProductDiscountCurrent <= 100)).ToList();
            if (ComboSort.SelectedIndex == 1)
                currentProducts = currentProducts.Where(p => (p.ProductDiscountCurrent >= 0 && p.ProductDiscountCurrent < 10)).ToList();
            if (ComboSort.SelectedIndex == 2)
                currentProducts = currentProducts.Where(p => (p.ProductDiscountCurrent >= 10 && p.ProductDiscountCurrent < 15)).ToList();
            if (ComboSort.SelectedIndex == 3)
                currentProducts = currentProducts.Where(p => (p.ProductDiscountCurrent >= 15 && p.ProductDiscountCurrent < 100)).ToList();


            TBCount.Text = currentProducts.Count.ToString();
            TBALLRecords.Text = productCount.ToString();
            ProductListView.ItemsSource = currentProducts;
        }



       
      
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void RbuttonUp_Checked(object sender, RoutedEventArgs e)
        {
            UpdateProducts();
        }

        private void RbuttonDown_Checked(object sender, RoutedEventArgs e)
        {
            UpdateProducts();
        }
    }
}
