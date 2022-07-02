using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp
{
    internal class DataAccess
    {
        public  static void InitializeDatabase()
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                //Create Books tables
                String tableBooksCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Books (ISBN INTEGER  PRIMARY KEY, " +
                    "Title NVARCHAR(100) NOT NULL,"+
                    "Description NVARCHAR(255) NOT NULL," +
                    "Price INTEGER NOT NULL" + 
                    ")";
                SqliteCommand createBooksTable = new SqliteCommand(tableBooksCommand, db);
                createBooksTable.ExecuteReader();

                //Create Customers tables
                String tableCustomersCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Customers (Customer_Id INTEGER  PRIMARY KEY, " +
                    "Customers_Name NVARCHAR(100) NOT NULL," +
                    "Address NVARCHAR(255) NOT NULL," +
                    "Email NVARCHAR(255) NOT NULL" +
                    ")";
                SqliteCommand createCustomersTable = new SqliteCommand(tableCustomersCommand, db);
                createCustomersTable.ExecuteReader();

                //Create Transactions tables
                String tableTransactionsCommand = "CREATE TABLE IF NOT " +
                    "EXISTS Transactions (Transactions_Id INTEGER AUTO_INCREMENT PRIMARY KEY, " +
                    "ISBN INTEGER NOT NULL," +
                    "Customer_Id INTEGER NOT NULL," +
                    "Quatity INTEGER NOT NULL," +
                    "Total_Price INTEGER NOT NULL" +
                    ")";
                SqliteCommand createTransactionsTable = new SqliteCommand(tableTransactionsCommand, db);
                createTransactionsTable.ExecuteReader();
            }
        }

        public static void AddCustomer(string customer_id, string customer_name, string address, string email)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Customers VALUES (@customer_id, @customer_name,@address,@email);";
                insertCommand.Parameters.AddWithValue("@customer_id", customer_id);
                insertCommand.Parameters.AddWithValue("@customer_name", customer_name);
                insertCommand.Parameters.AddWithValue("@address", address);
                insertCommand.Parameters.AddWithValue("@email", email);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        public static List<String> GetDataCustomer()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Customer_Id,Customers_Name from Customers", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));

                }
                db.Close();
            }
            return entries;
        }

        public static List<String> SearchDataCustomer(string customer_id)
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Customer_Id,Customers_Name from Customers Where Customer_Id = @customer_id", db);
                selectCommand.Parameters.AddWithValue("@customer_id", customer_id);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));

                }
                db.Close();
            }
            return entries;
        }

        public static void EditCustomer(string customer_id, string customer_name, string address, string email)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                SqliteCommand updateCommand = new SqliteCommand();
                updateCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                updateCommand.CommandText = "UPDATE Customers SET Customers_Name = @customer_name ,Address = @address,Email =  @email Where Customer_Id = @customer_id;";
                updateCommand.Parameters.AddWithValue("@customer_name", customer_name);
                updateCommand.Parameters.AddWithValue("@address", address);
                updateCommand.Parameters.AddWithValue("@email", email);
                updateCommand.Parameters.AddWithValue("@customer_id", customer_id);
                updateCommand.ExecuteReader();
                db.Close();
            }
        }
        public static List<String> ShowEditDataCustomer(string customer_id)
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Customers Where Customer_Id = @customer_id", db);
                selectCommand.Parameters.AddWithValue("@customer_id", customer_id);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }
                db.Close();
            }
            return entries;
        }

        public static void DeleteDataCustomer(string customer_id)
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                SqliteCommand deleteCommand = new SqliteCommand
                    ("DELETE  FROM  Customers WHERE  Customer_Id = @customer_id", db);
                deleteCommand.Parameters.AddWithValue("@customer_id", customer_id);
                SqliteDataReader query = deleteCommand.ExecuteReader();
                db.Close();
            }
        }

        public static void AddBook(string ISBN, string Title, string Description, int Price)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Books VALUES (@ISBN, @Title,@Description,@Price);";
                insertCommand.Parameters.AddWithValue("@ISBN", ISBN);
                insertCommand.Parameters.AddWithValue("@Title", Title);
                insertCommand.Parameters.AddWithValue("@Description", Description);
                insertCommand.Parameters.AddWithValue("@Price", Price);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        public static List<String> GetDataBook()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Books", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }
                db.Close();
            }
            return entries;
        }

        public static List<String> SearchDataBook(string ISBN)
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Books Where ISBN = @ISBN", db);
                selectCommand.Parameters.AddWithValue("@ISBN", ISBN);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }
                db.Close();
            }
            return entries;
        }

        public static List<String> ShowEditDataBook(string ISBN)
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Books Where ISBN = @ISBN", db);
                selectCommand.Parameters.AddWithValue("@ISBN", ISBN);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }
                db.Close();
            }
            return entries;
        }

        public static void EditBook(string ISBN, string Title, string Description, int Price)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                SqliteCommand updateCommand = new SqliteCommand();
                updateCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                updateCommand.CommandText = "UPDATE Books SET Title = @Title,Description =  @Description,Price = @Price  Where ISBN = @ISBN;";
                updateCommand.Parameters.AddWithValue("@Title", Title);
                updateCommand.Parameters.AddWithValue("@Description", Description);
                updateCommand.Parameters.AddWithValue("@Price", Price);
                updateCommand.Parameters.AddWithValue("@ISBN", ISBN);
                updateCommand.ExecuteReader();
                db.Close();
            }
        }

        public static void DeleteDataBook(string ISBN)
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                SqliteCommand deleteCommand = new SqliteCommand
                    ("DELETE  FROM  Books WHERE  ISBN = @ISBN", db);
                deleteCommand.Parameters.AddWithValue("@ISBN", ISBN);
                SqliteDataReader query = deleteCommand.ExecuteReader();
                db.Close();
            }
        }

        public static void AddOrder(string ISBN, string Customer_Id, string Quatity, int Total_Price)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Transactions VALUES (NULL,@ISBN, @Customer_Id,@Quatity,@Total_Price);";
                insertCommand.Parameters.AddWithValue("@ISBN", ISBN);
                insertCommand.Parameters.AddWithValue("@Customer_Id", Customer_Id);
                insertCommand.Parameters.AddWithValue("@Quatity", Quatity);
                insertCommand.Parameters.AddWithValue("@Total_Price", Total_Price);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }

        public static List<String> GetDataOrder()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=SqlBookStore.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Transactions.ISBN,Customers.Customers_Name,Transactions.Quatity,Transactions.Total_Price from Transactions INNER JOIN Customers ON Transactions.Customer_Id = Customers.Customer_Id", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                    entries.Add(query.GetString(3));
                }
                db.Close();
            }
            return entries;
        }
    }
}
