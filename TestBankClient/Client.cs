using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestBankClient
{
    public interface IInitialize
    {
        void Init(SqlDataReader Reader);
    }
    public class Client : IInitialize
    {
        public int? ClientID { get; private set; } = null;
        private string _familyName;
        private string _firstName;
        private string _lastName;
        private DateTime _bornDate;
        private string _contactEmail;


        public string Date { get => _bornDate.ToShortDateString(); }
        public string FamilyName
        {
            get => _familyName;
            set => _familyName = ValidateStr(value, 30);
        }
        public string FirstName
        {
            get => _firstName;
            set => _firstName = ValidateStr(value, 30);
        }
        public string LastName
        {
            get => _lastName;
            set => _lastName = ValidateStr(value, 30);
        }
        public string ContactEmail
        {
            get => _contactEmail;
            set => _contactEmail = ValidateStr(value, 30);
        }
        public DateTime BordDate
        {
            get => _bornDate;
            set => _bornDate = DateTime.Now.Year - value.Year >= 18 ? value : throw new Exception("Минимальный возраст клиента 18 лет!"); 
        }

        public override string ToString() => ClientID.ToString();

        public Client(SqlDataReader Reader) => Init(Reader);
        public Client() { }

        public virtual void Init(SqlDataReader Reader)
        {
            ClientID = Reader.GetInt32(0);
            FamilyName = Reader.GetString(1);
            FirstName = Reader.GetString(2);
            LastName = Reader.GetString(3);
            BordDate = Reader.GetDateTime(4);
            ContactEmail = Reader.GetString(5);
        }

        private string ValidateStr(string Value, int maxLen) => Value.Length <= 30 ? Value : throw new Exception($"Длинна строки не должна превышать {maxLen} символов!");
    }

    public class ClientCountAccounts : Client, IInitialize
    {
        public int NumberOfAccounts { get; private set; }

        public ClientCountAccounts(SqlDataReader Reader)// : base(Reader)
        {
            //NumberOfAccounts = Reader.GetInt32(6);
            Init(Reader);
        }
        public ClientCountAccounts() { }
        public override void Init(SqlDataReader Reader)
        {
            base.Init(Reader);
            NumberOfAccounts = Reader.GetInt32(6);
        }
    }

    public class ClientAccount : IInitialize
    {
        private string _accountCode;
        private decimal _moneyValue;
        public string Sign { get; private set; }

        public string AccountCode
        {
            get => _accountCode;
            set => _accountCode = value.Length == 16 ? value : throw new Exception("Номер счета должен состоять из 16ти символов!");
        }
        public decimal MoneyValue
        {
            get => _moneyValue;
            set => _moneyValue = value >= 0 ? value : throw new Exception("На счету должно быть неотрицательное значение!");
        }

        public ClientAccount(string AccountCode, decimal MoneyValue, string Sign) => Init(AccountCode, MoneyValue, Sign);
        public ClientAccount(SqlDataReader Reader) => Init(Reader);
        public ClientAccount() { }

        public void Init(string AccountCode, decimal MoneyValue, string Sign) => (this.AccountCode, this.MoneyValue, this.Sign) = (AccountCode, MoneyValue, Sign);
        public void Init(SqlDataReader Reader)
        {
            AccountCode = Reader.GetString(0);
            MoneyValue = Reader.GetDecimal(1);
            Sign = Reader.GetString(2);
        }
        public override string ToString() => AccountCode.ToString();
    }
}
