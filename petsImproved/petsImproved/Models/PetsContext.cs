using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pets.Models
{
    class PetsContext : DbContext
    {
        public PetsContext() : base(ConfigurationManager.ConnectionStrings["PetsConnection2"].ConnectionString)
        {

        }

        public DbSet<EntType> Types { get; set; }
        public DbSet<EntSize> Sizes { get; set; }
        public DbSet<EntOrder> Orders { get; set; }
        public DbSet<EntAnimal> Animals { get; set; }
    }
}
