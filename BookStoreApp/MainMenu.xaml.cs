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

namespace BookStoreApp
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.Show();
            Close();    
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book();
            book.Show();
            Close();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.Show();
            Close();
        }

        private void btnlogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void btnhistorysell_Click(object sender, RoutedEventArgs e)
        {
           
            string show = "";
            int count = 0;
            foreach (string data in DataAccess.GetDataOrder())
            {
                if (count % 4 == 0)
                {
                    show = show + "รหัสหนังสือ " + data.ToString();
                }
                else if (count % 4 == 1)
                {
                    show = show + " ชื่อลูกค้า " + data.ToString();
                }
                else if (count % 4 == 2)
                {
                    show = show + " จำนวนเล่ม " + data.ToString();
                }
                else if (count % 4 == 3)
                {
                    show = show + " ราคารวม " + data.ToString() +  " บาท " + "\r\n";
                }

                count++;
            }
            MessageBox.Show(show);
        }
    }
}
