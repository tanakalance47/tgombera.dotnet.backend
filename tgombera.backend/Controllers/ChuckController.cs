using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using tgombera.backend.Helpers.Chuck;
using tgombera.backend.Models;

namespace tgombera.backend.Controllers
{
    /// <summary>
    /// This controller is responsible for handling the GET/POST requests made to the API to obtain data from the Chuck Norris API.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ChuckController : ControllerBase
    {
        /// <summary>
        /// Gets the categories.
        /// </summary>
        [EnableCors("DefaultPolicy")]
        [HttpGet("/chuck/categories")]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            IChuckHelper chuckHelper = new ChuckHelper();

            return chuckHelper.GetCategories();
        }

        /// <summary>
        /// Gets the random joke.
        /// </summary>
        /// <param name="category">The category.</param>
        [EnableCors("DefaultPolicy")]
        [HttpGet("/chuck/categories/jokes/random/{category}")]
        public ActionResult<ChuckJoke> GetRandomJoke(string category)
        {
            IChuckHelper chuckHelper = new ChuckHelper();

            return chuckHelper.GetRandomJoke(category);
        }
    }
}