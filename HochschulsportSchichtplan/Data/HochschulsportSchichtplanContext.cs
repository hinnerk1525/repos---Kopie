using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HochschulsportSchichtplan.Models
{
    public class HochschulsportSchichtplanContext : DbContext
    {
        public HochschulsportSchichtplanContext (DbContextOptions<HochschulsportSchichtplanContext> options)
            : base(options)
        {
        }

        public DbSet<HochschulsportSchichtplan.Models.Schicht> Schicht { get; set; }
    }
}
