using CartClient.Request.Deserializer;
using CartClient.Request.WebRequest.Parameter.ContentType.Base;
using CartClient.Request.WebRequest.Parameter.Header;
using System.Net.Http;

namespace CartClient.Request.WebRequest.Parameter
{
    /// <summary>
    /// IParameter
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IParameter<T> where T : class
    {
        /// <summary>
        /// Url
        /// </summary>
        string Url { get; }

        /// <summary>
        /// Method
        /// </summary>
        HttpMethod Method { get; }

        /// <summary>
        /// IContent
        /// </summary>
        IContent Content { get; }

        /// <summary>
        /// Header
        /// </summary>
        IHeader Header { get; }

        /// <summary>
        /// Deserializer
        /// </summary>
        IDeserializer<T> Deserializer { get; }
    }
}
