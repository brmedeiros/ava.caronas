using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ava.caronas.domain;
using ava.caronas.repository;

namespace ava.caronas.Business {
    public class ColaboradorBusiness {

        private ColaboradorRepositoryIM _repository { get; set; }

        public ColaboradorBusiness(ColaboradorRepositoryIM repository) {
            _repository = repository;
        }

        public bool Exists(Colaborador colaborador) {
            if (_repository.Get(e => e.ID == colaborador.ID) != null) return true;
            if (_repository.Get(e => e.EID == colaborador.EID) != null) return true;
            if (_repository.Get(e => e.PID == colaborador.PID) != null) return true;
            else return false;
        }

        public Colaborador Add(Colaborador colaborador) {
            if (Exists(colaborador)) throw new ColaboradorJaExistenteException();
            return _repository.Add(colaborador);
        }

        public int Delete(Colaborador colaborador) {
            return _repository.Delete(colaborador);
        }

        public void Edit(Colaborador colaborador) {
            throw new NotImplementedException();
        }

        public IEnumerable<Colaborador> List() {
            return _repository.List();
        }

        public IEnumerable<Colaborador> List(Expression<Func<Colaborador, bool>> predicate) {
            return _repository.List().AsQueryable().Where(predicate).ToList();
        }
    }
}
