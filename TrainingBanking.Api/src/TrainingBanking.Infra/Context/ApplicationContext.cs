using Microsoft.EntityFrameworkCore;
using TrainingBanking.Domain.AccountContext.Entities;
using TrainingBanking.Shared;

namespace TrainingBanking.Infra.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Settings.ConnectionString);
            }
        }
    }
}
