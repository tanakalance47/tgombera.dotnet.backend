using tgombera.backend.Models;

namespace tgombera.backend.Helpers.Search
{
    /// <summary>
    ///   This interface is responsible for defining the methods used in the SearchHelper class.
    /// </summary>
    public interface ISearchHelper
    {
        /// <summary>
        /// Searches the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        ReturnSearchResults Search(string query);
    }
}