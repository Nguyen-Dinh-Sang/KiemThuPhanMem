using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Numerals;

namespace UnitTestNumerals
{
    [TestClass]
    public class NumberalsTest
    {
        private TestContext testContextInstance; 
        public TestContext TestContext
        {
            get { return testContextInstance;  }

            set { testContextInstance = value;  }
        }

        public void TestSumNumbers (double firstNumber, double secondNumber, double expectedValue)
        {
            Program obj = new Program();

            double result = obj.sum(firstNumber, secondNumber);

            try
            {
                Assert.AreEqual(expectedValue, result);
                TestContext.WriteLine("Result is correct."); 
            }
            catch
            {
                TestContext.WriteLine("The expected value is {0} but the actual value is {1}.",
                    expectedValue, result);
            }

        }
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "F:\\Documents\\N3\\HK2\\KiemThuPhamMem\\ThucHanh\\Numerals\\UnitTestNumerals\\TestData.csv",
            "TestData#csv",
            DataAccessMethod.Sequential),
            DeploymentItem("TestData.csv")]
        [TestMethod]
        public void TestMethod1()
        {
            double firstNumber = Convert.ToDouble(testContextInstance.DataRow["FirstNumber"]);
            double secondNumber = Convert.ToDouble(testContextInstance.DataRow["SecondNumber"]);
            double expectedValue = Convert.ToDouble(testContextInstance.DataRow["Total"]);

            TestContext.WriteLine("{0} + {1} = {2}", firstNumber, secondNumber, expectedValue);

            TestSumNumbers(firstNumber, secondNumber, expectedValue);
        }

        public static void Main()
        {
            NumberalsTest numberalsTest = new NumberalsTest();
            numberalsTest.TestMethod1();
            Console.ReadLine();
        }
    }
}
