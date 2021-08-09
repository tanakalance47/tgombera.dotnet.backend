using System.Collections.Generic;

namespace tgombera.backend.Models
{
    /// <summary>
    /// Generic search results model.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericSearchResults<T>
    {
        public List<T> results { get; set; }
    }
}