using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clientApp.Models
{
    public class ClinentContext : DbContext
    {
        public ClinentContext(DbContextOptions<ClinentContext> options)
          : base(options)
        { }

        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }



    }
}
