using HospedaFacil.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospedaFacil.Insfraestructure.Data.SQLServer.Configuration
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Id).ValueGeneratedOnAdd();
            builder.Property(h => h.Nome).IsRequired().HasMaxLength(100);
            builder.Property(h => h.MongoId).IsRequired().HasColumnName("mongo_id");

            builder.ToTable("Hoteis");
        }
    }
}
