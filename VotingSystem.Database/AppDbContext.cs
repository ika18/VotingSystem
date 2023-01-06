using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using VotingSystem.Models;

namespace VotingSystem.Database;

public class AppDbContext : DbContext
{
    public DbSet<Counter> Counters { get; set; }
    public DbSet<VotingPoll> VotingPolls { get; set; }
    public DbSet<Vote> Votes { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Counter>().Property<int>("Id");
        modelBuilder.Entity<Counter>().Ignore(x => x.Count);
        
        modelBuilder.Entity<VotingPoll>().Property<int>("Id");
        
        modelBuilder.Entity<Vote>().Property<int>("Id");
    }
}