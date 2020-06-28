using System;
using Banking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankingTest
{
    [TestClass]
    public class BankingUnitTest
    {

        [TestMethod]
        public void login_correctAccountInfo() // Đăng nhập với tài khoản và mật khẩu đều chính xác
        {

            BankAccount account = new BankAccount(1, "nhat");
            try
            {
                Assert.IsTrue(account.login(1, "nhat")); // assert kiểm tra nếu phương thức trả về True là đăng nhập thành công
            }
            catch (AssertFailedException e)
            {
                return;
            }
            catch (Exception e)
            {
                Assert.Fail("Phương thức có kiểu trả về là boolen nhưng lại không trả về giá trị nào");
            }
        }
        [TestMethod]
        public void login_correctAccountInfo_butFrozen() // Đăng nhập với tài khoản và mật khẩu chính xác nhưng tài khoản bị đóng băng
        {
            BankAccount account = new BankAccount(1, "nhat");
            account.frozen();
            try
            {
                Assert.IsFalse(account.login(1, "nhat")); // assert kiểm tra nếu phương thức trả về False là đăng nhập thất bại do đã bị đóng băng
            }
            catch (AssertFailedException e)
            {
                return;
            }
            catch (Exception e)
            {
                Assert.Fail("Phương thức có kiểu trả về là boolen nhưng lại không trả về giá trị nào");
            }

        }
        [TestMethod]
        public void login_correctAccountInfo_butAccountOver5Year() // Đăng nhập với tài khoản và mật khẩu chính xác nhưng tài khoản đã quá 5 năm
        {
            BankAccount account = new BankAccount(1, "nhat");
            account.created_year += 5;
            try
            {
                Assert.IsFalse(account.login(1, "nhat"));
            }
            catch (AssertFailedException e)
            {
                return;
            }
            catch (Exception e)
            {
                Assert.Fail("Phương thức có kiểu trả về là boolen nhưng lại không trả về giá trị nào");
            }
        }
        [TestMethod]
        public void login_incorrectAccountInfo_Password() // Đăng nhập sai mật khẩu
        {
            BankAccount account = new BankAccount(1, "nhatdungpass");
            try
            {
                Assert.IsFalse(account.login(1, "nhatsaipass"));
            }
            catch (AssertFailedException e)
            {
                return;
            }
            catch (Exception e)
            {
                Assert.Fail("Phương thức có kiểu trả về là boolen nhưng lại không trả về giá trị nào");
            }
        }
        [TestMethod]
        public void login_incorrectAccountInfo_Id() // Đăng nhập sai id
        {
            BankAccount account = new BankAccount(1, "nhatdungpass");
            try
            {
                Assert.IsFalse(account.login(2, "nhatdungpass"));
            }
            catch (AssertFailedException e)
            {
                return;
            }
            catch (Exception e)
            {
                Assert.Fail("Phương thức có kiểu trả về là boolen nhưng lại không trả về giá trị nào");
            }

        }
        [TestMethod]
        public void login_incorrectAccountInfo_over5time()// Đăng nhập sai mật khẩu quá 5 lần tức sai lần thứ 6
        {
            BankAccount account = new BankAccount(1, "nhat");
            account.active();
            account.login(1, "nhat1");
            account.login(1, "nhat2");
            account.login(1, "nhat3");
            account.login(1, "nhat4");
            account.login(1, "nhat5");
            account.login(1, "nhat6");
            try
            {
                Assert.IsFalse(account.login(1, "nhat"));
            }
            catch (AssertFailedException e)
            {
                return;
            }
            catch (Exception e)
            {
                Assert.Fail("Phương thức có kiểu trả về là boolen nhưng lại không trả về giá trị nào");
            }

        }
        [TestMethod]
        public void login_incorrectAccountInfo_notOver5timeThenIncorrectAgain() // Đăng nhập sai mật khẩu không quá 5 lần sau đó lại sai
        {
            BankAccount account = new BankAccount(1, "nhat");
            account.active();
            account.login(1, "nhat1");
            account.login(1, "nhat2");
            account.login(1, "nhat3");
            account.login(1, "nhat4");
            account.login(1, "nhat5");
            account.login(1, "nhat"); // lần này đăng nhập thành công
            account.logout();
            account.login(1, "nhat6"); // lần này lại sai để xem account có bị đóng băng không
            try
            {
                Assert.IsTrue(account.login(1, "nhat"));
            }
            catch (AssertFailedException e)
            {
                return;
            }
            catch (Exception e)
            {
                Assert.Fail("Phương thức có kiểu trả về là boolen nhưng lại không trả về giá trị nào");
            }
        }
        [TestMethod]
        public void debit_validAmount() //rút tiền với số tiền hợp lệ
        {
            double debitAmount = 10.121;
            BankAccount account = new BankAccount(1, "nhat");
            account.login(1, "nhat");
            account.deposit(debitAmount);  // vì tài khoản chưa có tiền nên ta phải deposit trước
            double balanceBeforeDebit = account.getBalance();
            account.debit(debitAmount);
            double balanceAfterDebit = account.getBalance();
            try
            {
                Assert.AreEqual(balanceBeforeDebit - debitAmount, balanceAfterDebit);
            }
            catch (AssertFailedException e)
            {
                System.Console.WriteLine(e.Message);
                Assert.Fail("Số tiền trước khi rút trừ cho số tiền rút phải bằng số tiền sau khi rút");
            }

        }
        [TestMethod]
        public void debit_validAmount_butEmptyBalance() //rút tiền với số tiền hợp lệ nhưng tài khoản không có tiền
        {
            double debitAmount = 10.121;
            BankAccount account = new BankAccount(1, "nhat");
            account.login(1, "nhat");
            double balanceBeforeDebit = account.getBalance();
            account.debit(balanceBeforeDebit); // Rút toàn bộ tiền hiện tại tài khoản đang có

            try
            {
                account.debit(debitAmount); // Rút tiếp 1 số tiền khác nhưng hiện tại tài khoản đã hết tiền

            }
            catch (ArgumentOutOfRangeException e)
            {
                System.Console.WriteLine(e.Message);
                return;
            }
            Assert.Fail("Rút tiền khi tài khoản không có tiền mà không báo lỗi");

        }
        [TestMethod]
        public void debit_invalidAmount_lessThenZero()// rút tiền với số tiền không hợp lệ - số tiền bị âm
        {
            double debitAmount = -1;
            BankAccount account = new BankAccount(1, "nhat");
            account.login(1, "nhat");
            try
            {
                account.debit(debitAmount);

            }
            catch (ArgumentOutOfRangeException e)
            {
                System.Console.WriteLine(e.Message);
                return;
            }
            Assert.Fail("Rút số tiền nhỏ hơn không nhưng phương thức lại không báo lỗi");
        }
        [TestMethod]
        public void debit_whenAccountFrozen() // Thực hiện rút tiền khi tài khoản đã bị đóng băng
        {
            double debitAmount = 10;
            BankAccount account = new BankAccount(1, "nhat");
            account.login(1, "nhat");
            account.deposit(debitAmount);
            account.frozen();
            try
            {
                account.debit(debitAmount);
            }
            catch (Exception e)
            {

                System.Console.WriteLine(e.Message);
                return;
            }
            Assert.Fail("Tài khoản đã bị đóng băng nhưng vẫn có thể rút tiền mà không báo lỗi");
        }
        [TestMethod]
        public void deposit_invalidAmount_lessThanZero() // Nạp tiền với số tiền không hợp lệ - số tiền bị âm
        {
            double depositAmount = -100;
            BankAccount account = new BankAccount(1, "nhat");
            account.login(1, "nhat");
            try
            {
                account.deposit(depositAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {

                System.Console.WriteLine(e.Message);
                return;
            }
            Assert.Fail("Nạp số bị âm nhưng phương thức không báo lỗi ");

        }
        [TestMethod]
        public void deposit_validAmount() // Nạp tiền với số tiền hợp lệ
        {
            double depositAmount = 123.123;
            BankAccount account = new BankAccount(1, "nhat");
            account.login(1, "nhat");
            double balanceBeforeDeposit = account.getBalance();
            account.deposit(depositAmount);
            double balanceAfterDeposit = account.getBalance();
            double expectBalance = balanceBeforeDeposit + depositAmount;

            Assert.AreEqual(expectBalance, balanceAfterDeposit);

        }

    }
}
