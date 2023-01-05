namespace VotingSystem.Application;

public interface IVotingSystemPersistance
{
    void SaveVotingPoll(VotingPoll votingPoll);
}