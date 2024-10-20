using BlazorProject.Domain.Common;
using BlazorProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Infrastructure.Data
{
	internal class ProjectContext : DbContext
	{
		public DbSet<Item> Items {  get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Tax> Taxes { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public ProjectContext(DbContextOptions options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Ignore<BaseEntity>();
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateTimeIssued = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
