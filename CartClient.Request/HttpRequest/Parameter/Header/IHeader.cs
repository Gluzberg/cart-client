using CartClient.Request.Common;
using System.Collections.Specialized;

namespace CartClient.Request.WebRequest.Parameter.Header
{
    /// <summary>
    /// IHeader
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IHeader : IHasValue<NameValueCollection>
    {
    }
}
