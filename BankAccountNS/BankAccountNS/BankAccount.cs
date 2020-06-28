using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNS
{

    public enum Status
    {
        FROZEN, 
        ACTIVE
    }
    public class BankAccount
    {
        private string m_customerName;

        private double m_balance;

        private int m_id;

        private string m_password;

        private int m_wrongLogin; 

        private bool m_frozen = false;

        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";

        public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero";

        private BankAccount()
        {
        }

        public BankAccount(string customerName, double balance, int id, string password)
        {
            m_customerName = customerName;
            m_balance = balance;
            m_id = id;
            m_password = password;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }
        public int Id
        {
            get { return m_id; }
        }

        public string Password
        {
            get { return m_password; }
        }

        public int WrongLogin
        {
            get { return m_wrongLogin; }
        }
        public bool Frozen
        {
            get { return m_frozen; }
        }

        public void Debit(double amount)
        {

            if (m_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount; // intentionally incorrect code
        }

        public void Credit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }

        public bool Login (int id, string password)
        {
            if( id != m_id)
            {
                throw new Exception("wrong ID");
                
            }else if (password != m_password)
            {
                ++m_wrongLogin; 
                if(m_wrongLogin > 5)
                {
                    m_frozen = true; 
                }
                
            }else if (m_frozen == false)
            {
                return true; 
            }

            return false; 
            
        }

        private void FreezeAccount()
        {
            m_frozen = true;
        }

        private void UnfreezeAccount()
        {
            m_frozen = false;
        }

        public Status status()
        {
            return m_frozen ? Status.FROZEN : Status.ACTIVE; 
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99, 123, "abc123");

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }
    }
}
