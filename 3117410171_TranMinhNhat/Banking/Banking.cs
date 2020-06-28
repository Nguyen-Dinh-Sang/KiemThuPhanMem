using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public enum Status
    {
        FROZEN,
        ACTIVE,
        LOGGED_IN,
        LOGGED_OUT
    };
    public class BankAccount
    {
        private int id;
        private string password;
        private double balance;
        private Status m_status;
        private int wrong_login;
        public int created_year;

        public BankAccount(int id, string password)
        {
            this.id = id;
            this.password = password;
            this.balance = 0;
            this.m_status = Status.ACTIVE;
            this.wrong_login = 0;
            this.created_year = DateTime.Now.Year;

        }
        public double getBalance()
        {
            return balance;
        }
        public void debit(double change)
        {
            if (balance < change)
                throw new ArgumentOutOfRangeException("Debit amount exceeds balance");
            else if (change < 0)
                throw new ArgumentOutOfRangeException("Charge less than zero");
            else if (m_status == Status.FROZEN)
                throw new Exception("Account is frozen");
            balance += change;
        }
        public bool login(int id, string pass)
        {
            if (id != this.id)
                throw new Exception("Wrong ID");
            else if (pass != this.password)
            {
                ++wrong_login;
                if (wrong_login > 5)
                    m_status = Status.FROZEN;
            }
            else if (m_status == Status.ACTIVE || m_status == Status.LOGGED_OUT)
            {
                wrong_login = 0;
                m_status = Status.LOGGED_IN;
                System.Console.WriteLine("Successfully login");
                return true;
            }
            System.Console.WriteLine("Failed login");
            return false;


        }
        public void logout()
        {
            m_status = Status.LOGGED_OUT;
        }
        public void deposit(double amount)
        {
            if (m_status == Status.ACTIVE)
                throw new Exception("Account is frozen");
            balance += amount;
        }
        public void frozen()
        {
            m_status = Status.FROZEN;
        }
        public void active()
        {
            m_status = Status.ACTIVE;
        }
        public static void Main()
        {
            System.Console.WriteLine("Start Banking");
        }

    }
}
