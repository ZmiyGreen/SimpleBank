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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Data;

namespace TestBankClient
{
    /// <summary>
    /// Логика взаимодействия для TransferWindow.xaml
    /// </summary>
    public partial class TransferWindow : Window
    {
        public ObservableCollection<ClientAccount> SourseAccount = new ObservableCollection<ClientAccount>();
        public Dictionary<string, int> CurrencyDict = new Dictionary<string, int>();
        public string Code { get; set; }
        public TransferWindow()
        {
            InitializeComponent();
            AccountGrid.AutoGenerateColumns = false;
            AccountGrid.ItemsSource = SourseAccount;

            //SQLFunctionscs.OpenConnection(MainWindow.ParentWindow.Bullder, "SELECT CU.CurrencySign FROM CURRENCY AS CU;", SQLFunctionscs.ComboBoxAdd, CurrencyBox);
            SQLFunctionscs.OpenConnection(MainWindow.ParentWindow.Bullder, $"SELECT AccountCode FROM ACCOUNT WHERE ClientID = {MainWindow.ParentWindow.IDCode}", SQLFunctionscs.ComboBoxAdd, FromAccountBox);
            SQLFunctionscs.OpenConnection(MainWindow.ParentWindow.Bullder, $"SELECT AccountCode FROM ACCOUNT WHERE ClientID = {MainWindow.ParentWindow.IDCode}", SQLFunctionscs.ComboBoxAdd, ToAccountBox);
            SQLFunctionscs.OpenConnection(MainWindow.ParentWindow.Bullder, $"SELECT * FROM dbo.ShowAccounts({MainWindow.ParentWindow.IDCode});", SQLFunctionscs.CollectionAdd, SourseAccount);

            using (var Connection = new SqlConnection(MainWindow.ParentWindow.Bullder.ConnectionString))
            {
                Connection.Open();
                using (var Command = new SqlCommand("SELECT CU.CurrencySign, Cu.CurrencyID FROM CURRENCY AS CU;", Connection))
                {
                    var Reader = Command.ExecuteReader();
                    while(Reader.Read())
                    {
                        CurrencyDict[Reader.GetString(0)] = Reader.GetInt32(1);
                    }
                }
            }
            CurrencyBox.ItemsSource = CurrencyDict.Keys;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SelfTransferButton_Click(object sender, RoutedEventArgs e)
        {
            SQLFunctionscs.UseTransferMoney(SourseAccount, MoneyValueBox.Text, FromAccountBox.SelectedItem.ToString(), ToAccountBox.SelectedItem.ToString());
        }

        private void CodeTransferButton_Click(object sender, RoutedEventArgs e)
        {
            SQLFunctionscs.UseTransferMoney(SourseAccount, MoneyValueBox.Text, FromAccountBox.SelectedItem.ToString(), AccountCodeBox.Text);
        }

        private void OpenAccountButton_Click(object sender, RoutedEventArgs e)
        {
            SQLFunctionscs.ConectionFunc(
                MainWindow.ParentWindow.Bullder, $"INSERT INTO ACCOUNT(AccountCode, ClientID, CurrencyID, MoneyValue)" +
                $" VALUES({AccountInputCodebox.Text},{MainWindow.ParentWindow.IDCode},{CurrencyDict[CurrencyBox.SelectedItem.ToString()]}, 0);");
            SourseAccount.Clear();
            SQLFunctionscs.OpenConnection(MainWindow.ParentWindow.Bullder, $"SELECT * FROM dbo.ShowAccounts({MainWindow.ParentWindow.IDCode});", SQLFunctionscs.CollectionAdd, SourseAccount);
        }

        private void CloseAccountButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SQLFunctionscs.ConectionFunc(MainWindow.ParentWindow.Bullder, $"DELETE FROM ACCOUNT WHERE AccountCode = '{AccountGrid.SelectedItem.ToString()}'");
                SourseAccount.Clear();
                SQLFunctionscs.OpenConnection(MainWindow.ParentWindow.Bullder, $"SELECT * FROM dbo.ShowAccounts({MainWindow.ParentWindow.IDCode});", SQLFunctionscs.CollectionAdd, SourseAccount);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DepositButton_Click(object sender, RoutedEventArgs e)
        {
            var paramDict = new Dictionary<string, string>
            {
                ["@Value"] = MoneyValueBox.Text,
                ["@AccountCode"] = FromAccountBox.SelectedItem.ToString(),
                ["@CurrencyID"] = CurrencyDict[CurrencyBox.SelectedItem.ToString()].ToString()
            };
            SQLFunctionscs.SQLStoredProcedure(MainWindow.ParentWindow.Bullder, "dbo.depositMoney", paramDict);
            SourseAccount.Clear();
            SQLFunctionscs.OpenConnection(MainWindow.ParentWindow.Bullder, $"SELECT * FROM dbo.ShowAccounts({MainWindow.ParentWindow.IDCode});", SQLFunctionscs.CollectionAdd, SourseAccount);
        }
    }
}
