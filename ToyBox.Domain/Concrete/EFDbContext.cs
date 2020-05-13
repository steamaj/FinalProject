using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyBox.Domain.Entities;
using System.Data.Entity;

namespace ToyBox.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Condition> Condition { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
