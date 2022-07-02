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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public Order()
        {
            InitializeComponent();
        }

        private void btnmain_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            Close();
        }


        private void btnshowCustomer_Click(object sender, RoutedEventArgs e)
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

        private void btnshowBook_Click(object sender, RoutedEventArgs e)
        {
            string show = "";
            int count = 0;
            foreach (string data in DataAccess.GetDataBook())
            {
                if (count % 4 == 0)
                {
                    show = show + "รหัสหนังสือ " + data.ToString();
                }
                else if (count % 4 == 1)
                {
                    show = show + " ชื่อหนังสือ " + data.ToString();
                }
                else if (count % 4 == 2)
                {
                    show = show + " คำอธิบาย " + data.ToString();
                }
                else if (count % 4 == 3)
                {
                    show = show + " ราคา " + data.ToString() + " บาท " + "\r\n";
                }
                count++;
            }
            MessageBox.Show(show);
        }

        private void btndetail_Click(object sender, RoutedEventArgs e)
        {
            ArrayList arrayList = new ArrayList();

            foreach (string data in DataAccess.ShowEditDataBook(txtISBN.Text))
            {
                arrayList.Add(data.ToString());

            }

            txtISBN.Text = txtISBN.Text;
            txtTitle.Text = arrayList[1].ToString();
            txtDescription.Text = arrayList[2].ToString();
            txtPrice.Text = arrayList[3].ToString();
        }

        private void btnconfirm_Click(object sender, RoutedEventArgs e)
        {
            int price = int.Parse(txtPrice.Text);
            int quatity = int.Parse(txtQuatity.Text);
            int sum = price * quatity;
            DataAccess.AddOrder(txtISBN.Text,txtCustomerID.Text,txtQuatity.Text,sum);

            MessageBox.Show("สรุปรายการ"+ "\r\n"+"รหัสหนังสือ : "+txtISBN.Text+ "\r\n"+"รหัสลูกค้า : "+ txtCustomerID.Text+ "\r\n"+ "จำนวนหนังสือ : " + txtQuatity.Text + "\r\n" + "ราคารวม : "+sum);

            txtISBN.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
            txtQuatity.Text = "";
            txtCustomerID.Text = "";
        }
    }
}
