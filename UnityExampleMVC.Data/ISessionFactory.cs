using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityExampleMVC.Data
{
    public interface ISessionFactory
    {
        /// <summary>
        /// Gets the current uo W.
        /// </summary>
        /// <value>The current uo W.</value>
        IUnitOfWork CurrentUoW { get; }
    }
}
