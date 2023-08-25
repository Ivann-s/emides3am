using ControledePet.Models;
using Microsoft.EntityFrameworkCore;

namespace ControledePet.Data
{
    public class BancoContext:DbContext
    {
        public BancoContext(DbContextOptions<BancoContext>options):base(options)
        { 
        }
        
        public DbSet<PetModel> Pets { get; set; }
    }
}
