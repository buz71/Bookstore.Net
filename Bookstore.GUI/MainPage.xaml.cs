using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Bookstore.MControl;
using Bookstrore.MControl.Model;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bookstore.GUI
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        #region Fields
        private static MainPage Window;
        private BookstoreDb _db;
        private Account _account;

        /// <summary>
        /// Переменная для хранения экземпляра корзины
        /// </summary>
        public Cart basket;
        public SMTP smtp;
        
        #endregion
        #region Properties
        public BookstoreDb Db
        {
            get { return _db; }
            set { _db = value; }
        }

        public Account Account
        {
            get { return _account; }
            set { _account = value; }
        }
        #endregion
        #region Methods

        // метод позволяет двигать окно мышкой
        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MainPage.Window.DragMove();
            }
        }

        //метод позволяет закрыть окно "крестиком"
        private void Window_Main_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Метод добавления товаров в корзину
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Book_Cart(object sender, RoutedEventArgs e)
        {
            List<BookItem> bookItems = new List<BookItem>();
            foreach (var item in panel.Children)
            {
                bookItems.Add(item as BookItem);
            }
            foreach (var item in bookItems)
            {
                if (item.IsChecked==true)
                {
                    item.IsChecked = false;
                    item.Border_BookItem.BorderBrush=new SolidColorBrush(Colors.Black);
                    CartItem cartItem =new CartItem(item.Name,item.Author,item.Year,item.Price,item.Quantity,item.Action,item.Tag);
                    basket.StackPanel_Basket.Children.Add(cartItem);
                }
            }

        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        /// <summary>
        /// Метод для изменения внешнего вида кнопки при выделении
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as BookItem).IsChecked==false)
            {
                (sender as BookItem).Border_BookItem.BorderBrush=new SolidColorBrush(Colors.Red);
                (sender as BookItem).IsChecked=true;
            }
            else
            {
                (sender as BookItem).Border_BookItem.BorderBrush = new SolidColorBrush(Colors.Black);
                (sender as BookItem).IsChecked = false;
            }
        }

        #endregion
        #region StylesMethods
        private void Button_catalog(object sender, RoutedEventArgs e)
        {

        }
        private void Button_cart(object sender, RoutedEventArgs e)
        {
            basket.ShowDialog();
        }
        private void Button_persona(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        public MainPage()
        {
            InitializeComponent();
            Window = this;
        }



    }
}
