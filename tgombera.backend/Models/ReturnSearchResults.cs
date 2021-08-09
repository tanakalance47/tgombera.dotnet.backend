using System.Collections.Generic;

namespace tgombera.backend.Models
{
    /// <summary>
    /// Return search results model that contains search metadata returned to the frontend application.
    /// </summary>
    public class ReturnSearchResults
    {
        public string                   api_name                { get; set; }
        public List<ChuckJoke>          chuck_search_results    { get; set; }
        public List<StarWarsPerson>     swapi_search_results    { get; set; }
    }
}