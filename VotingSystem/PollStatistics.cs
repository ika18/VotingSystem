namespace VotingSystem.Application;

public class PollStatistics
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<CounterStatistics> Counters { get; set; }
}