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
    /// Interaction logic for mainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        #region Fields
        private static MainPage Window;
        public BookstoreDb Db { get; set; }
        public Account Account { get; set; }
        /// <summary>
        /// Переменная для хранения экземпляра корзины
        /// </summary>
        public Cart basket;
        public SMTP smtp;

        public Persona persona;
        
        #endregion
        #region Properties

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
            Store.AddToBasket(this,basket);
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
            persona.ShowDialog();
        }
        #endregion

        public MainPage()
        {
            InitializeComponent();
            Window = this;
        }



    }
}
