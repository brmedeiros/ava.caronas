using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ava.caronas.domain;

namespace ava.caronas.repository
{
    public abstract class ARepositoryIM<T> : IRepository<T> where T : ABaseEntitiy {
        public ICollection<T> Entities { get; set; }
        public T Add(T entity) {
            Entities.Add(entity);
            return entity;
        }

        public int Delete(T entity) {
            var id = entity.ID;
            Entities.Remove(entity);
            return id;
        }

        public T Get(Expression<Func<T, bool>> predicate) {
            return Entities.AsQueryable().Where(predicate).FirstOrDefault();
        }

        public T GetById(int id) {
            return Get(e => e.ID == id);
        }

        public IEnumerable<T> List() {
            return List(e => true);
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> predicate) {
            return Entities.AsQueryable().Where(predicate).ToList();
        }
    }
}
