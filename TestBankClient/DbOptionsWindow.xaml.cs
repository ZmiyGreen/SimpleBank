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
using System.Xml;

namespace TestBankClient
{
    /// <summary>
    /// Логика взаимодействия для DbOptionsWindow.xaml
    /// </summary>
    public partial class DbOptionsWindow : Window
    {
        public DbOptionsWindow()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            using (var writer = XmlWriter.Create(MainWindow.ParentWindow.DbConfigFileName, new XmlWriterSettings { Indent = true }))
            {
                writer.WriteStartElement("DbConnectionOptions");
                writer.WriteElementString("DataSource", DataSourceBox.Text);
                writer.WriteElementString("InitialCatalog", InitializeCatalogBox.Text);
                writer.WriteEndElement();
            }
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
