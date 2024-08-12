using System;
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
        /// Deposits the specified amount into the account.
        /// </summary>
        /// <param name="amt">The positive amount to deposit</param>
        public void Deposit(double amt)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Withdraws the specified amount from the balance.
        /// The Withdraw method is used to withdraw money from the account.
        /// </summary>
        /// <param name="amt">The positive amount of money to be taken from the balance</param>
        public void Withdraw(double amt)
        {
            throw new NotImplementedException();
        }
    }
}
