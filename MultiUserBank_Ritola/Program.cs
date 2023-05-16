using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace MultiUserBank_Ritola
{
	internal class Program
	{

		static void Main(string[] args)
		{
			Console.WriteLine("-Welcome to the Multi-User Bank Co-");
			Console.WriteLine("-");

			Console.WriteLine("-Please Log in by following these instructions to log in-");
			Console.WriteLine("-");

			Console.WriteLine("-Enter your username, and then press the 'Enter' key.-");
			Console.WriteLine("-On the next line, enter your password and then press the 'Enter' key.-");
			Console.WriteLine("-");

			Bank bank = new Bank();
			string user;
			string pass;
			Login();



			
			//bank.Login(Console.ReadLine(), Console.ReadLine());
			//Console.WriteLine("What would you like to do?");
			//MenuInformation();

			

			bool isRunning = true;
			while (isRunning)
			{

				

				Console.WriteLine("Hello {0:C}! What would you like to do?", user);
				bank.MenuInformation();

				int option = 0;
				option = int.Parse(Console.ReadLine());

				switch (option)
				{
					// EXIT
					case 0:
						isRunning = false;
						Console.WriteLine("Goodbye, {0:C}!", user);
						break;

					// DISPLAY BALANCE
					case 1:
						if (bank.IsSomeoneLoggedIn() == false)
						{
							NotLoggedIn();
						}
						Console.WriteLine("Hello {0:C}, welcome back.", user);
						bank.DisplayUserBalance();
						break;

					// WITHDRAW
					case 2:
						if (bank.IsSomeoneLoggedIn() == false)
						{
							NotLoggedIn();
						}
						
						Console.WriteLine("Hello, {0:C}! Please enter how much would you like to withdraw:", user);
						decimal withdrawalAmt = decimal.Parse(Console.ReadLine());
						if (withdrawalAmt > 500)
						{
							Console.WriteLine("Hello, {0:C}! Please choose an amount less than $500.00", user);
							break;
						}
						bank.Withdraw(withdrawalAmt);

						break;

					// DEPOSIT
					case 3:
						if (bank.IsSomeoneLoggedIn() == false)
						{
							NotLoggedIn();
						}
						Console.WriteLine("Hello, {0:C}! Please enter how much would you like to deposit:", user);
						decimal depositAmt = decimal.Parse(Console.ReadLine());
						bank.Deposit(depositAmt);
						break;

					// LOG OUT USER
					case 4:
						if (bank.IsSomeoneLoggedIn() == false)
						{
							NotLoggedIn();
						}
						bank.Logout();
						Console.WriteLine("Goodbye, {0:C}!", user);
						break;

					// LOG IN USER
					case 5:
						Login();
						Console.WriteLine("Hello, {0:C}!", user);
						break;

					default: break;
						
				}
			}
			void Login()
			{
			
				Console.WriteLine("Please enter your username:");
				user = Console.ReadLine();
				Console.WriteLine("Please enter your password:");
				pass = Console.ReadLine();
				bank.Login(user, pass);
				
				
			}
			void NotLoggedIn()
			{
				Console.WriteLine("*WARNING*\n*You are not logged in to your account*\n\n*Please Log in to continue*");
				Login();
			}
			
		}
		
	}
}