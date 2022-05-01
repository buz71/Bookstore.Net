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
        public string BookName { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Action { get; set; }
        public int Tag { get; set; }

        public CartItem(string bookName, string author, int year, double price, int quantity, int action, int tag)
        {
            InitializeComponent();
            BookName = bookName;
            Author = author;
            Year = year;
            Price = price;
            Quantity = quantity;
            Action = action;
            Tag = tag;
            Field_Author.Text = author;
            Field_Book.Text=bookName;
            Field_Price.Text = price.ToString();
            Field_Quntity.Text = "1";
        }

        public CartItem()
        {
            InitializeComponent();
        }
    }
}
