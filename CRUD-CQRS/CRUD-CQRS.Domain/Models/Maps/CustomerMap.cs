using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.CQRS.Domain.Models.Maps
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasIndex(p => new { p.FirstName, p.LastName, p.DateOfBirth }).IsUnique();
            builder.HasIndex(p => new { p.Email }).IsUnique();
        }
    }
}
