using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uNhAddIns.Entities;

namespace UnityExampleMVC.Data
{
    public interface IDao<T> : IDaoReadOnly<T>
        where T : Entity
    {
        T MakePersistent(T entity);
        void MakeTransient(T entity);
    }
}
