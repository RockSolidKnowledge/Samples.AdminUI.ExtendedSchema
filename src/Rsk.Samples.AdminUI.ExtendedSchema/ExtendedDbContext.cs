using IdentityExpress.Identity;
using Microsoft.EntityFrameworkCore;

namespace Rsk.Samples.AdminUI.ExtendedSchema
{
    public class ExtendedDbContext : IdentityExpressDbContext<ExtendedUser>
    {
        public ExtendedDbContext(DbContextOptions<ExtendedDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Department>(dept =>
            {
                dept.HasKey(x => x.Id);
                dept.ToTable("Departments");

                dept.HasMany(x => x.Users)
                    .WithOne(x => x.Department)
                    .HasForeignKey(x => x.DepartmentId)
                    .IsRequired(false);
            });
        }
    }
}