using Microsoft.EntityFrameworkCore;
using VotingSystem.Models;

namespace VotingSystem.Database;

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

    public void SaveVote(Vote vote)
    {
        _ctx.Votes.Add(vote);
        _ctx.SaveChanges();
    }

    public bool VoteExists(Vote vote)
    {
        return _ctx.Votes.Any(x => x.UserId == vote.UserId && x.CounterId == vote.CounterId);
    }

    public VotingPoll GetPoll(int pollId)
    {
        return _ctx.VotingPolls
            .Include(x => x.Counters)
            .Where(x => EF.Property<int>(x, "Id") == pollId)
            .Select(x => new VotingPoll
            {
                Title = x.Title,
                Description = x.Description,
                Counters = x.Counters.Select(y => new Counter
                {
                    Name = y.Name,
                    Count = y.Votes.Count
                }).ToList()
            })
            .FirstOrDefault();
    }
}