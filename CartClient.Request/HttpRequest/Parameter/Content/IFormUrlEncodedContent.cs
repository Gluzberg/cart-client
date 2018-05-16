using CartClient.Request.WebRequest.Parameter.ContentType.Base;
using System.Collections.Generic;

namespace CartClient.Request.WebRequest.Parameter.Content
{
    /// <summary>
    /// IFormUrlEncodedContent
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IFormUrlEncodedContent : IContent
    {
        IEnumerable<KeyValuePair<string, string>> Values { get; }
    }
}
