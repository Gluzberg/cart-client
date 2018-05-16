using CartClient.Request.WebRequest.Parameter.ContentType.Base;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CartClient.Request.WebRequest.Parameter.Content.Imp
{
    /// <summary>
    /// FormUrlEncodedContent
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class JsonContent : IContent
    {
        /// <summary>
        /// JsonContent
        /// </summary>
        /// <param name="values">Values</param>
        public JsonContent(string value)
        {
            this.RawValue = value;
        }

        /// <summary>
        /// JsonContent
        /// </summary>
        /// <param name="value"></param>
        public JsonContent(object value)
        {
            this.RawValue = JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get { return JsonContent.NameValue; } }

        /// <summary>
        /// Value
        /// </summary>
        public HttpContent Value
        { 
            get
            {
                return new StringContent(this.RawValue, Encoding.UTF8, JsonContent.NameValue);
            }
        }

        /// <summary>
        /// Values
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Values { get; private set; }

        /// <summary>
        /// RawValue
        /// </summary>
        protected readonly string RawValue;

        /// <summary>
        /// NameValue
        /// </summary>
        private const string NameValue = "application/json";
    }
}
