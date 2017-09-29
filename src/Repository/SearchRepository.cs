using System.Collections.Generic;
using System.Threading.Tasks;
using src.Model;

namespace src.Repository
{
    /// <summary>
    /// Represents a interface os search
    /// </summary>
    public interface SearchRepository<T>
    {
        /// <summary>
        /// Search itens
        /// </summary>
        /// <param name="query">Query to search repository</param>
        /// <returns>Return iterable collection of T</returns>
        Task<IEnumerable<T>> Search(string query);

        /// <summary>
        /// Add itens on repository
        /// </summary>
        /// <param name="itens">Collection of T</param>
        Task Add(IEnumerable<T> itens);

    }
}