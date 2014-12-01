using System.Threading.Tasks;

namespace Catering.Data.Repositories.Common
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