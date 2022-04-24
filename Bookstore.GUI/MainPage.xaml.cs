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
        public void FillStore(WrapPanel panel)
        {
            var store = _db.Stores.ToList();
            foreach (var item in store)
            {
                BookItem bookItem = new BookItem(item.Product.Book.Name, item.Product.Book.Autor.Name,(int)item.Product.Year,item.Price,(int)item.Quantity,(int)item.ActionId,(int)item.TagId);
                panel.Children.Add(bookItem);
                //ToggleButton button = new ToggleButton();
                //Button button = new Button();
                //button.Style = (Style)Resources["Button_Book"];
                //string content = $"{item.Product.Book.Name}\n" +
                //                 $"{item.Product.Book.Autor.Name}\n";
                //button.Content = content;
                //button.Click += SelectButton_Click;
                //panel.Children.Add(button);
            }
        }
        //void UpdateStore(BookstoreDB db, WrapPanel panel)
        //{
        //    panel.Children.Clear();
        //    FillStore(db, panel);
        //} 

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
            List<ToggleButton> buttonList = new List<ToggleButton>();
            foreach (var item in panel.Children)
            {
                buttonList.Add(item as ToggleButton);
            }

            foreach (var item in buttonList)
            {
                if (item.IsChecked==true)
                {
                    item.IsChecked = false;
                    item.Style = (Style)Resources["Button_Book"];
                    ToggleButton basketItem = new ToggleButton();
                    basketItem.Content = item.Content;
                    basket.StackPanel_Basket.Children.Add(basketItem);
                }
            }

        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        //Метод для изменения внешнего вида кнопки при выделении
        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as ToggleButton).Style == (Style)Resources["Button_Book_Press"])
            {
                (sender as ToggleButton).Style = (Style)Resources["Button_Book"];
            }
            else
            {
                (sender as ToggleButton).Style = (Style)Resources["Button_Book_Press"];
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
