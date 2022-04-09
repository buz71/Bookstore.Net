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
using Bookstore.MControl;
using Bookstrore.MControl.Model;

namespace Bookstore.GUI
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        private BookstoreDb _db;
        private SMTP _smtp;
        private Account _account;

        public BookstoreDb Db
        {
            get { return _db;}
            set { _db = value; }
        }

        public Account Account
        {
            get { return _account; }
            set { _account = value; }
        }

        public SMTP Smtp
        {
            get { return _smtp; }
            set { _smtp = value; }
        }

        public MainPage()
        {
            InitializeComponent();
        }

        #region StylesMethods
        private void Button_catalog(object sender, RoutedEventArgs e)
        {

        }
        private void Button_cart(object sender, RoutedEventArgs e)
        {

        }
        private void Button_persona(object sender, RoutedEventArgs e)
        {

        } 
        #endregion

    }
}
