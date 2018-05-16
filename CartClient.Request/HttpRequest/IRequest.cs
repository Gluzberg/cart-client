using CartClient.Request.Common;
using CartClient.Request.WebRequest.Parameter;

namespace CartClient.Request.WebRequest
{
    /// <summary>
    /// IRequest
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IRequest<T> : IExecuteable<IParameter<T>, T> where T : class
    {
    }
}
