using Data.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class MyDB_Context : DbContext
    {
        public MyDB_Context(DbContextOptions<MyDB_Context> options) : base(options) { }

        #region DbSet
        public DbSet<Account> Account { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Certify> Certify { get; set; }
        public DbSet<Goldk> Goldk { get; set; }
        public DbSet<ItemProduct> ItemProduct { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        #endregion
    }
}
