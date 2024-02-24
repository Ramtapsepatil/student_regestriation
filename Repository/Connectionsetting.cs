using studentregestration.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace studentregestration.Repository
{
    public class Connectionsetting
    {
        //public Connectionsetting(DbContextOptions<YourDbContext> options) : base(options)
        //{
        //}

        public DbSet<Student> Students { get; set; }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}