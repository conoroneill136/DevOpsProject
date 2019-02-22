using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Model
{
    public class RegistrationContext : DbContext
    {

        public RegistrationContext(DbContextOptions<RegistrationContext> options)
            : base(options)
        {
        }

        public DbSet<Registration> _RegestrationDb { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registration>().HasData(new Registration
            {
                FirstName = "Conor",
                LastName = "ONeill",
                Email = "conor@version1.com",
                Password = "conor123"

            }, new Registration
            {
                FirstName = "Uncle",
                LastName = "Bob",
                Email = "uncle.bob@gmail.com",
                Password = "bob123"
            });
        }
    }
}
