using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MobileRecharge.Models;

namespace MobileRecharge.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MobileRecharge.Models.RechargeModel>? RechargeModel { get; set; }
        public DbSet<MobileRecharge.Models.History>? History { get; set; }
        
    }
}