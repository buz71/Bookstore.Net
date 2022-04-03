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
using Bookstore.MControl;
using Bookstrore.MControl.Control;
using Microsoft.Data.Sqlite;

namespace Bookstore.GUI
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Переменная которая хравнит объект подключения для работы с БД.
        /// В случае успешной авторизации, метод Autorization возвращает объект подключения к БД
        /// </summary>
        private BookstoreDb db;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Login_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //Для тестирования можно попробовать login:admin, password:admin 
                db = AccountManager.Autorization(Box_user.Text, Box_pass.Password);
                MessageBox.Show("Добро пожаловать в книжный магазин", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                //LogWindow.Close(); //Скрытие окна авторизации
            }
            catch (SqliteException exeption)
            {
                MessageBox.Show(exeption.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Registry_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Нажал");
        }

    }
}
