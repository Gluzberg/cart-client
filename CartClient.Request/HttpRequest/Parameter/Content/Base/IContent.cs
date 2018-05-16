using CartClient.Request.Common;
using System.Net.Http;

namespace CartClient.Request.WebRequest.Parameter.ContentType.Base
{
    /// <summary>
    /// IContent
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IContent : IHasName, IHasValue<HttpContent>
    {
    }
}
