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
        public MainPage MainPage;
        public static Cart Window;

        /// <summary>
        /// Метод оформления заказа
        /// </summary>
        public void CreateOrder()
        {
            // 1.Сначала создаем список из элементов в StackPanel
            List<CartItem> cartItems = new List<CartItem>();
            foreach (var item in StackPanel_Basket.Children)
            {
                cartItems.Add(item as CartItem);
            }
            double orderSum = 0;
            string orderString = "Ваш заказ:";

            //2. Формируем сообщение заказа
            foreach (var item in cartItems)
            {
                orderString += $"\nКнига:{item.bookName}| Автор: {item.Author} | Количество: {item.Quantity} | Цена: {item.Price}";
                orderSum += item.Price;
            }
            orderString += $"\n Сумма Вашего заказа: {orderSum}";
            MainPage.smtp.SendMessage("Заказ BookStore.NET", orderString);
            Logger.WriteLog(MainPage.Account.Name,"Оформлен заказ");
        }

        public Cart()
        {
            InitializeComponent();
            Window = this;
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
                CreateOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}