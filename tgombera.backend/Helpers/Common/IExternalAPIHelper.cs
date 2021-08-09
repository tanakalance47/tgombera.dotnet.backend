using RestSharp;

namespace tgombera.backend.Helpers.Common
{
    /// <summary>
    ///   This interface is responsible for defining the methods used in the ExternalAPIHelper class.
    /// </summary>
    public interface IExternalAPIHelper
    {
        /// <summary>
        /// Calls the API.
        /// </summary>
        /// <param name="endPoint">The end point.</param>
        /// <returns>A Response</returns>
        IRestResponse CallAPI(string endPoint);
    }
}