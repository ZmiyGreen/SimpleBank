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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

namespace TestBankClient
{
    public static class OpenWindow
    {
        public static void OpenTransferWindow()
        {
            var Transfer = new TransferWindow();
            Transfer.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            Transfer.ShowDialog();
        }
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public static MainWindow ParentWindow { get; private set; }

        public SqlConnectionStringBuilder Bullder = new SqlConnectionStringBuilder {IntegratedSecurity = true };
        public ObservableCollection<ClientCountAccounts> SourseCollection = new ObservableCollection<ClientCountAccounts>();
        public string IDCode { get; set; }
        public readonly string DbConfigFileName = "DbConfig.xml";
        public MainWindow()
        {
            InitializeComponent();
            ParentWindow = this;

            ClientInfoemationGrid.AutoGenerateColumns = false;
            ClientInfoemationGrid.ItemsSource = SourseCollection;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (File.Exists(DbConfigFileName))
            {
                using (var reader = XmlReader.Create(DbConfigFileName, new XmlReaderSettings { IgnoreWhitespace = true }))
                {
                    reader.MoveToContent();
                    reader.ReadStartElement("DbConnectionOptions");
                    Bullder.DataSource = reader.ReadElementContentAsString("DataSource", "");
                    Bullder.InitialCatalog = reader.ReadElementContentAsString("InitialCatalog", "");
                    reader.ReadEndElement();
                }
            }
            else
            {
                MessageBox.Show("Отсутствуют настройки поключения к БД!");
            }
        }

        private void NewClientButton_Click(object sender, RoutedEventArgs e)
        {
            var NewClient = new NewClientWindow();
            NewClient.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            NewClient.ShowDialog();
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            if (SourseCollection.Count != 0)
                SourseCollection.Clear();
            string selectString = "SELECT * FROM dbo.NumberOfAccounts()";
            using (var Connection = new SqlConnection(Bullder.ConnectionString))
            {
                Connection.Open();
                using (var Command = new SqlCommand(selectString , Connection))
                {
                    var Reader = Command.ExecuteReader();
                    while(Reader.Read())
                    {
                        SourseCollection.Add(new ClientCountAccounts(Reader));
                    }
                }
            }

        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IDCode = ClientInfoemationGrid.SelectedItem.ToString();
                OpenWindow.OpenTransferWindow();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DBOptions_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var OptionsWindow = new DbOptionsWindow();
                OptionsWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                OptionsWindow.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
