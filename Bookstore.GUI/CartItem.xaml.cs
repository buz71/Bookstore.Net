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

namespace Bookstore.GUI
{
    /// <summary>
    /// Interaction logic for Border_CartItem.xaml
    /// </summary>
    public partial class CartItem : UserControl
    {
        public bool IsChecked { get; set; }
        public long Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public int CartQuantity { get; set; }
        public int Quantity { get; set; }
        public int Action { get; set; }
        public int Tag { get; set; }

        public CartItem(BookItem bookItem)
        {
            InitializeComponent();
            IsChecked = false;
            Id = bookItem.Id;
            BookName = bookItem.BookName;
            Author = bookItem.Author;
            Year = bookItem.Year;
            Price = bookItem.Price;
            CartQuantity = 1;
            Quantity = bookItem.Quantity;
            Action = bookItem.Action;
            Tag = bookItem.Tag;
            Field_Author.Text = Author;
            Field_Book.Text =BookName;
            Field_Price.Text = Price.ToString();
            Field_Quntity.Text = CartQuantity.ToString();
            Field_Total.Text = Price.ToString();
        }

        public CartItem(long id, string bookName, string author, int year, double price, int quantity, int action, int tag)
        {
            //TODO: Добавить порядковый номер в корзине
            InitializeComponent();
            IsChecked = false;
            Id = id;
            BookName = bookName;
            Author = author;
            Year = year;
            Price = price;
            CartQuantity = 1;
            Quantity = quantity;
            Action = action;
            Tag = tag;
            Field_Author.Text = author;
            Field_Book.Text=bookName;
            Field_Price.Text = price.ToString();
            Field_Quntity.Text = CartQuantity.ToString();
            Field_Total.Text = price.ToString();
        }

        public CartItem()
        {
            InitializeComponent();
        }

        private void Border_CartItem_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton==MouseButton.Left)
            {
                if (IsChecked==false)
                {
                    Border_CartItem.BorderBrush = new SolidColorBrush(Colors.Red);
                    IsChecked = true;
                }
                else
                {
                    Border_CartItem.BorderBrush = new SolidColorBrush(Color.FromArgb(255,0,64,64));
                    IsChecked = false;
                }
            }
        }
    }
}
