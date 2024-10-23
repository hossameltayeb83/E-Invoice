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
	internal class InvoiceLineTaxConfiguration : IEntityTypeConfiguration<InvoiceLineTax>
	{
		public void Configure(EntityTypeBuilder<InvoiceLineTax> builder)
		{
			builder.ToTable("InvoiceLineTaxes");
            //builder.HasOne(e => e.Tax)
            //    .WithMany(e => e.InvoiceLineTaxes)
            //    .HasForeignKey(e => e.TaxId)
            //    .OnDelete(DeleteBehavior.SetNull);
            builder.HasIndex("InvoiceLineId", "TaxId").IsUnique();
			builder.Property(e => e.TaxName).HasMaxLength(50);
		}
	}
}
