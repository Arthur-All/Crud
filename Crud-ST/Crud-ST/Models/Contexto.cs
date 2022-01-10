using Microsoft.EntityFrameworkCore;
using Crud_ST.Models;

namespace Crud_Ins.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Inscritos> Inscritos { get; set; }

        public DbSet<Instrutores> Instrutores { get; set; }

        public DbSet<Live> Live { get; set; }

        //public DbSet<Inscricoes> Inscricoes { get; set; }


    }
}
