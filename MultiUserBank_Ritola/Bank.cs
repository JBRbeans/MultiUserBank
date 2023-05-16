using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiUserBank_Ritola
{
	public class Bank
	{
		private const decimal InitialBankBalance = 10000;
		private decimal bankBalance;
		private List<Customer> customers;
		private Customer loggedInUser;

		public decimal BankBalance => bankBalance;

		public Bank()
		{
			bankBalance = InitialBankBalance;
			customers = new List<Customer>();

			// Add customers to the bank
			customers.Add(new Customer("jlennon", "johnny", 1250));
			customers.Add(new Customer("pmccartney", "pauly", 2500));
			customers.Add(new Customer("gharrison", "georgy", 3000));
			customers.Add(new Customer("rstarr", "ringoy", 1000));

			loggedInUser = null;
		}


		public void MenuInformation()
		{
			Console.WriteLine("-Type a number and press the 'Enter' key to select an option-");
			Console.WriteLine("-0: -Exit the application-");
			Console.WriteLine("-1: -Display your current balance-");
			Console.WriteLine("-2: -Withdraw an amount from your balance-");
			Console.WriteLine("-3: -Deposit an amount into your balance-");
			Console.WriteLine("-4: -Log out of the current account-");
			Console.WriteLine("-5: -Log in-");

		}
		public bool Login(string username, string password)
		{
			Customer customer = GetCustomerByUsername(username);
			if (customer != null && customer.Password == password)
			{
				loggedInUser = customer;
				Console.WriteLine("Logged in as: {0}", loggedInUser.Username);
				return true;
			}

			return false;
		}
		

		public void Logout()
		{
			if (loggedInUser != null)
			{
				Console.WriteLine("Logged out.");
				loggedInUser = null;
			}
		}
		public bool IsSomeoneLoggedIn()
		{
			if (loggedInUser == null)
			{
				return false;
			}
			if (loggedInUser != null)
			{
				return true;
			}
			return true;
			
		}
		public void DisplayBankBalance()
		{
			Console.WriteLine("Bank balance: {0:C}", bankBalance);
		}

		public void DisplayUserBalance()
		{
			if (loggedInUser != null)
			{
				decimal balance = loggedInUser.GetBalance();
				Console.WriteLine("Your balance: {0:C}", balance);
			}
		}

		public void Deposit(decimal amount)
		{
			if (loggedInUser != null)
			{
				loggedInUser.Deposit(amount);
				Console.WriteLine("Deposit successful. Current balance: {0:C}", loggedInUser.GetBalance());
			}
		}

		public decimal Withdraw(decimal amount)
		{
			if (loggedInUser != null)
			{
				decimal withdrawalAmount = Math.Min(amount, loggedInUser.GetBalance());
				loggedInUser.Withdraw(withdrawalAmount);
				Console.WriteLine("Withdrawal successful. Amount withdrawn: {0:C}, Current balance: {1:C}", withdrawalAmount, loggedInUser.GetBalance());
				return withdrawalAmount;
			}

			return 0;
		}

		private Customer GetCustomerByUsername(string username)
		{
			return customers.Find(customer => customer.Username == username);
		}


		private class Customer
		{
			public string Username { get; }
			public string Password { get; }
			private decimal balance;


			public Customer(string username, string password, decimal initialBalance)
			{
				Username = username;
				Password = password;
				balance = initialBalance;
			}

			public decimal GetBalance()
			{
				return balance;
			}

			public void Deposit(decimal amount)
			{
				balance += amount;
			}

			public void Withdraw(decimal amount)
			{
				decimal withdrawalAmount = Math.Min(amount, balance);
				balance -= withdrawalAmount;
			}
		}
	}
	
}
