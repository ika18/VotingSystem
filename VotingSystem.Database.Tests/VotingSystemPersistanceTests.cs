using Microsoft.EntityFrameworkCore;
using VotingSystem.Application;
using VotingSystem.Database.Tests.Infrastructure;
using VotingSystem.Models;

namespace VotingSystem.Database.Tests;

public class VotingSystemPersistanceTests
{
    [Fact]
    public void PersistsVotingPoll()
    {
        var poll = new VotingPoll
        {
            Title = "title",
            Description = "desc",
            Counters = new List<Counter>
            {
                new Counter {Name = "One"},
                new Counter {Name = "Two"}
            }
        };

        using (var ctx = DbContextFactory.Create(nameof(PersistsVotingPoll)))
        {
            IVotingSystemPersistance persistance = new VotingSystemPersistance(ctx);
        
            persistance.SaveVotingPoll(poll);    
        }
        
        
        using (var ctx = DbContextFactory.Create(nameof(PersistsVotingPoll)))
        {
            var savedPoll = ctx.VotingPolls
                .Include(x => x.Counters)
                .Single();
            
            Assert.Equal(poll.Title, savedPoll.Title);
            Assert.Equal(poll.Description, savedPoll.Description);
            Assert.Equal(poll.Counters.Count(), savedPoll.Counters.Count());

            foreach (var name in savedPoll.Counters.Select(x =>x.Name))
            {
                Assert.Contains(name, savedPoll.Counters.Select(x => x.Name));
            }
        }
    }
}

public class VotingSystemPersistance : IVotingSystemPersistance
{
    private readonly AppDbContext _ctx;

    public VotingSystemPersistance(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public void SaveVotingPoll(VotingPoll votingPoll)
    {
        _ctx.VotingPolls.Add(votingPoll);
        _ctx.SaveChanges();
    }
}