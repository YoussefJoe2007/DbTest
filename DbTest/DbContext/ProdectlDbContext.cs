namespace DbTest.DbContext;

using DbTest.Models;
using Microsoft.EntityFrameworkCore;
using System;

public class ProdectlDbContext : DbContext
{

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }

    public ProdectlDbContext(DbContextOptions<ProdectlDbContext> options) : base(options)
    {

    }
}


