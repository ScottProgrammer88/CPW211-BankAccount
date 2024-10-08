﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using System.Dynamic;

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
        [DataRow(100, 50)]
        [DataRow(100, .99)]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance(double initialDeposit,
                                                                double withdrawalAmount)
        {
            // Arrange
            double expectedBalance = initialDeposit - withdrawalAmount;
            acc.Deposit(initialDeposit);

            // Act
            double returnedBalance = acc.Withdraw(withdrawalAmount);

            // Assert
            Assert.AreEqual(expectedBalance, returnedBalance); // Verify that the Withdraw method decreases the balance by the correct amount.
        }


        /// <summary>
        /// public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double withdrawAmount): This is the test method itself. 
        /// It takes a double parameter named withdrawAmount, which will be filled by the values from the DataRow attributes.
        /// The purpose of this method is to test whether the Withdraw method in the Account class correctly throws an
        /// ArgumentOutOfRangeException when the withdrawAmount is zero or negative. Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Withdraw(withdrawAmount));
        /// This line asserts that calling the Withdraw method with the provided withdrawAmount will throw an ArgumentOutOfRangeException.The Assert.ThrowsException<T> method
        /// is used to verify that a specific type of exception (ArgumentOutOfRangeException) is thrown when the code inside the lambda expression (() => acc.Withdraw(withdrawAmount)) is executed.
        /// This line checks if the Withdraw method crashes correctly when you try to take out zero or a negative amount of money. If it doesn’t throw the right error, the test will fail, meaning there’s a bug in your code.
        /// </summary>
        /// <param name="withdrawAmount"></param>
        [TestMethod]
        [DataRow(0)] // Test a zero withdrawal amount
        [DataRow(-.01)] // Test a negative withdrawal amount
        [DataRow(-1000)]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double withdrawAmount) // The data that is passed in from the DataRow attribute.
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Withdraw(withdrawAmount)); // Verify that the Withdraw method throws an ArgumentOutOfRangeException.  
        }

        [TestMethod]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            // Arrange
            double withdrawAmount = 100;
            
            // Assert
            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmount)); // Verify that the Withdraw method throws an ArgumentException.
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

        [TestMethod]
        public void Owner_SetAsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => acc.Owner = null); // Verify that the Owner property throws an ArgumentNullException.   
        }

        [TestMethod]
        public void Owner_SetAsWhiteSpaceOrEmptyString_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = String.Empty);
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = "   ");
        }

        [TestMethod]
        [DataRow("Joe")]
        [DataRow("Joe Ortiz")]
        [DataRow("Joseph Jo Smithfield")]
        public void Owner_SetAsUpTo20Characters_SetsSuccessfully(string ownerName)
        {
            acc.Owner = ownerName;
            Assert.AreEqual(ownerName, acc.Owner);
        }

        [TestMethod]
        [DataRow("Joseph Jo Smithfield Jr.")]
        [DataRow("Joe 3rd")]
        [DataRow("#$%$")]
        public void Owner_InvalidOwnerName_ThrowsArgumentException(string ownerName)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = ownerName);
        }
    }
}