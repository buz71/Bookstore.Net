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


namespace Bookstore.GUI
{
    /// <summary>
    /// Interaction logic for Registry.xaml
    /// </summary>
    public partial class Registry : Window
    {
        public Registry()
        {
            InitializeComponent();
        }


        private void Button_Registration_OnClick(object sender, RoutedEventArgs e)
        {
            ////TODO: Нужно добавить Имя, Фамилия, Логин
            //string name = (TextBox_Name.Text.ToString().Replace(" ", ""));
            //string pass = (TextBox_Pass.Text.ToString().Replace(" ", ""));
            //string mail = (TextBox_Mail.Text.ToString().Replace(" ", ""));

            //if (TextBox_Name.Text==""|| TextBox_Pass.Text == ""|| TextBox_Mail.Text == "")
            //{
            //    MessageBox.Show("Введены не корректные данные", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return;
            //}

            //try
            //{
            //   AccountManager.Registration(name, pass, mail);
            //   MessageBox.Show("Вы успешно зарегистрированы", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //catch (Exception exception)
            //{
            //    MessageBox.Show("Пользователь уже зарегистрирован", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
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
        //

    }
}
