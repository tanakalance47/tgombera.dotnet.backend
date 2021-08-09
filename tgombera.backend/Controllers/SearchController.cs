using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using tgombera.backend.Helpers.Search;
using tgombera.backend.Models;

namespace tgombera.backend.Controllers
{
    /// <summary>
    /// /// This controller is responsible for handling the GET/POST requests made to the API to obtain results for a search query from both the StarWars and Chuck Norris APIs.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        /// <summary>
        /// Searches the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        [EnableCors("DefaultPolicy")]
        [HttpGet("/search/{query}")]
        public ReturnSearchResults Search(string query)
        {
            ISearchHelper seachHelper = new SearchHelper();

            return seachHelper.Search(query);
        }
    }
}