using Microsoft.EntityFrameworkCore;
using SistemaDeCadastroAPI.Data.Map;
using SistemaDeCadastroAPI.Models;

namespace SistemaDeCadastroAPI.Data
{
    public class SistemaCadastroDBContex: DbContext
    {
        public SistemaCadastroDBContex(DbContextOptions<SistemaCadastroDBContex> options)
            :base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
