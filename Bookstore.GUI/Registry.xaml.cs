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

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Registry.Window.DragMove();
            }
        }


        private void Button_Registration_OnClick(object sender, RoutedEventArgs e)
        {
            //TODO: Нужно добавить Имя, Фамилия, Логин
            string login = (TextBox_Login.Text.ToString().Replace(" ", ""));
            string pass = (TextBox_Pass.Text.ToString().Replace(" ", ""));
            string mail = (TextBox_Mail.Text.ToString().Replace(" ", ""));

            //
            //string name = (TextBox_Name.Text.ToString().Replace(" ", ""));
            //string surname = (TextBox_Surname.Text.ToString().Replace(" ", ""));
            //

            if (TextBox_Login.Text == "" || TextBox_Pass.Text == "" || TextBox_Mail.Text == "")
            {
                MessageBox.Show("Введены не корректные данные", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                AccountManager.Registration(login, pass, mail);
                MessageBox.Show("Вы успешно зарегистрированы", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Пользователь уже зарегистрирован", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Зачем нужны эти методы?
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

        private void Window_Reg_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
