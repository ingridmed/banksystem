using System;
using System.Collections.Generic;

public class Person
{
    public List<Account> accountlist = new List<Account>();
    public String name;
    public int idnumber;
    public int telephone;
    public Money money;
    public Person(String Name, int idnum, int phonenum, Money cash)
	{
        name = Name;
        idnumber = idnum;
        telephone = phonenum;
        money = cash;
    }
}
