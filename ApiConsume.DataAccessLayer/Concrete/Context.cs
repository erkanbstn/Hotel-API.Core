using ApiConsume.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        private readonly IConfiguration _configuration;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GEOPC\\SQLEXPRESS;Initial Catalog=ApiDb;Integrated Security=True");
        }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staffes { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
