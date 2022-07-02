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
    /// Interaction logic for Book.xaml
    /// </summary>
    public partial class Book : Window
    {
        public Book()
        {
            InitializeComponent();
        }

        private void btnmain_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            Close();
        }

        private void btnadd_book_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.AddBook(txtISBN.Text,txtTitle.Text,txtDescription.Text,int.Parse(txtPrice.Text));
            txtISBN.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
        }

        private void btnshow_Click(object sender, RoutedEventArgs e)
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

        private void btnreset_book_Click(object sender, RoutedEventArgs e)
        {
            txtISBN.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
        }

        private void btnsearch_book_Click(object sender, RoutedEventArgs e)
        {
            string show = "";
            int count = 0;
            foreach (string data in DataAccess.SearchDataBook(txtISBN.Text))
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

            txtISBN.Text = "";
            MessageBox.Show(show);
        }

        private void btnedit_book_Click(object sender, RoutedEventArgs e)
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

        private void btneditsave_book_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.EditBook(txtISBN.Text, txtTitle.Text, txtDescription.Text, int.Parse(txtPrice.Text));

            txtISBN.Text = "";
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtPrice.Text = "";
        }

        private void btndelete_book_Click(object sender, RoutedEventArgs e)
        {
            DataAccess.DeleteDataBook(txtISBN.Text);
            txtISBN.Text = "";
        }
    }
}
