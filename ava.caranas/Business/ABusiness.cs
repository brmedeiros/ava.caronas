using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ava.caronas.domain;
using ava.caronas.repository;

namespace ava.caronas.Business {
    public abstract class ABusiness<T> : IBusiness<T> where T : ABaseEntitiy {
        protected IRepository<T> _repository { get; set; }

        public ABusiness(IRepository<T> repository) {
            _repository = repository;
        }
        public virtual bool Exists(T entity) {
            if (_repository.Get(e => e.ID == entity.ID) != null) return true;
            else return false;
        }

        public T Add(T entity) {
            if (Exists(entity)) throw new EntidadeJaExistenteException();
            return _repository.Add(entity);
        }

        public int Delete(T entity) {
            return _repository.Delete(entity);
        }

        public void Edit(T entity) {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> predicate) {
            return _repository.List().AsQueryable().Where(predicate).FirstOrDefault();
        }

        public T GetByID(int id) {
            return Get(e => e.ID == id);
        }

        public IEnumerable<T> List() {
            return _repository.List();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate) {
            return _repository.List().AsQueryable().Where(predicate).ToList();
        }
    }
}
