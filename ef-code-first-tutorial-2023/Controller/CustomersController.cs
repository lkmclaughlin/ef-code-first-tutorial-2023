using ef_code_first_tutorial_2023.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ef_code_first_tutorial_2023.Controller;

public class CustomersController
{ ///begins class
    private readonly SalesDbContext _context;

    public CustomersController()
    {
        _context = new SalesDbContext();
    }

    public async Task<ICollection<Customer>> GetCustomer()
    {
        return await _context.Customers
                                   // .Include(x => x.Orders)
                                      .ToListAsync();
    }

    public async Task<Customer?> GetCustomer(int id)
    {
        return await _context.Customers
                                     .FindAsync(id);
    }

    public async Task<Customer?> GetCustomerWithOrders(int id)
    {
        return await _context.Customers
                                     .Include(x => x.Orders)
                                        .ThenInclude(x => x.Orderlines)
                                            .ThenInclude(x => x.Item)
                                      .SingleOrDefaultAsync(x => x.Id == id);
                           
    }

    public async Task<Customer> InsertCustomer(Customer cust)
    {
        _context.Customers.Add(cust);
        var changes = await _context.SaveChangesAsync();
        if(changes != 1)
        {
            throw new Exception("Insert failed!");
        }
        return cust;
    }

    public async Task UpdateCustomer(int id, Customer cust)
    {
        if(id != cust.Id)
        {
            throw new Exception("Customer ID does not match!");

        }
        _context.Entry(cust).State = EntityState.Modified;
        var changes = await _context.SaveChangesAsync();
        if(changes != 1)
        {
            throw new Exception("Update unsuccessful!");
        }
    }

    public async Task DeleteCustomer(int id)
    {
        var cust = await GetCustomer(id);
        if(cust is null)
        {
            throw new Exception("Not found!");

        }
        _context.Customers.Remove(cust);
        var changes = await _context.SaveChangesAsync();
        if(changes != 1)
        {
            throw new Exception("Delete unsuccessful!");
        }

    }

} //ends class 
