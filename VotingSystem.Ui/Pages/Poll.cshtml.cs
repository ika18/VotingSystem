using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VotingSystem.Application;

namespace VotingSystem.Ui.Pages;

public class Poll : PageModel
{
    public PollStatistics Statistics { get; set; }
    public void OnGet(int id, [FromServices] StatisticsInteractor interactor)
    {
        Statistics = interactor.GetStatistics(id);
    }
}