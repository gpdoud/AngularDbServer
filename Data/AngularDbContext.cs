using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AngularDbServer.Models;

namespace AngularDbServer.Data {

    public class AngularDbContext : DbContext {
    
        public DbSet<AngularDbServer.Models.Customer> Customers { get; set; } = default!;
        public DbSet<AngularDbServer.Models.Order> Orders { get; set; }

        public AngularDbContext(DbContextOptions<AngularDbContext> options)
            : base(options) {
        }

    }
}
