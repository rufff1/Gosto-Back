using Gosto.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Setting> Settings { get; set; }
        public DbSet<BTag> BTags { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<HiGosto> HiGostos { get; set; }
        public DbSet<WelcomeGosto> WelcomeGostos { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Texnology> Texnologies { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<OurTeamBackImage> OurTeamBackImages { get; set; }
        public DbSet<CreateTrend> CreateTrends { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<PTag> PTags { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Basket> Baskets { get; set; }
       



    }
}
