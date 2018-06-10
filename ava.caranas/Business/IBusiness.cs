using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ava.caronas.domain;

namespace ava.caronas.Business {
    public interface IBusiness<T> where T : ABaseEntitiy {
        bool Exists(T entitiy);
        T Add(T entity);
        int Delete(T entity);
        void Edit(T entity);
        T Get(Expression<Func<T, bool>> predicate);
        T GetByID(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
    }
}