using System;
using System.Collections;
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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void btnmain_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            Close();
        }

        private void btnadd_customer_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.AddCustomer(txtid.Text, txtName.Text, txtAddress.Text,txtEmail.Text);

            txtid.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
        }


        private void btnsearch_customer_Click(object sender, RoutedEventArgs e)
        {
            string show = "";
            int count = 0;
            ;
            foreach(string data in DataAccess.SearchDataCustomer(txtid.Text))
            {
                if (count % 2 == 1)
                {
                    show = show + " " + data.ToString() + "\r\n";
                }
                else
                {
                    show = show + "ข้อมูลลูกค้า : " + data.ToString();
                }
                count++;
            }
            txtid.Text = "";
            MessageBox.Show(show);
        }

        private void btnshow_Click(object sender, RoutedEventArgs e)
        {
            string show = "";
            int count = 0;
            foreach (string data in DataAccess.GetDataCustomer())
            {
                if (count % 2 == 1)
                {
                    show = show + " " + data.ToString() + "\r\n";
                }
                else
                {
                    show = show + "ข้อมูลลูกค้า : " + data.ToString();
                }
                count++;
            }
            MessageBox.Show(show);
        }

        private void btnedit_customer_Click(object sender, RoutedEventArgs e)
        {
            ArrayList arrayList = new ArrayList();

            int count = 0;
            foreach (string data in DataAccess.ShowEditDataCustomer(txtid.Text))
            {
                arrayList.Add(data.ToString());
                count++;
            }
            arrayList[0] = "";
            arrayList[1] = "";
            arrayList[2] = "";
            arrayList[3] = "";

            txtid.Text = txtid.Text;
            txtName.Text = arrayList[1].ToString();
            txtAddress.Text = arrayList[2].ToString();
            txtEmail.Text = arrayList[3].ToString();
        }

        private void btneditsave_customer_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.EditCustomer(txtid.Text, txtName.Text, txtAddress.Text, txtEmail.Text);

            txtid.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
        }


        private void btndelete_customer_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.DeleteDataCustomer(txtid.Text);
            txtid.Text = "";
        }

        private void btnreset_customer_Click(object sender, RoutedEventArgs e)
        {
            txtid.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
        }
    }
}
