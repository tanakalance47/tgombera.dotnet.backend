using System.Collections.Generic;

namespace tgombera.backend.Models
{
    /// <summary>
    /// The Search Results model for a search result from the Chuck Norris API response data.
    /// </summary>
    public class ChuckJokesSearchResults
    {
        public string           total   { get; set; }
        public List<ChuckJoke>  result  { get; set; }
    }
}