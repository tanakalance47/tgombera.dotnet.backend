using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using tgombera.backend.Helpers.Swapi;
using tgombera.backend.Models;

namespace tgombera.backend.Controllers
{
    /// <summary>
    /// /// This controller is responsible for handling the GET/POST requests made to the API to obtain data from the StarWars API.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class SwapiController : ControllerBase
    {
        /// <summary>
        /// Gets the StarWars people.
        /// </summary>
        [EnableCors("DefaultPolicy")]
        [HttpGet("/swapi/people")]
        public ActionResult<IEnumerable<StarWarsPerson>> GetStarWarPeople()
        {
            ISwapiHelper swapiHelper = new SwapiHelper();

            return swapiHelper.GetStarWarsPeople();
        }
    }
}