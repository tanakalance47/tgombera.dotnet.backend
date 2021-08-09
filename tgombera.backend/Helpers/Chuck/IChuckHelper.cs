using System.Collections.Generic;

using tgombera.backend.Models;

namespace tgombera.backend.Helpers.Chuck
{
    /// <summary>
    ///   This interface is responsible for defining the methods used in the ChuckHelper class.
    /// </summary>
    public interface IChuckHelper
    {
        /// <summary>
        /// Gets the categories.
        /// </summary>
        List<Category> GetCategories();

        /// <summary>
        /// Gets the random joke.
        /// </summary>
        /// <param name="category">The category.</param>
        ChuckJoke GetRandomJoke(string category);
    }
}