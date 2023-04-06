using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
      
        protected override  void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=LAPTOP-T6G0U2K3\\SQLEXPRESS;Database=C#B13;User Id=safin;Password=12345;Trust Server Certificate=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet <Filelist> Files { get; set; }
    }
}
