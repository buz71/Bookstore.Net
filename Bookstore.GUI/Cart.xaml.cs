using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Bookstrore.MControl.Control;

namespace Bookstore.GUI
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        /// <summary>
        /// Переменная для хранения ссылки на окно, из которого мы получаем данные для корзины
        /// </summary>
        public MainPage mainPage;
        public static Cart Window;
        public double TotalSum { get; set; }

        public Cart()
        {
            InitializeComponent();
            TotalSum = 0;
            Window = this;
            AllowsTransparency = true;      //прозрачность фона windows
        }


        // метод позволяет двигать окно мышкой
        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Cart.Window.DragMove();
            }
        }

        //метод позволяет закрыть окно "крестиком"
        private void Window_Cart_Close(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        //удаление книги из корзины
        private void Delete_Book(object sender, RoutedEventArgs e)
        {
            List<CartItem> cartItems = new List<CartItem>();
            foreach (CartItem cartItem in StackPanel_Basket.Children)
            {
                if (cartItem.IsChecked==true)
                {
                    cartItems.Add(cartItem);
                }
            }

            foreach (CartItem cartItem in cartItems)
            {
                StackPanel_Basket.Children.Remove(cartItem);
            }

            Store.SetTotalSum(this);
        }

        /// <summary>
        /// Метод оформления заказа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Checkout_Book(object sender, RoutedEventArgs e)
        {
            try
            {
                Store.CreateOrder(mainPage,this);
                Store.SetTotalSum(this);
                MessageBox.Show("Ваш заказ успешно оформлен", "Оформление заказа", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}