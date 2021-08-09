using System.Collections.Generic;

using RestSharp;
using Newtonsoft.Json;

using tgombera.backend.Helpers.Common;
using tgombera.backend.Models;

namespace tgombera.backend.Helpers.Chuck
{
    /// <summary>
    /// This class is reponsible for getting response data from the Chuck Norris API and coverting it into the relevent return data to be used in the frontend application. 
    /// </summary>
    /// <seealso cref="tgombera.backend.Helpers.Chuck.IChuckHelper" />
    public class ChuckHelper : IChuckHelper
    {
        private const string CHUCK_CATEGORIES_ENDPOINT          = "https://api.chucknorris.io/jokes/categories";
        private const string RANDOM_CHUCK_NORRIS_JOKE_ENDPOINT  = "https://api.chucknorris.io/jokes/random?category=";

        /// <summary>
        /// Gets the categories.
        /// </summary>
        public List<Category> GetCategories()
        {
            IExternalAPIHelper apiHelper                    = new ExternalAPIHelper();
            IRestResponse      response                     = null;
            List<string>       categoriesResponseRecords    = new List<string>();
            List<Category>     categories                   = new List<Category>();

            try
            {
                response                        = apiHelper.CallAPI(CHUCK_CATEGORIES_ENDPOINT);   
                categoriesResponseRecords       = JsonConvert.DeserializeObject<List<string>>(response.Content);

                if (categoriesResponseRecords.Count > 0)
                {
                    for (int i = 0; i < categoriesResponseRecords.Count; i++)
                    {
                        Category category = new Category()
                        {
                            id      = i,
                            name    = categoriesResponseRecords[i]
                        };
                        categories.Add(category);
                    }
                }     
                return categories;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the random joke.
        /// </summary>
        /// <param name="category">The category.</param>
        public ChuckJoke GetRandomJoke(string category)
        {
            try
            {
                IExternalAPIHelper  apiHelper   = new ExternalAPIHelper();
                IRestResponse       response    = null;
                ChuckJoke           randomJoke  = new ChuckJoke();

                response        = apiHelper.CallAPI(RANDOM_CHUCK_NORRIS_JOKE_ENDPOINT + category);
                randomJoke      = JsonConvert.DeserializeObject<ChuckJoke>(response.Content);

                return randomJoke;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}