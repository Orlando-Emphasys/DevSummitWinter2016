﻿using Microsoft.EntityFrameworkCore;
using QRScanner_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QRScanner_API.DAL
{
    public class APIDataContext : DbContext
    {
        public APIDataContext(DbContextOptions<APIDataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ItemQR> ItemQRs { get; set; }
    }
}
