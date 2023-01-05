using VotingSystem.Models;

namespace VotingSystem;

public class VotingPoll
{
    public string Title { get; set; }
    public string Description { get; set; }

    public VotingPoll()
    {
        Counters = new List<Counter>();
    }

    public ICollection<Counter> Counters { get; set; }
}