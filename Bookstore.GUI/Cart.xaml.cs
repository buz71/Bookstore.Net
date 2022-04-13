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
using System.Windows.Shapes;

namespace Bookstore.GUI
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
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
            Application.Current.Shutdown();
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