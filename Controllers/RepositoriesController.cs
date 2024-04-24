using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GitHubExplorerAPI.Services;

namespace GitHubExplorerAPI.Controllers
{
    [ApiController]
    [Route("/api/repositories")]
    public class RepositoriesController : ControllerBase
    {
        private readonly GitHubService _gitHubService;

        public RepositoriesController()
        {
            _gitHubService = new GitHubService();
        }

        [HttpGet]
        public async Task<IActionResult> GetReposInfo(
            [FromQuery] string user = "",
            [FromQuery] string language = "",
            [FromQuery] string sort = "updated",
            [FromQuery] string include_forks="false",
            [FromQuery] string limit = ""
        )
        {
            string result = await _gitHubService.GetReposInfoAsync(user, language, sort, include_forks, limit);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(500, "Erro ao processar a solicitação.");
            }
        }
    }
}
