using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using caes_donos.Models;
using System.Data.Entity;


namespace caes_donos.Context
{
    public class Context : DbContext
    {
        public DbSet<Cao> Cao { get; set; }
        public DbSet<Dono> Dono { get; set; }
        public DbSet<Raca> Raca { get; set; }
        public DbSet<CaoDono> CaoDono { get; set; }
        
    }
}