using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ef_code_first_tutorial_2023.Models;
using Microsoft.EntityFrameworkCore;

namespace ef_code_first_tutorial_2023;

public class SalesDbContext : DbContext
{
    // Tables accessible- the only data you can get from the db is when you define the db set
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Item> Items { get; set; }  
    public DbSet<Orderline> OrdersLines { get; set; }

    public SalesDbContext() { }
        //base options: passing whatever gets passed into options gets passed up to dbcontext
    public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connStr = "server=localhost\\sqlexpress;" +
                        "database=SalesDb2;" +
                        "trusted_connection=true;" +
                        "trustServerCertificate=true;";
        optionsBuilder.UseSqlServer(connStr);
    }
}
