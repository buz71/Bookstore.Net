using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                BookItem bookItem = new BookItem(item.ProductId, item.Product.Book.Name, item.Product.Book.Autor.Name,
                    (int)item.Product.Year, item.Price, (int)item.Quantity, (int)item.ActionId, (int)item.TagId);
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
        /// Метод добавления товара в корзину
        /// </summary>
        /// <param name="mainPage"></param>
        /// <param name="cart"></param>
        public static void AddToBasket(MainPage mainPage, Cart cart)
        {
            EditableList<BookItem> bookItems = new EditableList<BookItem>();
            EditableList<CartItem> cartItems_old = new EditableList<CartItem>();
            EditableList<CartItem> cartItems_new = new EditableList<CartItem>();
            bool IsBasketEmpty = CheckBasketIsEmpty(cart);

            if (IsBasketEmpty)
            {
                foreach (BookItem bookItem in mainPage.panel.Children)
                {
                    if (bookItem.IsChecked)
                    {
                        bookItems.Add(bookItem);
                        bookItem.IsChecked = false;
                        bookItem.Border_BookItem.BorderBrush = new SolidColorBrush(Colors.Black);
                    }
                }

                foreach (BookItem bookItem in bookItems)
                {
                    CartItem cartItem = new CartItem(bookItem);
                    cartItem.ItemCart = mainPage.basket;
                    cart.StackPanel_Basket.Children.Add(cartItem);
                }

            }

            else
            {
                foreach (BookItem bookItem in mainPage.panel.Children)
                {
                    if (bookItem.IsChecked)
                    {
                        bookItems.Add(bookItem);
                        bookItem.IsChecked = false;
                        bookItem.Border_BookItem.BorderBrush = new SolidColorBrush(Colors.Black);
                    }
                }

                foreach (CartItem cartItem in cart.StackPanel_Basket.Children)
                {
                    cartItems_old.Add(cartItem);
                }

                foreach (BookItem bookItem in bookItems)
                {
                    if ((from item in cartItems_old where bookItem.Id == item.Id select item).FirstOrDefault() is null)
                    {
                        cartItems_new.Add(new CartItem(bookItem));
                    }

                }

                cart.StackPanel_Basket.Children.Clear();

                foreach (CartItem cartItem in cartItems_old)
                {
                    cart.StackPanel_Basket.Children.Add(cartItem);
                }

                foreach (CartItem cartItem in cartItems_new)
                {
                    cart.StackPanel_Basket.Children.Add(cartItem);
                }
            }

            SetTotalSum(cart);
        }

        /// <summary>
        /// Метод проверки доступного для заказа количества книг
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static bool CheckQuantity(CartItem item)
        {
            int newQuantity = item.CartQuantity + 1;
            if (newQuantity > item.Quantity)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Метод для увеличения количества товара в корзине
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="Exception"></exception>
        public static void SetQuantityInc(CartItem item)
        {
            if (CheckQuantity(item))
            {
                item.Field_Quntity.Foreground = new SolidColorBrush(Colors.Black);
                item.CartQuantity++;
                item.Field_Quntity.Text = item.CartQuantity.ToString();
            }
            else
            {
                item.Field_Quntity.Foreground = new SolidColorBrush(Colors.Red);
                throw new Exception("Выбранное количество товара недоступно");
            }
        }

        /// <summary>
        /// Метод для уменьшения количества товара в корзине
        /// </summary>
        /// <param name="item"></param>
        public static void SetQuantityDec(CartItem item)
        {

            item.Field_Quntity.Foreground = new SolidColorBrush(Colors.Black);
            item.CartQuantity--;
            item.Field_Quntity.Text = item.CartQuantity.ToString();

        }

        /// <summary>
        /// Метод оформления заказа
        /// </summary>
        /// <param name="mainPage"></param>
        /// <param name="cart"></param>
        public static void CreateOrder(MainPage mainPage, Cart cart)
        {
            List<CartItem> cartItems = new List<CartItem>();
            foreach (CartItem item in cart.StackPanel_Basket.Children)
            {
                if (!CheckQuantity(item))
                {
                    throw new Exception("Выбранное количество товара недоступно");
                }
                cartItems.Add(item);
            }

            //2. Заносим изменения в DB
            foreach (CartItem cartItem in cartItems)
            {
                InsertOrderIntoDB(mainPage.Db,mainPage,cartItem);   
            }

            double orderSum = 0;
            string orderString = "Ваш заказ:";

            //3. Формируем сообщение заказа
            foreach (var item in cartItems)
            {
                orderString +=
                    $"\nКнига:{item.BookName}| Автор: {item.Author} | Количество: {item.Quantity} | Цена: {item.Price}";
                orderSum += item.Price;
            }

            orderString += $"\n Сумма Вашего заказа: {orderSum}";
            mainPage.smtp.SendMessage("Заказ BookStore.NET", orderString);
            cart.StackPanel_Basket.Children.Clear();
            Logger.WriteLog(mainPage.Account.Name, "Оформлен заказ");
        }

        /// <summary>
        /// Метод расчета суммы заказа
        /// </summary>
        /// <param name="cart"></param>
        public static void SetTotalSum(Cart cart)
        {
            cart.TotalSum = 0;

            foreach (CartItem item in cart.StackPanel_Basket.Children)
            {
                cart.TotalSum += (item.Price * item.CartQuantity);
            }

            cart.TextBlock_Total_Sum.Text = cart.TotalSum.ToString();
        }

        /// <summary>
        /// Метод для изменения информации в окошке "Итого"
        /// </summary>
        /// <param name="item"></param>
        public static void SetCartItemTotalSum(CartItem item)
        {
            item.TotalSum = item.CartQuantity * item.Price;
            item.Field_Total.Text = item.TotalSum.ToString();
        }

        /// <summary>
        /// Метод для записи в БД информации о заказе, а так же об изменении доступного для заказа количества товара
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mainPage"></param>
        /// <param name="cartItem"></param>
        public static void InsertOrderIntoDB(BookstoreDb db,MainPage mainPage , CartItem cartItem)
        {
            var client = (from c in db.Clients where c.Mail==mainPage.Account.Mail select c).FirstOrDefault();
            var product =(from p in db.Stores where  p.Id==cartItem.Id select p).FirstOrDefault();
            product.Quantity=cartItem.Quantity-cartItem.CartQuantity;
            db.Sales.Add(new Sale
            {
                ClientId = client.Id,ProductId = cartItem.Id,Price = cartItem.Price,Quantity = cartItem.CartQuantity,Date = (DateTime.Now.ToString())
            });
            db.SaveChanges();
            mainPage.panel.Children.Clear();
            FillStore(mainPage,db);
        }
    }


}


