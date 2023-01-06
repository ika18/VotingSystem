using VotingSystem.Models;

namespace VotingSystem;

public interface ICounterManager
{
    List<CounterStatistics> GetStatistics(ICollection<Counter> pollCounters);
    void ResolveExcess(List<CounterStatistics> counterStats);
}