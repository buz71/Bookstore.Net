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
using System.Windows.Shapes;

namespace Bookstore.GUI
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        //TODO: Добавить список для хранения ссылок на товары добавленные в корзину
        //TODO: Добавить метод проверки количества, доступного для заказа товара
        //TODO: Добавить метод для оформления заказа

        /// <summary>
        /// Переменная для хранения ссылки на окно, из которого мы получаем данные для корзины
        /// </summary>
        public MainPage MainPage;
        public static Cart Window;
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

        //Оформить заказ
        private void Checkout_Book(object sender, RoutedEventArgs e)
        {

        }
    }
}