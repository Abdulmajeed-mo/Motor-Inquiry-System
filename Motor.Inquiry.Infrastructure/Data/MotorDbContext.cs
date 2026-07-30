using Microsoft.EntityFrameworkCore;
using Motor.Inquiry.Domain.Entities;

namespace Motor.Inquiry.Infrastructure.Data
{

    public class MotorDbContext : DbContext
    {

        public MotorDbContext(DbContextOptions<MotorDbContext> options)  : base(options)
        {

        }
        public DbSet<Motor.Inquiry.Domain.Entities.Inquiry> Inquiries { get; set; }
    }
    
}
