using System.Collections.Generic;

using tgombera.backend.Models;

namespace tgombera.backend.Helpers.Swapi
{
    /// <summary>
    ///  This interface is responsible for defining the methods used in the SwapiHelper class.
    /// </summary>
    public interface ISwapiHelper
    {
        /// <summary>
        /// Gets the star wars people.
        /// </summary>
        List<StarWarsPerson> GetStarWarsPeople();
    }
}