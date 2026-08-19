using Microsoft.EntityFrameworkCore;
using Motor.Inquiry.Domain.Entities;

namespace Motor.Inquiry.Infrastructure.Data.Context
{

    public class MotorDbContext : DbContext
    {

        public MotorDbContext(DbContextOptions<MotorDbContext> options) : base(options)
        {

        }
        public DbSet<InquiryHistory> InquiryHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تطبيق إعدادات الجداول من ملفات الـ Configuration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MotorDbContext).Assembly);
        }
    }
}
