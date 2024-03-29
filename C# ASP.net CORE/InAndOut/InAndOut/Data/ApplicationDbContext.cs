﻿using InAndOut.Models;
using Microsoft.EntityFrameworkCore;

namespace InAndOut.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }


        public DbSet<Item> Items { get; set; }
        public DbSet<Expenses> ExpensesList { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
    }
}
