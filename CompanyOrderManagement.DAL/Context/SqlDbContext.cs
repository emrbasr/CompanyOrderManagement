﻿using CompanyOrderManagement.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOrderManagement.DAL.Context
{
    public class SqlDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public SqlDbContext()
        {

        }
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Sql server veritabanı bağlantısı
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CompanyDb;Trusted_Connection=true");
        }
    }
} 
