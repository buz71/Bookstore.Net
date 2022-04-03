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


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            string name, pass, mail;
            if (String.IsNullOrWhiteSpace(TextBlock_Name.Text.ToString()) || String.IsNullOrWhiteSpace(TextBlock_Pass.Text.ToString()) || String.IsNullOrWhiteSpace(TextBlock_Mail.Text.ToString()))
            {
                MessageBox.Show("Введены не корректные данные", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                name = (TextBlock_Name.Text.ToString().Replace(" ", ""));
                pass = (TextBlock_Pass.Text.ToString().Replace(" ", ""));
                mail = (TextBlock_Mail.Text.ToString().Replace(" ", ""));
            }

            try
            {
                AccountManager.Registration(name, pass, mail);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
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
        //

    }
}
