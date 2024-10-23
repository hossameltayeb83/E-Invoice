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
	internal class InvoiceLineConfiguration : IEntityTypeConfiguration<InvoiceLine>
	{
		public void Configure(EntityTypeBuilder<InvoiceLine> builder)
		{
			builder.ToTable("InvoiceLines");
			//builder.HasOne(e=>e.Item)
			//	.WithMany(e=>e.InvoiceLines)
			//	.HasForeignKey(e=>e.ItemId)
			//	.OnDelete(DeleteBehavior.SetNull)
			//	 ;
			builder.HasIndex("ItemId", "InvoiceId").IsUnique();
			builder.Property(e => e.ItemName).HasMaxLength(50);
		}
	}
}
