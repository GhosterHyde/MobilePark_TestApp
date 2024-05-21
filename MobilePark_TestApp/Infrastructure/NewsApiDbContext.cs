using Microsoft.EntityFrameworkCore;
using MobilePark_TestApp.Models;

namespace MobilePark_TestApp.Infrastructure
{
    /// <summary>
    /// News Api DataBase Context
    /// </summary>
    /// <param name="configuration">DataBase Configuration</param>
    public class NewsApiDbContext(IConfiguration configuration) : DbContext
    {
        /// <summary>
        /// Set of News Api Results
        /// </summary>
        public DbSet<ParametersAndResult> Results { get; init; }

        private readonly string _connectionString = configuration["ConnectionString"]!;

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ParametersAndResult>()
                .HasIndex(x => new { x.Keyword, x.SearchIn, x.Language });
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
