using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class CoreContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=ADMINISTRATOR\SQLEXPRESS;Initial Catalog=Accounting;Integrated Security=True");
            optionsBuilder.UseSqlServer(@"Data Source=194.62.52.71,49886;Initial Catalog=Accounting;User ID=sa;Password=ali123");
        }
        //"Data Source=DESKTOP-98BH4PS\SQLEXPRESS;Initial Catalog=Accounting;Integrated Security=True"
        //"Server=(localdb)\SQLEXPRESS;Database=Accounting;Trusted_Connection=true"
        //ADMINISTRATOR\SQLEXPRESS
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
