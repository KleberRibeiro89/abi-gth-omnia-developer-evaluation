using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("sales");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.SaleNumber).IsRequired();
        builder.Property(s => s.DateSaleMade).IsRequired();
        builder.Property(s => s.Customer).IsRequired();
        builder.Property(s => s.TotalSaleAmount).IsRequired();
        builder.Property(s => s.BranchSaleMade).IsRequired();
        builder.Property(s => s.TotalAmountItem).IsRequired();
        builder.Property(s => s.Cancelled).IsRequired();
    }
}
