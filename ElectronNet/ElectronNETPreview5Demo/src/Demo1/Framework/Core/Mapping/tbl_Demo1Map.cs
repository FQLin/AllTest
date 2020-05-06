using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo1.Framework.Core.Mapping
{
    public class tbl_Demo1Map : IEntityTypeConfiguration<tbl_Demo1>
    {
        public void Configure(EntityTypeBuilder<tbl_Demo1> builder)
        {
            builder.HasKey(b => b.Id);
            builder.ToTable(nameof(tbl_Demo1));
            builder.Property(b => b.Id).HasMaxLength(32);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(500);
            builder.Property(b => b.Age).IsRequired();
        }
    }
}
