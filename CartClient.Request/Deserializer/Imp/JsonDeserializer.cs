using CartClient.Request.Deserializer.Parameter;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CartClient.Request.Deserializer.Imp
{
    /// <summary>
    /// JsonDeserializer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class JsonDeserializer<T> : IDeserializer<T> where T : class
    {
        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="parameters">parameters</param>
        /// <returns>Execution result</returns>
        public Task<T> Execute(IParameter parameters)
        {
            return Task.Run(() =>
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(parameters.Value, new JsonSerializerSettings() { });
                }
                catch (Exception)
                {
                    return default(T);
                }
            });
        }
    }
}
