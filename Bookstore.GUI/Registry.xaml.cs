using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Bookstrore.MControl.Control;


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
            Window = this;
            InitializeComponent();
        }

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
            Application.Current.Shutdown();
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
                RegWindow.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Пользователь уже зарегистрирован", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
    }
}
