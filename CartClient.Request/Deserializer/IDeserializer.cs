using CartClient.Request.Common;
using CartClient.Request.Deserializer.Parameter;

namespace CartClient.Request.Deserializer
{
    /// <summary>
    /// IDeserializer
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IDeserializer<T> : IExecuteable<IParameter, T> where T : class
    {
    }
}
