using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Bookstore.GUI
{
    /// <summary>
    /// Interaction logic for BookItem.xaml
    /// </summary>
    public partial class BookItem : UserControl
    {
        public bool IsChecked { get; set; }
        public string BookBookName { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Action { get; set; }
        public int Tag { get; set; }

        /// <summary>
        /// Метод для заполнения полей BookItem
        /// </summary>
        private void FillTextBox()
        {
            IsChecked = false;
            Field_Book.Text = BookBookName;
            Field_Author.Text = Author;
            Field_Price.Text = Price.ToString();
            Field_Quntity.Text = Quantity.ToString();
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param bookName="bookName"></param>
        /// <param bookName="author"></param>
        /// <param bookName="year"></param>
        /// <param bookName="price"></param>
        /// <param bookName="quantity"></param>
        /// <param bookName="action"></param>
        /// <param bookName="tag"></param>
        public BookItem(string bookName, string author, int year, double price, int quantity, int action, int tag)
        {
            InitializeComponent();
            BookBookName = bookName;
            Author = author;
            Year = year;
            Price = price;
            Quantity = quantity;
            Action = action;
            Tag = tag;
            FillTextBox();
        }

        public BookItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для выделения книги при нажатии
        /// </summary>
        /// <param bookName="sender"></param>
        /// <param bookName="e"></param>
        private void Border_BookItem_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (IsChecked == false)
                {
                    Border_BookItem.BorderBrush = new SolidColorBrush(Colors.Red);
                    IsChecked = true;
                }
                else
                {
                    Border_BookItem.BorderBrush = new SolidColorBrush(Colors.Black);
                    IsChecked = false;
                }
            }

        }
    }
}
