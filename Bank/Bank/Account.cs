using System;

public class Account
{
    public int Balance;
    public Person Owner;
    public String Name;
    public Account(Person customer, Money deposit)
	{
        Owner = customer;
        Balance += deposit.Value;
        Name = customer.name + (customer.accountlist.Count + 1);
    }

    
}
