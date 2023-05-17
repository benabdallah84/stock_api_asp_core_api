using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace comuneApi.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<product> products { get; set; }
        public DbSet<facture> factures { get; set; }
        public DbSet<fournisseur> fournisseurs { get; set; }
        public DbSet<beneficie> beneficies { get; set; }
        public DbSet<operation> operations { get; set; }

    }    
}
