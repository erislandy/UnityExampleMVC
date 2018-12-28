using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityExampleMVC.Domain.Interfaces
{
    public interface ICategoryManager
    {
        /// <summary>
        /// Return a list of category to browse
        /// </summary>
        /// <returns></returns>
        IEnumerable<Category> GetCategoryToBrowse();

        /// <summary>
        /// Return a category by given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Category GetCategoryById(int id);

        /// <summary>
        /// Persisten a category
        /// </summary>
        /// <param name="category"></param>
        void Save(Category category);

        /// <summary>
		/// Revert changes of a given category to his current persisted state.
		/// </summary>
		/// <param name="album"></param>
		void Cancel(Category category);

        /// <summary>
        /// Return true if the album is valid.
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        bool IsValid(Category category);
    }
}
