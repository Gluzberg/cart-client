using System;
using System.Linq;
using CartClient.Request.WebRequest.Parameter;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CartClient.Request.WebRequest.Imp
{
    /// <summary>
    /// Request
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class Request<T> : IRequest<T> where T : class 
    {
        public async Task<T> Execute(IParameter<T> parameters)
        {
            //// Ctor: Url & Method Type
            HttpRequestMessage request = new HttpRequestMessage(parameters.Method, parameters.Url);

            //// Content
            if (parameters.Content != null)
            {
                request.Content = parameters.Content.Value;
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(parameters.Content.Name);
            }

            //// Header
            if (parameters.Header != null)
            {
                parameters.Header.Value.AllKeys.ToList().ForEach(k => request.Headers.Add(k, parameters.Header.Value.Get(k)));
            }           

            //// Response & Deserializiotion
            HttpResponseMessage response = await new HttpClient().SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return default(T);
            }

            try
            {
                return await parameters.Deserializer.Execute(new Deserializer.Parameter.Imp.Parameter()
                {
                    Value = response.Content.ReadAsStringAsync().Result
                });
            }
            catch (Exception e)
            {
                return default(T);
            }
        }
    }
}
