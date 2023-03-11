using Microsoft.EntityFrameworkCore;
using OrganizadorPOs.Domain.Entities;

namespace OrganizadorPOs.Repository.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Registro>? Registros { get; set; }
        public DbSet<Tipo>? Tipos { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
