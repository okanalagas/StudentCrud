

using Microsoft.EntityFrameworkCore;

namespace StudentCrud.Models
{
    public class Model1: DbContext
    {

        public Model1(DbContextOptions<Model1> options) : base(options)
        {

        }

        public virtual DbSet<Ogrenci> MyEntities { get; set; }

    }
}
