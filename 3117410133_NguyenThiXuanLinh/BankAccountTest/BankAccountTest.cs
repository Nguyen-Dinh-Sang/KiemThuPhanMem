using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3117410133_NguyenThiXuanLinh;

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
        public void TestRutLonHonTaiKhoan()
        {
            double charge = 200;

            //khai báo Account, tiền ban đầu, đăng nhập
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            bankAccount.login(133, "xuanlinh");
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
                StringAssert.Contains(e.Message, "Debit amount exceeds balance");
                TestContext.WriteLine("Result is correct.");
            }
        }

        [TestMethod]
        public void TestRutHopLeKhiTaiKhoanBiDongBang()
        {
            double charge = 100;

            //khai báo Account, tiền ban đầu, tài khoản bị khóa, đăng nhập
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            bankAccount.login(133, "xuanlinh");
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
        public void TestRutSoTienAm()
        {
            double charge = -200;

            //khai báo Account, đăng nhâp, tiền ban đầu
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            bankAccount.login(133, "xuanlinh");
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
        public void TestRutTienHopLe()
        {
            double charge = 100;

            //khai báo Account, tiền ban đầu, đăng nhập
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            bankAccount.login(133, "xuanlinh");
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
        public void TestTienNapHopLe()
        {
            double amount = 100;

            //khai báo Account, đăng nhập
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            bankAccount.login(133, "xuanlinh");
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
        public void TestNapTienKhiTaiKhoanBiKhoa()
        {
            double amount = 100;

            //khai báo Account,đăn nhập, tài khoản bị khóa
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            bankAccount.login(133, "xuanlinh");
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
        public void TestTienNapAm()
        {
            double amount = -100;

            //khai báo Account, đăng nhập
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            bankAccount.login(133, "xuanlinh");
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
        public void TestKhongDangNhapNapTien()
        {
            double amount = 100;

            //khai báo Account
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
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
        public void TestLogInLogOut()
        {
            //khai báo Account, login
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            bankAccount.login(133, "xuanlinh");
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
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            //

            TestContext.WriteLine("Status: {0}", bankAccount.status());


            try
            {
                bankAccount.login(133, "xuanlinh");
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
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            //

            TestContext.WriteLine("Status: {0}", bankAccount.status());


            try
            {
                if (bankAccount.login(133, "xuanlinh123") == false)
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
            //khai báo Account.
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            //

            TestContext.WriteLine("Status: {0}", bankAccount.status());


            try
            {
                bankAccount.login(1234, "xuanlinh");
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
            //khai báo Account, năm trừ 6
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            bankAccount.created_year -= 6;
            //

            TestContext.WriteLine("Create year: {0}", bankAccount.created_year);


            try
            {
                bankAccount.login(133, "xuanlinh");
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
            //khai báo Account, đăng nhập sai 5 lần
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            //

            TestContext.WriteLine("Status: {0}", bankAccount.status());
            bankAccount.login(133, "xuanlinhxinhdep");
            bankAccount.login(133, "xuanlinhxinhdep");
            bankAccount.login(133, "xuanlinhxinhdep");
            bankAccount.login(133, "xuanlinhxinhdep");
            bankAccount.login(133, "xuanlinhxinhdep");

            try
            {
                bankAccount.login(133, "xuanlinh");
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
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            bankAccount.frozen();
            //

            TestContext.WriteLine("Status: {0}", bankAccount.status());


            try
            {

                if (bankAccount.login(133, "xuanlinh") == false)
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
            //khai báo Account, đăng nhập sai 4 lần
            BankAccount bankAccount = new BankAccount(133, "xuanlinh");
            //

            TestContext.WriteLine("Status: {0}", bankAccount.status());
            bankAccount.login(133, "xuanlinhxinhdep");
            bankAccount.login(133, "xuanlinhxinhdep");
            bankAccount.login(133, "xuanlinhxinhdep");
            bankAccount.login(133, "xuanlinhxinhdep");

            try
            {
                if (bankAccount.login(133, "xuanlinh") == true)
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
            bankAccountTest.TestRutLonHonTaiKhoan();
            bankAccountTest.TestRutHopLeKhiTaiKhoanBiDongBang();
            bankAccountTest.TestRutSoTienAm();
            bankAccountTest.TestRutTienHopLe();
            bankAccountTest.TestTienNapHopLe();
            bankAccountTest.TestNapTienKhiTaiKhoanBiKhoa();
            bankAccountTest.TestTienNapAm();
            bankAccountTest.TestKhongDangNhapNapTien();
            bankAccountTest.TestLogInLogOut();
            bankAccountTest.TestLogInBinhThuong();
            bankAccountTest.TestLogInSaiMatKhau();
            bankAccountTest.TestLogInQua5Nam();
            bankAccountTest.TestLogInSaiQua5Lan();
            bankAccountTest.TestLogInTaiKhoanBiDongBang();
            bankAccountTest.TestLogIn4LanSaiLan5Dung();
            Console.ReadLine();
        }
    }
}
