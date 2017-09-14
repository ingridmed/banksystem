using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Bank
{
    class Bank
    {
        public Bank()
        {

        }
        public Account CreateAccount(Person customer, Money deposit)
        {   if (customer.money.Value >= deposit.Value)
            {
                customer.money.Value -= deposit.Value;
                Account account = new Account(customer, deposit);
                customer.accountlist.Add(account);
                return account;
            }
            else 
            {
                Console.Out.WriteLine("Could not create account, not enough money");
                return null;
            }
        }
        Account[] GetAccountsForCustomer(Person customer)
        {
            Account[] list = customer.accountlist.ToArray();
            return list;
        }
        public void Deposit(Account to, Money amount)
        {
            if (amount.Value > 0 && to.Owner.money.Value >= amount.Value) {
                to.Balance += amount.Value;
                to.Owner.money.Value -= amount.Value;
            }
            else
            {
                Console.Out.WriteLine("You have less money than you want to deposit");
            }
        }
        public void Withdraw(Account from, Money amount)
        {
            if(amount.Value < from.Balance)
            {
                from.Balance -= amount.Value;
                from.Owner.money.Value += amount.Value;
            }
            else
            {
                Console.Out.WriteLine("You have less money than you want to transfer");
            }
        }
        public void Transfer(Account from, Account to, Money amount)
        {
            if (from.Balance >= amount.Value)
            {
                from.Balance -= amount.Value;
                to.Balance += amount.Value;
            }
            else
            {
                Console.Out.WriteLine("You have less money than you want to transfer");
            }
        }


        static void Main(string[] args)
        {
            Bank bank = new Bank();
            Person person = new Person("TestPerson",  1234, 456843, new Money(800));
            Console.WriteLine("New person is called: " + person.name + "   Current balance: " + person.money.Value);

            //test to check account creation
            Console.WriteLine();
            Account account1 = bank.CreateAccount(person, new Money(200));
            Console.WriteLine("Current balance: " + person.money.Value);
            Account account2 = bank.CreateAccount(person, new Money(300));
            Console.WriteLine("Current balance: " + person.money.Value);
            bank.CreateAccount(person, new Money(100));
            Console.WriteLine("Current balance: " + person.money.Value);
            bank.CreateAccount(person, new Money(500));

            //test of GetAccountsForPerson
            Console.WriteLine();
            Console.WriteLine("Listing all current accounts");
            foreach (Account account in bank.GetAccountsForCustomer(person))
            {
                Console.WriteLine("KontoNavn: " + account.Name + "      KontoEier: " + account.Owner.name + "      Balance: " + account.Balance);
            }

            //test of Deposit
            Console.WriteLine();
            bank.Deposit(account1, new Money(200));
            Console.WriteLine("Deposit 200");
            Console.WriteLine("KontoNavn: " + account1.Name + "      KontoEier: " + account1.Owner.name + "      Balance: " + account1.Balance);

            //test of Withdrawl
            Console.WriteLine();
            bank.Withdraw(account1, new Money(100));
            Console.WriteLine("Withdraw 100");
            Console.WriteLine("KontoNavn: " + account1.Name + "      KontoEier: " + account1.Owner.name + "      Balance: " + account1.Balance);

            //test of Transfer
            Console.WriteLine();
            bank.Transfer(account1, account2, new Money(200));
            Console.WriteLine("Transfer 200 from " + account1.Name + " to " + account2.Name);
            Console.WriteLine("KontoNavn: " + account1.Name + "      KontoEier: " + account1.Owner.name + "      Balance: " + account1.Balance);
            Console.WriteLine("KontoNavn: " + account2.Name + "      KontoEier: " + account2.Owner.name + "      Balance: " + account2.Balance);

            Console.ReadLine();
        }
    }
}
