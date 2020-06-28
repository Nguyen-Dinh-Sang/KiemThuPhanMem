using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS; 

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {

            //arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;

            BankAccount account = new BankAccount("Mr. Brayan Walton", beginningBalance, 123, "abc123");
           
            //act
            account.Debit(debitAmount);

            //assert 

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance, 123, "abc123");
           
            // act  
            account.Debit(debitAmount);

            // assert is handled by ExpectedException  
        }

        [TestMethod]  
        public void Debit_WhenAmountIMoreThanBalance_ShouldThrowArgumentOutOfRang()
        {
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Brayan Walton", beginningBalance, 123, "abc123");
            
            try
            {
                account.Debit(debitAmount);
            }catch(ArgumentOutOfRangeException e)
            {
                //assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown");
        }

        [TestMethod]
        public void TestDebit_WhenFrozenAccount()
        {
            double balance = 100.00; 
            BankAccount account = new BankAccount("Mr. Brayan Walton", balance, 123, "abc123");

            account.Login(123, "a");
            account.Login(123, "ab");
            account.Login(123, "aacv");
            account.Login(123, "aa");
            account.Login(123, "aq");
            account.Login(123, "as");

           try
            {
                Assert.AreEqual(account.status(), Status.FROZEN);
            }
            catch(Exception e)
            {
                StringAssert.Contains(e.Message, "Account is frozen");
            }
        }

        [TestMethod]
        public void TestLogin_Success()
        {
            double balance = 100.00;
            BankAccount account = new BankAccount("Mr. Brayan Walton", balance, 123, "abc123");

            Assert.IsTrue(account.Login(123, "abc123"));
        }
    }
}
