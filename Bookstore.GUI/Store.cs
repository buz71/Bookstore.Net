using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Bookstore.MControl;
using Bookstrore.MControl.Control;
using Castle.Components.DictionaryAdapter;

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
                BookItem bookItem = new BookItem(item.ProductId, item.Product.Book.Name, item.Product.Book.Autor.Name, (int)item.Product.Year, item.Price, (int)item.Quantity, (int)item.ActionId, (int)item.TagId);
                mainPage.panel.Children.Add(bookItem);
            }
        }

        /// <summary>
        /// Метод проверки наличия объектов в корзине
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        private static bool CheckBasketIsEmpty(Cart cart)
        {
            if (cart.StackPanel_Basket.Children.Count != 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Метод для добавления выбранного товара в корзину
        /// </summary>
        /// <param name="mainPage"></param>
        /// <param name="cart"></param>
        public static void AddToBasket(MainPage mainPage, Cart cart)
        {
            EditableList<BookItem> bookItems = new EditableList<BookItem>();
            EditableList<CartItem> cartItems = new EditableList<CartItem>();
            foreach (BookItem bookItem in mainPage.panel.Children)
            {
                if (bookItem.IsChecked)
                {
                    bookItems.Add(bookItem);
                }
            }

            if (!CheckBasketIsEmpty(cart))
            {
                foreach (CartItem cartItem in cart.StackPanel_Basket.Children)
                {
                    cartItems.Add(cartItem);
                }

            }

            cart.StackPanel_Basket.Children.Clear();

            if (!CheckBasketIsEmpty(cart))
            {
                foreach (CartItem cartItem in cartItems)
                {
                    foreach (BookItem bookItem in bookItems)
                    {
                        if (bookItem.Id==cartItem.Id)
                        {
                            //TODO: Где то тут кроется проблема
                            //cartItem.CartQuantity++;
                            //cartItem.Field_Quntity.Text = cartItem.CartQuantity.ToString();
                            cart.StackPanel_Basket.Children.Add(cartItem);
                            bookItems.Remove(bookItem);
                        }
                    }
                }
            }

            foreach (BookItem bookItem in bookItems)
            {
                bookItem.IsChecked = false;
                bookItem.Border_BookItem.BorderBrush = new SolidColorBrush(Colors.Black);
                CartItem cartItem = new CartItem(cart,bookItem.Id, bookItem.BookBookName, bookItem.Author, bookItem.Year, bookItem.Price, bookItem.Quantity, bookItem.Action, bookItem.Tag);
                cart.StackPanel_Basket.Children.Add(cartItem);

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
                cart.TotalSum += (item.Price*item.CartQuantity);
            }
            cart.TextBlock_Total_Sum.Text = cart.TotalSum.ToString();
        }
    }
}
