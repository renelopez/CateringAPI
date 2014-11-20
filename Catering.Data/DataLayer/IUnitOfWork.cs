using System.Threading.Tasks;

namespace Catering.Data.DataLayer
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        Task<int> CommitAsync();
    }
}