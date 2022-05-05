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
using System.Windows.Shapes;
using Bookstrore.MControl.Control;
using Bookstrore.MControl.Model;


namespace Bookstore.GUI
{
    /// <summary>
    /// Interaction logic for Registry.xaml
    /// </summary>
    public partial class Registry : Window
    {
        public static Registry Window;
        public Registry()
        {
            InitializeComponent();
            Window = this;
            AllowsTransparency = true;      //прозрачность фона windows
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            string login = (TextBox_Login.Text.ToString().Replace(" ", ""));
            string pass = (TextBox_Pass.Text.ToString().Replace(" ", ""));
            string mail = (TextBox_Mail.Text.ToString().Replace(" ", ""));
            string name = (TextBox_Name.Text.ToString().Replace(" ", ""));
            string surname = (TextBox_Surname.Text.ToString().Replace(" ", ""));

            if (login == "" || pass == "" || mail == "" || surname == "" || name == "" || !mail.Contains("@"))
            {
                MessageBox.Show("Введены не корректные данные", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                AccountManager.Registration(login, pass, mail, name, surname);
                MessageBox.Show("Вы успешно зарегистрированы", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                SMTP.SendMessage(mail, "Регистрация в Bookstore.NET", "Спасибо за регистрацию в книжном магазине Bookstore.NET");
                Logger.CreateLog(login);
                Logger.WriteLog($"{login}.txt", "Пользователь зарегистрирован");
                RegWindow.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        #region Styles Methods
        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb5_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        #endregion

        // метод позволяет двигать окно мышкой
        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Registry.Window.DragMove();
            }
        }

        //метод позволяет закрыть окно "крестиком"
        private void Window_Reg_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
