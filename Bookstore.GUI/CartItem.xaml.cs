﻿using System;
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
    /// Interaction logic for CartItem.xaml
    /// </summary>
    public partial class CartItem : UserControl
    {
        public string bookName { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Action { get; set; }
        public int Tag { get; set; }

        public CartItem(string name, string author, int year, double price, int quantity, int action, int tag)
        {
            bookName = name;
            Author = author;
            Year = year;
            Price = price;
            Quantity = quantity;
            Action = action;
            Tag = tag;
            InitializeComponent();
        }

        public CartItem()
        {
            InitializeComponent();
        }
    }
}