using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuntoTexteditorExtensionWPF.Classes.Database
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
