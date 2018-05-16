using System.Threading.Tasks;

namespace CartClient.Request.Common
{
    /// <summary>
    /// IExecuteable
    /// </summary>
    /// <typeparam name="P">Paraeters type</typeparam>
    /// <typeparam name="R">Result Type</typeparam>
    /// <author>
    /// M. Gluzberg, May-2018
    /// </author>
    public interface IExecuteable<P, R> where R : class
    {
        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="parameters">Parameter for execution</param>
        /// <returns>Result</returns>
        Task<R> Execute(P parameters);
    }
}
