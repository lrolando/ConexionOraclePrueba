using System;
using System.Collections.Generic;
using Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Persistence.DBContext;

public partial class ApiDBContext : DbContext
{

    public ApiDBContext()
    {
    }

    public ApiDBContext(DbContextOptions<ApiDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ITEM> Items { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        var myConnectionString = configuration.GetConnectionString("myDb1");

        optionsBuilder.UseOracle(myConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ITEM>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ITEM");

            entity.Property(e => e.DESCRIPTION)
                //.HasMaxLength(50)
                //.IsUnicode(false)
                .HasColumnName("DESCRIPTION");

            entity.Property(e => e.ID)
                .HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
