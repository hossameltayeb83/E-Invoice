using BlazorProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorProject.Infrastructure.Configurations
{
	internal class TaxConfiguartion : IEntityTypeConfiguration<Tax>
	{
		public void Configure(EntityTypeBuilder<Tax> builder)
		{
			builder.Property(e => e.DefaultRate).HasColumnType("decimal(5,3)");
			builder.Property(e => e.Code).HasMaxLength(50);
			builder.Property(e => e.Name).HasMaxLength(50);
		}
	}
}
