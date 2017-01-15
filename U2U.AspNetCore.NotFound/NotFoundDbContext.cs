using Microsoft.EntityFrameworkCore;
using System;

namespace U2U.AspNetCore.NotFound
{
  public class NotFoundDbContext : DbContext
  {
    public NotFoundDbContext(DbContextOptions<NotFoundDbContext> options)
      : base(options)
    {
    }

    public DbSet<NotFoundRequest> NotFoundRequests { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      // Customize the ASP.NET Identity model and override the defaults if needed.
      // For example, you can rename the ASP.NET Identity table names and more.
      // Add your customizations after calling base.OnModelCreating(builder);
      modelBuilder.Entity<NotFoundRequest>().HasKey(nfr => nfr.Id);
    }
  }
}
