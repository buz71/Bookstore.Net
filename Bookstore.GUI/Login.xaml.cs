using System.Windows;
using System.Windows.Input;
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
        public static MainWindow Window;
        public MainWindow()
        {
            Window = this;
            InitializeComponent();
        }

        // метод позволяет двигать окно мышкой
        private void Drag(object sender, RoutedEventArgs e)
        {
            if(Mouse.LeftButton==MouseButtonState.Pressed)
            {
                MainWindow.Window.DragMove();
            }
        }

        //метод позволяет закрыть окно "крестиком"
        private void Window_Log_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Login_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //Для тестирования можно попробовать login:admin, password:admin

                MainPage mainPage = new MainPage();
                mainPage.Db = AccountManager.Autorization(Box_user.Text, Box_pass.Password);
                MessageBox.Show("Добро пожаловать в книжный магазин", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                mainPage.Show();
                LogWindow.Close();

            }
            catch (SqliteException exeption)
            {
                MessageBox.Show(exeption.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Registry_OnClick(object sender, RoutedEventArgs e)
        {
            Registry registry = new Registry();
            registry.ShowDialog();
        }
    }
}
