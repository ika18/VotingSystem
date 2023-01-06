using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VotingSystem.Ui.Pages
{
    public class IndexModel : PageModel
    {
        public VotingPoll Poll { get; set; }
        
        [BindProperty]
        public VotingPollFactory.Request Request { get; set; }

        public void OnGet([FromServices] IVotingPollFactory pollFactory)
        {
            // var request = new VotingPollFactory.Request
            // {
            //     Title = "title",
            //     Description = "desc",
            //     Names = new[] {"One", "Two"}
            // };
            //
            // Poll = pollFactory.Create(request);
        }
        
        public void OnPost([FromServices] IVotingPollFactory pollFactory)
        {
            Poll = pollFactory.Create(Request);
        }
    }
}
