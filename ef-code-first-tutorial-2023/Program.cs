using ef_code_first_tutorial_2023.Controller;

/////using Controller:



var custCtrl = new CustomersController();
var customer = await custCtrl.GetCustomerWithOrders(4);

//if (customer == null) return;

Console.WriteLine($"CUSTOMER: {customer.Name}");
foreach (var ord in customer.Orders)
{
    Console.WriteLine($"ORDER: Description {ord.Description}");
    foreach (var ol in ord.Orderlines)
    {
        Console.WriteLine($"ORDERLINE: Product: {ol.Item.Name}, Quantity: {ol.Quantity}, Price: {ol.Item.Price:C}, Line total: {ol.Quantity * ol.Item.Price:C}");
    }
}

////And it worked! 3/1/23

/*
var custCtrl = new CustomersController();
var customers = await custCtrl.GetCustomer();

foreach(var cust in customers)
{
    Console.WriteLine(cust.Name);
}
*/
/*
using ef_code_first_tutorial_2023;
using Microsoft.EntityFrameworkCore;


var _context = new SalesDbContext();

var customer = _context.Customers
                            .Include(x => x.Orders)
                            .ThenInclude(x => x.Orderlines)
                            .ThenInclude(x => x.Item)
                            .Single(x => x.Id == 4); //my Kroger is Id 4

Console.WriteLine($"CUSTOMER: {customer.Name}"); 
foreach (var ord in customer.Orders) 
{
    Console.WriteLine($"ORDER: Description {ord.Description}");
    foreach (var ol in ord.Orderlines)
    {
        Console.WriteLine($"ORDERLINE: Product: {ol.Item.Name}, Quantity: {ol.Quantity}, Price: {ol.Item.Price:C}, Line total: {ol.Quantity * ol.Item.Price:C}");
    }

}
////////Yay, it worked!!!

*/

////////////////////////// Feb 27 below //////////////////
/*
var order = _context.Orders.Include(x => x.Orderlines)
                                .ThenInclude(x => x.Item)
                           .Include(x => x.Customer) //This can also go above the Include Orderlines
                                // .ThenInclude(x => x.Orders)
                           .Single(x => x.Id == 1);

Console.WriteLine($"ORDER: Description: {order.Description}");
foreach(var ol in order.Orderlines) {
    Console.WriteLine($"ORDERLINE: Product: {ol.Item.Name}, Quantity: {ol.Quantity}, Price: {ol.Item.Price:C}, Line total: {ol.Quantity * ol.Item.Price:C}");
}
var orderTotal = order.Orderlines.Sum(ol => ol.Item.Price * ol.Quantity);
Console.WriteLine($"Total: {orderTotal:C}");
*/


//_context.Customers.ToList().ForEach(c => Console.WriteLine(c.Name));


//////**** This coding session is key for the Capsone ****