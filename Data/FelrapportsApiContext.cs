using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FelrapportsApi.Model;

namespace FelrapportsApi.Data
{
    public class FelrapportsApiContext : DbContext
    {
        public FelrapportsApiContext (DbContextOptions<FelrapportsApiContext> options)
            : base(options)
        {
        }

        public DbSet<FelrapportsApi.Model.Felrapport> Felrapport { get; set; } = default!;
    }
}
