using System.Collections.Generic;
using System.Net.Http;

namespace CartClient.Request.WebRequest.Parameter.Content.Imp
{
    /// <summary>
    /// FormUrlEncodedContent
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class FormUrlEncodedContent : IFormUrlEncodedContent
    {
        /// <summary>
        /// FormUrlEncodedContent
        /// </summary>
        /// <param name="values">Values</param>
        public FormUrlEncodedContent(IEnumerable<KeyValuePair<string, string>> values)
        {
            this.Values = values;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get { return FormUrlEncodedContent.NameValue; } }

        /// <summary>
        /// Value
        /// </summary>
        public HttpContent Value
        { 
            get
            {
                return new System.Net.Http.FormUrlEncodedContent(this.Values);
            }
        }

        /// <summary>
        /// Values
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Values { get; private set; }

        /// <summary>
        /// NameValue
        /// </summary>
        private const string NameValue = "application/x-www-form-urlencoded";
    }
}
