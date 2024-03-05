using Domain.Models;
using Infrastracture.Services;

var cs = new CustomerService();
var tr = new TranzactionService();
foreach (var c in cs.GetCustomers())
{
    Console.WriteLine($"Customer Id :{c.Id}");
    Console.WriteLine($"Customer Full Name: {c.FullName}");
    Console.WriteLine($"Customer balance :{c.Balance}");
    Console.WriteLine("--------------------------------");
}

Console.WriteLine("--------------------------------");
Console.WriteLine("--------------------------------");


foreach (var t in tr.HistorTranzactions())
{
    Console.WriteLine($"Tranzaction Id {t.Id}");
    Console.WriteLine($"Sender id {t.SenderId}");
    Console.WriteLine($"Recipient id {t.TakerId}");
    Console.WriteLine($"Amount to send {t.Sum}");
    Console.WriteLine("--------------------------------");
}



/*
var c1 = new Customer();
Console.WriteLine("Enter customer Name");
c1.FullName = Console.ReadLine();
Console.WriteLine("Enter Customer start Balance");
c1.Balance = decimal.Parse(Console.ReadLine());

cs.AddCustomer(c1);
*/


/*var t1 = new Tranzaction();
Console.WriteLine("Enter sender id");
t1.SenderId = int.Parse(Console.ReadLine());
Console.WriteLine("Enter a Recipient id");
t1.TakerId = int.Parse(Console.ReadLine());
Console.WriteLine("Enter a amount for send");
t1.Sum = decimal.Parse(Console.ReadLine());
tr.MakeTranzaction(t1);*/