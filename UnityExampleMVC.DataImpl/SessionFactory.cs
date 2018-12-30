using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityExampleMVC.Data;

namespace UnityExampleMVC.DataImpl
{
    public class SessionFactory : ISessionFactory
    {
        private IUnitOfWork uow;

        #region ISessionFactory Members

        /// <summary>
        /// Gets the current uo W.
        /// </summary>
        /// <value>The current uo W.</value>
        public IUnitOfWork CurrentUoW
        {
            get
            {
                if (uow == null)
                {
                    uow = GetUnitOfWork();
                }

                return uow;
            }
        }

        #endregion

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <returns></returns>
        private IUnitOfWork GetUnitOfWork()
        {
            var orm = new UnityExampleMVCContext();
            return new UnitOfWork(orm);
        }
    }

}
