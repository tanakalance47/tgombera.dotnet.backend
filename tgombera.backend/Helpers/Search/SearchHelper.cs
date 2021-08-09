using System.Collections.Generic;

using Newtonsoft.Json;
using RestSharp;

using tgombera.backend.Helpers.Common;
using tgombera.backend.Models;

namespace tgombera.backend.Helpers.Search
{
    /// <summary>
    /// This class is reponsible for obtaining response data from either the Chuck Norris API or the StarWars API and coverting it into the relevent return data to be used in the frontend application. 
    /// </summary>
    /// <seealso cref="tgombera.backend.Helpers.Search.ISearchHelper" />
    public class SearchHelper : ISearchHelper
    {
        private const string CHUCK_JOKES_SEARCH_ENDPOINT  = "https://api.chucknorris.io/jokes/search?query=";
        private const string SWAPI_PEOPLE_SEARCH_ENDPOINT = "https://swapi.dev/api/people/?search=";

        /// <summary>
        /// Searches the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        public ReturnSearchResults Search(string query)
        {
            GenericSearchResults<ChuckJoke>          chuckResultsRecords          = new GenericSearchResults<ChuckJoke>();
            GenericSearchResults<StarWarsPerson>     swapiResultsRecords          = new GenericSearchResults<StarWarsPerson>();
            ChuckJokesSearchResults                   chuckSearchResults           = new ChuckJokesSearchResults();
            StarWarsPeopleSearchResults              swapiSeachResults            = new StarWarsPeopleSearchResults();
            ReturnSearchResults                      returnSearchResults          = new ReturnSearchResults();
            IExternalAPIHelper                       apiHelper                    = new ExternalAPIHelper();
            IRestResponse                            response                     = null;

            try
            {

                if (!string.IsNullOrEmpty(query))
                {
                    response                    = apiHelper.CallAPI(CHUCK_JOKES_SEARCH_ENDPOINT + query);
                    chuckSearchResults          = JsonConvert.DeserializeObject<ChuckJokesSearchResults>(response.Content);

                    if(!string.IsNullOrEmpty(chuckSearchResults.total))
                    {
                        int count = int.Parse(chuckSearchResults.total);

                        if(count > 0)
                        {
                            chuckResultsRecords.results               = chuckSearchResults.result;
                            returnSearchResults.api_name              = "chuck";
                            returnSearchResults.chuck_search_results  = chuckResultsRecords.results;
                            returnSearchResults.swapi_search_results  = new List<StarWarsPerson>();
                        }
                        else
                        {
                            response                                    = null;
                            response                                    = apiHelper.CallAPI(SWAPI_PEOPLE_SEARCH_ENDPOINT + query);
                            swapiSeachResults                           = JsonConvert.DeserializeObject<StarWarsPeopleSearchResults>(response.Content);
                            swapiResultsRecords.results                 = swapiSeachResults.results;
                            returnSearchResults.api_name                = "swapi";
                            returnSearchResults.swapi_search_results    = swapiResultsRecords.results;
                            returnSearchResults.chuck_search_results    = new List<ChuckJoke>();
                        }
                    }
                }
                return returnSearchResults;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}