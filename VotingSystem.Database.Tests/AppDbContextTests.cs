using VotingSystem.Database.Tests.Infrastructure;
using VotingSystem.Models;

namespace VotingSystem.Database.Tests;

public class AppDbContextTests
{
    

    [Fact]
    public void SaveCounterToDatabase()
    {
        var counter = new Counter {Name = "New Counter"};

        using (var ctx = DbContextFactory.Create(nameof(SaveCounterToDatabase)))
        {
            ctx.Counters.Add(counter);
            ctx.SaveChanges();
        }

        using (var ctx = DbContextFactory.Create(nameof(SaveCounterToDatabase)))
        {
            var saveDcounter = ctx.Counters.Single();
            Assert.Equal(counter.Name, saveDcounter.Name);
        }
    }

    [Fact]
    public void SaveVotingPollToDatabase()
    {
        var poll = new VotingPoll() {Title = "New VotingPoll", Description = "Description"};

        using (var ctx = DbContextFactory.Create(nameof(SaveVotingPollToDatabase)))
        {
            ctx.VotingPolls.Add(poll);
            ctx.SaveChanges();
        }

        using (var ctx = DbContextFactory.Create(nameof(SaveVotingPollToDatabase)))
        {
            var savedPoll = ctx.VotingPolls.Single();
            Assert.Equal(poll.Title, savedPoll.Title);
        }
    }
}