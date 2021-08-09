using System.Collections.Generic;

using RestSharp;
using Newtonsoft.Json;

using tgombera.backend.Models;
using tgombera.backend.Helpers.Common;

namespace tgombera.backend.Helpers.Swapi
{
    /// <summary>
    /// This class is reponsible for getting response data from the Star Wars API and coverting it into the relevent return data to be used in the frontend application. 
    /// </summary>
    /// <seealso cref="tgombera.backend.Helpers.Swapi.ISwapiHelper" />
    public class SwapiHelper : ISwapiHelper
    {
        private const string SWAPI_PEOPLE_ENDPOINT = "https://swapi.dev/api/people/";

        /// <summary>
        /// Gets the star wars people.
        /// </summary>
        public List<StarWarsPerson> GetStarWarsPeople()
        {
            List<StarWarsPerson>   starWarsPeople               = new List<StarWarsPerson>();
            StarWarsPeople         starWarsPeopleWithMetaData   = new StarWarsPeople();
            IExternalAPIHelper     apiHelper                    = new ExternalAPIHelper();
            IRestResponse          response                     = null;

            try
            {
                response                    = apiHelper.CallAPI(SWAPI_PEOPLE_ENDPOINT);
                starWarsPeopleWithMetaData  = JsonConvert.DeserializeObject<StarWarsPeople>(response.Content);
                starWarsPeople              = starWarsPeopleWithMetaData.results;

                return starWarsPeople;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}