using System.Collections.Specialized;

namespace CartClient.Request.WebRequest.Parameter.Header.Imp
{
    /// <summary>
    /// Header
    /// </summary>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public class Header : IHeader
    {
        /// <summary>
        /// Header
        /// </summary>
        /// <param name="value">Value</param>
        public Header(NameValueCollection value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Values
        /// </summary>
        public NameValueCollection Value { get; private set; }
    }
}
