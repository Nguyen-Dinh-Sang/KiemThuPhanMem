using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3117410210_NguyenDinhSang;

namespace BankAccountTest
{
    [TestClass]
    public class BankAccountTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void TestTienRutLonHonTienTaiKhoan()
        {
            double charge = 200;

            //khai báo Account, login, tiền ban đầu
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            bankAccount.login(12345, "sangdeptrai");
            bankAccount.frozen();
            bankAccount.deposit(100);
            bankAccount.active();
            //

            TestContext.WriteLine("Balance: {0} - Charge: {1}", bankAccount.getBalance(), charge);

            try
            {
                bankAccount.debit(charge);
            }
            catch (ArgumentOutOfRangeException e)
            {
                //assert
                StringAssert.Contains(e.Message, "Debit amount exceeds balance");
                TestContext.WriteLine("Result is correct.");
            }
        }

        [TestMethod]
        public void TestTienRutHopLeTaiKhoanBiKhoa()
        {
            double charge = 100;

            //khai báo Account, login, tiền ban đầu, tài khoản bị khóa
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            bankAccount.login(12345, "sangdeptrai");
            bankAccount.frozen();
            bankAccount.deposit(200);
            //

            TestContext.WriteLine("Balance: {0} - Charge: {1} - Status: {2}", bankAccount.getBalance(), charge, bankAccount.status());


            try
            {
                bankAccount.debit(charge);
            }
            catch (Exception e)
            {
                //assert
                StringAssert.Contains(e.Message, "Account is frozen");
                TestContext.WriteLine("Result is correct.");
            }
        }

        [TestMethod]
        public void TestTienRutAm()
        {
            double charge = -200;

            //khai báo Account, login, tiền ban đầu
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            bankAccount.login(12345, "sangdeptrai");
            bankAccount.frozen();
            bankAccount.deposit(100);
            bankAccount.active();
            //

            TestContext.WriteLine("Balance: {0} - Charge: {1}", bankAccount.getBalance(), charge);


            try
            {
                bankAccount.debit(charge);
            }
            catch (ArgumentOutOfRangeException e)
            {
                //assert
                StringAssert.Contains(e.Message, "Charge less than zero");
                TestContext.WriteLine("Result is correct.");
            }
        }

        [TestMethod]
        public void TestTienRutHopLe()
        {
            double charge = 100;

            //khai báo Account, login, tiền ban đầu
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            bankAccount.login(12345, "sangdeptrai");
            bankAccount.frozen();
            bankAccount.deposit(200);
            bankAccount.active();
            //

            TestContext.WriteLine("Balance: {0} - Charge: {1}", bankAccount.getBalance(), charge);


            try
            {
                bankAccount.debit(charge);
                if (bankAccount.getBalance() == 100)
                {
                    TestContext.WriteLine("Result is correct.");
                }
                else TestContext.WriteLine("Test Failed.");
            }
            catch (ArgumentOutOfRangeException e)
            {
                //assert
                TestContext.WriteLine("Test Failed.");
            }
        }

        [TestMethod]
        public void TestNapTienHopLe()
        {
            double amount = 100;

            //khai báo Account, login
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            bankAccount.login(12345, "sangdeptrai");
            //

            TestContext.WriteLine("Balance: {0} - Amount: {1} - Status: {2}", bankAccount.getBalance(), amount, bankAccount.status());


            try
            {
                bankAccount.deposit(amount);
                if (bankAccount.getBalance() == 100)
                    TestContext.WriteLine("Result is correct.");
            }
            catch (Exception e)
            {
                //assert
                StringAssert.Contains(e.Message, "Account is frozen");
                TestContext.WriteLine("Test Failed.");
            }
        }

        [TestMethod]
        public void TestNapTienTaiKhoanBiKhoa()
        {
            double amount = 100;

            //khai báo Account, tiền ban đầu, tài khoản bị khóa
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            bankAccount.login(12345, "sangdeptrai");
            bankAccount.frozen();
            //

            TestContext.WriteLine("Balance: {0} - Amount: {1} - Status: {2}", bankAccount.getBalance(), amount, bankAccount.status());


            try
            {
                bankAccount.deposit(amount);
                if (bankAccount.getBalance() == 100)
                    TestContext.WriteLine("Test Failed.");
            }
            catch (Exception e)
            {
                //assert
                StringAssert.Contains(e.Message, "Account is frozen");
                TestContext.WriteLine("Result is correct.");
            }
        }

        [TestMethod]
        public void TestNapTienAm()
        {
            double amount = -100;

            //khai báo Account, login
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            bankAccount.login(12345, "sangdeptrai");
            //

            TestContext.WriteLine("Balance: {0} - Amount: {1} - Status: {2}", bankAccount.getBalance(), amount, bankAccount.status());


            try
            {
                bankAccount.deposit(amount);
                if (bankAccount.getBalance() == -100)
                    TestContext.WriteLine("Test Failed.");
            }
            catch (Exception e)
            {
                //assert
                TestContext.WriteLine("Result is correct.");
            }
        }

        [TestMethod]
        public void TestNapTienKhongDangNhap()
        {
            double amount = 100;

            //khai báo Account
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            //

            TestContext.WriteLine("Balance: {0} - Amount: {1} - Status: {2}", bankAccount.getBalance(), amount, bankAccount.status());


            try
            {
                bankAccount.deposit(amount);
                if (bankAccount.getBalance() == 0)
                    TestContext.WriteLine("Result is correct.");
            }
            catch (Exception e)
            {
                //assert
                TestContext.WriteLine("Test Failed.");
            }
        }

        [TestMethod]
        public void TestLogOut()
        {
            //khai báo Account, login
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            bankAccount.login(12345, "sangdeptrai");
            //

            TestContext.WriteLine("Status: {0}", bankAccount.status());


            try
            {
                bankAccount.logout();
                if (bankAccount.status() == Status.LOGGED_OUT)
                    TestContext.WriteLine("Result is correct.");
            }
            catch (Exception e)
            {
                //assert
                TestContext.WriteLine("Test Failed.");
            }
        }

        [TestMethod]
        public void TestLogInBinhThuong()
        {
            //khai báo Account
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            //

            TestContext.WriteLine("Status: {0}", bankAccount.status());


            try
            {
                bankAccount.login(12345, "sangdeptrai");
                if (bankAccount.status() == Status.LOGGED_IN)
                    TestContext.WriteLine("Result is correct.");
            }
            catch (Exception e)
            {
                //assert
                TestContext.WriteLine("Test Failed.");
            }
        }

        [TestMethod]
        public void TestLogInSaiMatKhau()
        {
            //khai báo Account
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            //

            TestContext.WriteLine("Status: {0}", bankAccount.status());


            try
            {
                if (bankAccount.login(12345, "sangdeptrainhat") == false)
                {
                    TestContext.WriteLine("Result is correct.");
                }
                if (bankAccount.status() == Status.LOGGED_IN)
                    TestContext.WriteLine("Test Failed.");
            }
            catch (Exception e)
            {
                //assert
            }
        }

        [TestMethod]
        public void TestLogInSaiID()
        {
            //khai báo Account
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            //

            TestContext.WriteLine("Status: {0}", bankAccount.status());


            try
            {
                bankAccount.login(123, "sangdeptrai");
                if (bankAccount.status() == Status.LOGGED_IN)
                    TestContext.WriteLine("Test Failed.");
            }
            catch (Exception e)
            {
                //assert
                StringAssert.Contains(e.Message, "Wrong ID");
                TestContext.WriteLine("Result is correct.");
            }
        }

        [TestMethod]
        public void TestLogInQua5Nam()
        {
            //khai báo Account, số năm -7 => 2013
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            bankAccount.created_year -= 7;
            //

            TestContext.WriteLine("Create year: {0}", bankAccount.created_year);


            try
            {
                bankAccount.login(12345, "sangdeptrai");
                if (bankAccount.status() == Status.LOGGED_IN)
                    TestContext.WriteLine("Test Failed.");
            }
            catch (Exception e)
            {
                //assert
                TestContext.WriteLine("Result is correct.");
            }
        }

        [TestMethod]
        public void TestLogInSaiQua5Lan()
        {
            //khai báo Account
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            //

            TestContext.WriteLine("Status: {0}", bankAccount.status());
            bankAccount.login(12345, "sangdeptrainhat");
            bankAccount.login(12345, "sangdeptrainhat");
            bankAccount.login(12345, "sangdeptrainhat");
            bankAccount.login(12345, "sangdeptrainhat");
            bankAccount.login(12345, "sangdeptrainhat");

            try
            {
                bankAccount.login(12345, "sangdeptrai");
                if (bankAccount.status() == Status.LOGGED_IN)
                    TestContext.WriteLine("Test Failed.");
            }
            catch (Exception e)
            {
                //assert
                TestContext.WriteLine("Result is correct.");
            }
        }

        [TestMethod]
        public void TestLogInTaiKhoanBiDongBang()
        {
            //khai báo Account, tài khoản bị khóa
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            bankAccount.frozen();
            //

            TestContext.WriteLine("Status: {0}", bankAccount.status());


            try
            {

                if (bankAccount.login(12345, "sangdeptrai") == false)
                    TestContext.WriteLine("Result is correct.");
            }
            catch (Exception e)
            {
                //assert
                TestContext.WriteLine("Test Failed.");
            }
        }

        [TestMethod]
        public void TestLogIn4LanSaiLan5Dung()
        {
            //khai báo Account
            BankAccount bankAccount = new BankAccount(12345, "sangdeptrai");
            //

            TestContext.WriteLine("Status: {0}", bankAccount.status());
            bankAccount.login(12345, "sangdeptrainhat");
            bankAccount.login(12345, "sangdeptrainhat");
            bankAccount.login(12345, "sangdeptrainhat");
            bankAccount.login(12345, "sangdeptrainhat");

            try
            {
                if (bankAccount.login(12345, "sangdeptrai") == true)
                    TestContext.WriteLine("Result is correct.");
            }
            catch (Exception e)
            {
                TestContext.WriteLine("Test Failed.");
            }
        }

        static void Main()
        {
            BankAccountTest bankAccountTest = new BankAccountTest();
            //1
            bankAccountTest.TestTienRutLonHonTienTaiKhoan();
            //2
            bankAccountTest.TestTienRutHopLeTaiKhoanBiKhoa();
            //3
            bankAccountTest.TestTienRutAm();
            //4
            bankAccountTest.TestTienRutHopLe();
            //5
            bankAccountTest.TestNapTienHopLe();
            //6
            bankAccountTest.TestNapTienTaiKhoanBiKhoa();
            //7
            bankAccountTest.TestNapTienAm();
            //8
            bankAccountTest.TestNapTienKhongDangNhap();
            //9
            bankAccountTest.TestLogOut();
            //10
            bankAccountTest.TestLogInBinhThuong();
            //11
            bankAccountTest.TestLogInSaiMatKhau();
            //12
            bankAccountTest.TestLogInQua5Nam();
            //13
            bankAccountTest.TestLogInSaiQua5Lan();
            //14
            bankAccountTest.TestLogInTaiKhoanBiDongBang();
            //15
            bankAccountTest.TestLogIn4LanSaiLan5Dung();
            Console.ReadLine();
        }
    }
}
