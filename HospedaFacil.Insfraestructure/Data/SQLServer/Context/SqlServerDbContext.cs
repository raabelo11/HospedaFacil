using HospedaFacil.Domain.Models;
using HospedaFacil.Insfraestructure.Data.SQLServer.Configuration;
using Microsoft.EntityFrameworkCore;

namespace HospedaFacil.Insfraestructure.Data.SQLServer.Context
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options)
            : base(options) { }

        public DbSet<Hotel> Hoteis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
        }
    }
}
