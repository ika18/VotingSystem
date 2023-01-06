using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Ui.Models;

namespace VotingSystem.Ui.Controllers;

[Route("[Controller]/[action]")]
public class HomeController : Controller
{
    private readonly IVotingPollFactory _pollFactory;

    public HomeController(IVotingPollFactory pollFactory)
    {
        _pollFactory = pollFactory;
    }

    [HttpPost]
    public VotingPoll Create(VotingPollFactory.Request request)
    {
        return _pollFactory.Create(request);
    }
}
