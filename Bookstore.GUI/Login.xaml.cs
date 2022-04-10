using System;
using System.Collections.Generic;
using System.IO;
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
using Bookstrore.MControl.Model;
using Microsoft.Data.Sqlite;

namespace Bookstore.GUI
{
    public partial class MainWindow : Window
    {
        public static MainWindow Window;
        public MainWindow()
        {
            InitializeComponent();
            Window = this;
        }

        private void Button_Login_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //Для тестирования можно попробовать login:admin, password:admin
                MainPage mainPage = new MainPage();
                mainPage.Db = AccountManager.Autorization(Box_user.Text, Box_pass.Password);
                mainPage.Account = (from a in mainPage.Db.Accounts where a.Name == Box_user.Text select a).FirstOrDefault();
                mainPage.smtp = new SMTP(mainPage.Account.Mail);
                MessageBox.Show("Добро пожаловать в книжный магазин", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                SMTP.SendMessage((mainPage.Account.Mail), "Вход в аккаунт Bookstore.NET", $"В Ваш аккаунт выполнен вход {DateTime.Now}");
                if (File.Exists($"{mainPage.Account.Name}.txt"))
                {
                    Logger.WriteLog(mainPage.Account.Name, "Выполнен вход в приложение");
                }
                else
                {
                    Logger.CreateLog((mainPage.Account.Name));
                }
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

        // метод позволяет двигать окно мышкой
        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                MainWindow.Window.DragMove();
            }
        }

        //метод позволяет закрыть окно "крестиком"
        private void Window_Log_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}