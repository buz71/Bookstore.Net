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

namespace Bookstore.GUI
{
    
    /// <summary>
    /// Interaction logic for Persona.xaml
    /// </summary>
    public partial class Persona : Window
    {
        public static Persona Window;
        public Cart basket;
        public Persona()
        {
            InitializeComponent();
            Window = this;
            AllowsTransparency = true;           //прозрачность фона windows
        }
        // метод позволяет двигать окно мышкой
        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Persona.Window.DragMove();
            }
        }

        //метод позволяет закрыть окно "крестиком"
        private void Window_Persona_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_cart(object sender, RoutedEventArgs e)
        {
            basket.ShowDialog();
        }
    }
}
