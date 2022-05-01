using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Bookstore.MControl;

namespace Bookstore.GUI
{
    /// <summary>
    /// Статический класс для управления магазином
    /// </summary>
    public static class Store
    {
        /// <summary>
        /// Метод для заполнения витрины
        /// </summary>
        /// <param name="mainPage"></param>
        public static void FillStore(MainPage mainPage, BookstoreDb db)
        {
            var store = db.Stores.ToList();
            foreach (var item in store)
            {
                BookItem bookItem = new BookItem(item.Product.Book.Name, item.Product.Book.Autor.Name, (int)item.Product.Year, item.Price, (int)item.Quantity, (int)item.ActionId, (int)item.TagId);
                mainPage.panel.Children.Add(bookItem);
            }
        }
        /// <summary>
        /// Метод для добавления выбранного товара в корзину
        /// </summary>
        /// <param name="mainPage"></param>
        /// <param name="cart"></param>
        public static void AddToBasket(MainPage mainPage, Cart cart)
        {
            List<BookItem> bookItems = new List<BookItem>();
            foreach (var item in mainPage.panel.Children)
            {
                bookItems.Add(item as BookItem);
            }
            foreach (var item in bookItems)
            {
                if (item.IsChecked == true)
                {
                    item.IsChecked = false;
                    item.Border_BookItem.BorderBrush = new SolidColorBrush(Colors.Black);
                    CartItem cartItem = new CartItem(item.BookBookName, item.Author, item.Year, item.Price, item.Quantity, item.Action, item.Tag);
                    cart.StackPanel_Basket.Children.Add(cartItem);
                    
                }
            }
        }
        /// <summary>
        /// Метод для создания заказа
        /// </summary>
        /// <param name="cart"></param>
        public static void CreateOrder(Cart cart)
        {

        }
        /// <summary>
        /// Метод для проверки количества доступного для покупки товара
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static int CheckQuantity(BookstoreDb db)
        {
            return 0;
        }

    }
}
