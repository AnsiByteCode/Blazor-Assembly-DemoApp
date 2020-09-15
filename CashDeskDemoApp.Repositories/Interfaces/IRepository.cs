using System.Collections.Generic;
using System.Threading.Tasks;

namespace CashDeskDemoApp.Repositories.Interfaces
{
    /// <summary>
    /// IRepository interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<string> Delete(string id);
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAll();
        /// <summary>
        /// Creates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<T> Create(T model);
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> GetById(string id);
        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<T> Update(T model);
    }
}
