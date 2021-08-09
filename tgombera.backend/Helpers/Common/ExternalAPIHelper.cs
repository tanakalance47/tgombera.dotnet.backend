using RestSharp;

namespace tgombera.backend.Helpers.Common
{
    /// <summary>
    /// This class is responsible for making calls to any external API as per the provived end point.
    /// </summary>
    /// <seealso cref="tgombera.backend.Helpers.Common.IExternalAPIHelper" />
    public class ExternalAPIHelper : IExternalAPIHelper
    {
        /// <summary>
        /// Calls the API.
        /// </summary>
        /// <param name="endPoint">The end point.</param>
        /// <returns>
        /// A Response
        /// </returns>
        public IRestResponse CallAPI(string endPoint)
        {
            try
            {
                var             client              = new RestClient(endPoint);
                client.Timeout                      = -1;
                var             request             = new RestRequest(Method.GET);
                IRestResponse   response            = client.Execute(request);

                return response;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}