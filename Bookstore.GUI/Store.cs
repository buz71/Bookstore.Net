using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Bookstore.MControl;
using Bookstrore.MControl.Control;

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
            SetTotalSum(cart);
        }
        /// <summary>
        /// Метод для создания заказа
        /// </summary>
        /// <param name="cart"></param>
        public static void CreateOrder(MainPage mainPage, Cart cart)
        {
            List<CartItem> cartItems = new List<CartItem>();
            foreach (var item in cart.StackPanel_Basket.Children)
            {
                cartItems.Add(item as CartItem);
            }
            double orderSum = 0;
            string orderString = "Ваш заказ:";

            //2. Формируем сообщение заказа
            foreach (var item in cartItems)
            {
                orderString += $"\nКнига:{item.BookName}| Автор: {item.Author} | Количество: {item.Quantity} | Цена: {item.Price}";
                orderSum += item.Price;
            }
            orderString += $"\n Сумма Вашего заказа: {orderSum}";
            mainPage.smtp.SendMessage("Заказ BookStore.NET", orderString);
            cart.StackPanel_Basket.Children.Clear();
            Logger.WriteLog(mainPage.Account.Name, "Оформлен заказ");
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

        /// <summary>
        /// Метод для расчета суммы заказа
        /// </summary>
        /// <param name="cart"></param>
        public static void SetTotalSum(Cart cart)
        {
            cart.TotalSum = 0;
            foreach (CartItem item in cart.StackPanel_Basket.Children)
            {
                cart.TotalSum += item.Price;
            }
            cart.TextBlock_Total_Sum.Text= cart.TotalSum.ToString();
        }
    }
}
