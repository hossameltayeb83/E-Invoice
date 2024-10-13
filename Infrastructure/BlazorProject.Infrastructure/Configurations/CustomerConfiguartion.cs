using BlazorProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Infrastructure.Configurations
{
	internal class CustomerConfiguartion : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.Property(e => e.Code).HasMaxLength(50);
			builder.Property(e => e.Name).HasMaxLength(50);
		}
	}
}
