using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;


namespace TestBankClient
{
    public static class SQLFunctionscs
    {
        /// <summary>
        /// Отправить запрос без извлечения данных
        /// </summary>
        /// <param name="Builder"></param>
        /// <param name="ComandString"></param>
        public static void ConectionFunc(SqlConnectionStringBuilder Builder, string ComandString)
        {
            using (var Connection = new SqlConnection(Builder.ConnectionString))
            {
                Connection.Open();
                using (var Command = new SqlCommand(ComandString, Connection))
                {
                    Command.ExecuteNonQuery();
                }
            }
        }

        public static void OpenConnection<T>(SqlConnectionStringBuilder Builder, string ComandString, Action<SqlCommand, T> func, T GoalData)
        {
            using (var Connection = new SqlConnection(Builder.ConnectionString))
            {
                Connection.Open();
                using (var Command = new SqlCommand(ComandString, Connection))
                {
                    func(Command, GoalData);
                }
            }
        }

        public static void CollectionAdd<T>(SqlCommand Command, ObservableCollection<T> ListCollection) where T : IInitialize, new()
        {
            var Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                T Temp = new T();
                Temp.Init(Reader);
                
                ListCollection.Add(Temp);
            }
        }

        public static void ComboBoxAdd(SqlCommand Command, ComboBox Box)
        {
            var Reader = Command.ExecuteReader();
            while(Reader.Read())
            {
                Box.Items.Add(Reader.GetString(0));
            }
        }

        public static void UseTransferMoney(ObservableCollection<ClientAccount> SourseCollection, string Value, string FromAccount, string ToAccount)
        {
            using (var Connection = new SqlConnection(MainWindow.ParentWindow.Bullder.ConnectionString))
            {
                Connection.Open();
                using (var Command = new SqlCommand("dbo.TransferMoney", Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    Command.Parameters.Add(new SqlParameter("@Value", Value));
                    Command.Parameters.Add(new SqlParameter("@fromCode", FromAccount));
                    Command.Parameters.Add(new SqlParameter("@ToCode", ToAccount));
                    Command.ExecuteNonQuery();
                }
            }
            SourseCollection.Clear();
            SQLFunctionscs.OpenConnection(MainWindow.ParentWindow.Bullder, $"SELECT * FROM dbo.ShowAccounts({MainWindow.ParentWindow.IDCode});", SQLFunctionscs.CollectionAdd, SourseCollection);
        }
        public static void SQLStoredProcedure(SqlConnectionStringBuilder Build, string procName, Dictionary<string, string> parametrs)
        {
            using (var Connection = new SqlConnection(Build.ConnectionString))
            {
                Connection.Open();
                using (var Command = new SqlCommand(procName, Connection))
                {
                    Command.CommandType = CommandType.StoredProcedure;
                    foreach (var i in parametrs)
                        Command.Parameters.Add(new SqlParameter(i.Key, i.Value));
                    Command.ExecuteNonQuery();
                }
            }
        }

    }
}
