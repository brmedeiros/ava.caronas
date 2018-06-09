using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ava.caronas.domain;

namespace ava.caronas.repository
{
    public interface IRepository<T> where T : ABaseEntitiy {
        T Add(T entity);
        int Delete(T entity); //returns ID of deleted entity
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
    }
}
