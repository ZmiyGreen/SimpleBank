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
using System.Data.SqlClient;

namespace TestBankClient
{
    /// <summary>
    /// Логика взаимодействия для NewClientWindow.xaml
    /// </summary>
    public partial class NewClientWindow : Window
    {
        public NewClientWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string InsertString = $"INSERT INTO CLIENT(FamilyName, FirstName, LastName, BornDate, ContactEmail) VALUES('{FamilyBox.Text}', '{FirstNameBox.Text}', '{LastNameBox.Text}', '{BornDateBox.Text}', '{EmailBox.Text}');";
            using (var Connection = new SqlConnection(MainWindow.ParentWindow.Bullder.ConnectionString))
            {
                Connection.Open();
                using (var Command = new SqlCommand(InsertString, Connection))
                {
                    Command.ExecuteNonQuery();
                }
            }
            this.Close();
        }
    }
}
