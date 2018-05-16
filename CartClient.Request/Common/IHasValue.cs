namespace CartClient.Request.Common
{
    /// <summary>
    /// IHasValue
    /// </summary>
    /// <typeparam name="T">ValueType</typeparam>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IHasValue<T>
    {
        /// <summary>
        /// Value
        /// </summary>
        T Value { get; }
    }
}
