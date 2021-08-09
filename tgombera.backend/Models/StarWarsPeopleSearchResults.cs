using System.Collections.Generic;

namespace tgombera.backend.Models
{
    /// <summary>
    ///  The Search Results model for a search result from the StarWars API response data.
    /// </summary>
    public class StarWarsPeopleSearchResults
    {
        public string               count       { get; set; }
        public string               next        { get; set; }
        public string               previous    { get; set; }
        public List<StarWarsPerson> results     { get; set; }
    }
}