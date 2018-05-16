using CartClient.Request.Deserializer;
using CartClient.Request.WebRequest.Parameter.ContentType.Base;
using CartClient.Request.WebRequest.Parameter.Header;
using System.Net.Http;

namespace CartClient.Request.WebRequest.Parameter.Imp
{
    /// <summary>
    /// Parameter
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class Parameter<T> : IParameter<T> where T : class
    {
        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public IContent Content { get; set; }

        /// <summary>
        /// Deserializer
        /// </summary>
        public IDeserializer<T> Deserializer { get; set; }

        /// <summary>
        /// Header
        /// </summary>
        public IHeader Header { get; set; }

        /// <summary>
        /// Method
        /// </summary>
        public HttpMethod Method { get; set; }
    }
}
