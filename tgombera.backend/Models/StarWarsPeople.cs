using System.Collections.Generic;

namespace tgombera.backend.Models
{
    /// <summary>
    /// StarWars People model
    /// </summary>
    public class StarWarsPeople
    {
        public string               count       { get; set; }
        public string               next        { get; set; }
        public string               previous    { get; set; }
        public List<StarWarsPerson> results     { get; set; }
    }
}
