using BigBrotherAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.DataContext
{
    public class BbAppContext : DbContext
    {
        public BbAppContext(DbContextOptions<BbAppContext> options) : base (options)
        {

        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Emotions> Emotion { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<PersonEmotions> PersonEmotions { get; set; }
        public DbSet<TeamPerson> TeamPerson { get; set; }
    }
}
