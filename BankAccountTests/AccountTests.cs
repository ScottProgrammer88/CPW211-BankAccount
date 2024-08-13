using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BankAccount.Tests
{
    /// <summary>
    /// This attribute indicates that the class contains test methods that you want to run. 
    /// This tells the test framework this class is used for testing.
    /// </summary>
    [TestClass()] 
    public class AccountTests
    {
        // Private Field (private Account acc;): This line declares a private field acc of type Account within
        // the AccountTests class. A private field is a variable that can only be accessed within the class it is
        // declared in, and it stores an instance of the Account class. 
        private Account acc;

        /// <summary>
        /// CreateDefaultAccount Method (private void CreateDefaultAccount()): This method creates a new instance
        /// of the Account class, assigning it to the acc field. The method sets up a default account with the owner
        /// "John Doe" before each test runs, ensuring that every test starts with a fresh, consistent state.
        /// </summary>
        [TestInitialize] // This attribute indicates that the method will be run before each test in the class.
        public void CreateDefaultAccount()
        {
            acc = new Account("John Doe");
        }

       /// <summary>
       /// This attribute indicates that the method is a test method. Unit tests are methods that test
       /// a single method or function in your code. Unit tests should pass or fail based on the behavior
       /// of the method you are testing, and should be void.
       /// </summary>
       [TestMethod()]
        [DataRow(100)]
        [DataRow(.01)] // smallest possible deposit
        [DataRow(1.99)] 
        [DataRow(9_999.99)] // largest possible deposit
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount)
        {
            // Look at Deposit method in Account.cs, and determine what to test and what is the expected result.
            // Write a test code in this test method that verifies that the Deposit method adds the correct amount to the balance.
            // We need a bank account object to test. Create an instance of the Account class to test.

            acc.Deposit(depositAmount); 

            Assert.AreEqual(depositAmount, acc.Balance);  // Verify that the Deposit method adds the correct amount to the balance.
           // Assert.Fail(); // This test will fail. To get it to pass, you need to implement the Deposit method in the Account class.
        }

        [TestMethod()]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // AAA - Arrange, Act, Assert
            // Arrange - Create an instance of the Account class to test. Set up the variables you need to test the method.
            // Act - Call the Deposit method with a positive amount.
            // Assert - Verify that the Deposit method returns the correct balance.

            double depositAmount = 100; 
            double expectedReturn = 100; 

            // Act - Call the Deposit method with a positive amount.
            double returnValue = acc.Deposit(depositAmount);

            // Assert - Verify that the Deposit method returns the correct balance.
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod()]
        [DataRow(-1)] // Test a negative deposit amount
        [DataRow(0)] // Data row attribute allows you to run the same test with different data.
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            // AAA - Arrange, Act, Assert
            // Arrange - Create an instance of the Account class to test. Set up the variables you need to test the method.
            // Act - Call the Deposit method with a zero or negative amount.
            // Assert - Verify that the Deposit method throws an ArgumentOutOfRangeException.

             
            // Act - Call the Deposit method with a zero or negative amount.
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Deposit(invalidDepositAmount));
        }

        [TestMethod]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance()
        {
            Assert.Fail();
        }

        [TestMethod]
        [DataRow(0)] // Test a zero withdrawal amount
        [DataRow(-.01)] // Test a negative withdrawal amount
        [DataRow(-1000)]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Withdraw_PositiveAmount_DecreasesBalance()
        {
            // Arrange
            double initialDeposit = 100;
            double withdrawalAmount = 50;
            double expectedBalance = initialDeposit - withdrawalAmount;

            // Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawalAmount);

            double actualBalance = acc.Balance; // this needs to happen after the Withdraw method is called. To show the new balance.
            
            // Assert
            Assert.AreEqual(expectedBalance, actualBalance); // Verify that the Withdraw method decreases the balance by the correct amount.
        }
    }
}


// withdrawing a positive amount - returns an updated balance
// withdrawing a negative amount - throws ArgumentOutOfRangeException
// withdrawing more than the available balance - ArgumentException  
// withdrawing 0 - throws ArgumentOutOfRangeException