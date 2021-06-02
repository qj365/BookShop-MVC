using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DetailOrder> DetailOrders { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Orders>()
                .HasMany(e => e.DetailOrder)
                .WithRequired(e => e.Orders)
                .HasForeignKey(e => e.IdOrder)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Book>()
               .HasMany(e => e.DetailOrder)
               .WithRequired(e => e.Book)
               .HasForeignKey(e => e.IdBook)
               .WillCascadeOnDelete(false);


        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}