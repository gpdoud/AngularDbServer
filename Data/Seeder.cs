using AngularDbServer.Models;

using Microsoft.EntityFrameworkCore;

namespace AngularDbServer.Data;

public static class Seeder {

    public static void Initialize(AngularDbContext context) {
        context.Database.EnsureCreated();

        List<Customer> customers = new List<Customer> {
            new Customer { Name = "MAX" },
            new Customer { Name = "Amazon" },
            new Customer { Name = "Microsoft" },
            new Customer { Name = "BestBuy" },
            new Customer { Name = "Google" }
        };

        context.Customers.AddRange(customers);
        
        context.SaveChanges();

        List<Order> orders = new List<Order> {
            new Order { Description = "1st Order", Total = 1000, CustomerId = 1 },
            new Order { Description = "2nd Order", Total = 3000, CustomerId = 3 },
            new Order { Description = "3rd Order", Total = 5000, CustomerId = 5 }
        };

        context.Orders.AddRange(orders);

        context.SaveChanges();

    }
}
