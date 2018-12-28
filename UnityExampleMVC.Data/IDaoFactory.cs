using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uNhAddIns.Entities;

namespace UnityExampleMVC.Data
{
    public interface IDaoFactory
    {
        IDaoReadOnly<TEntity> GetDaoReadOnlyOf<TEntity>() where TEntity : Entity;
        IDao<TEntity> GetDaoOf<TEntity>() where TEntity : Entity;
        TDao GetSpecializedDao<TDao, TEntity>() where TDao : class, IDao<TEntity> where TEntity : Entity;
    }
}
