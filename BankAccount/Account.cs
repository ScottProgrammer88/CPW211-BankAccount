﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single customers bank account.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Creates a new account instance with the specified owner, and a balance of zero. 
        /// Since we are not taking in a balance parameter, Double defaults to 0, 
        /// we are assuming that the account is created with a zero balance.
        /// </summary>
        /// <param name="accOwner">The customer full name that owns the account</param>
        public Account(string accOwner)
        {
            Owner = accOwner; 
        }
        /// <summary>
        /// This defines a public property named Owner of type string with both a public getter and setter.
        /// The account holders full name (first and last)
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// The current balance of the account.
        /// This defines a public property named Balance of type double with a public getter but a private
        /// setter. This means external code can read the value, but only code within the class can change it.
        /// This provides a level of encapsulation, protecting the data from accidental modification.
        /// </summary>
        public double Balance { get; private set; } // private set means that the Balance property can only be set from within the Account class.

        /// <summary>
        /// Deposits the specified amount into the account. Returns the new balance
        /// </summary>
        /// <param name="amt">The positive amount to deposit</param>
        /// <returns>The new balance after the deposit</returns>
        public double Deposit(double amt)
        {
            if (amt <= 0)
            {
                throw new ArgumentOutOfRangeException($"The {nameof(amt)} must be must be more than 0");
            }

            Balance += amt;
            return Balance;
        }

        /// <summary>
        /// Withdraws the specified amount from the balance and returns the balance.
        /// The Withdraw method is used to withdraw money from the account.
        /// </summary>
        /// <param name="amount">The positive amount of money to be taken from the balance</param>
        /// <returns>The new balance after the withdrawal</returns>
        public double Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new ArgumentException($"{nameof(amount)} cannot be greater than {nameof(Balance)}");
            }

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amount)} must be greater than 0");
            }
            Balance -= amount; // subtract the amount from the balance
            return Balance; // return the new balance after the withdrawal
        }
    }
}
