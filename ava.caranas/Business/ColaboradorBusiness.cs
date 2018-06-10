using System;
using System.Text;
using ava.caronas.domain;
using ava.caronas.repository;

namespace ava.caronas.Business {
    public class ColaboradorBusiness : ABusiness<Colaborador> {

        public ColaboradorBusiness(IRepository<Colaborador> repository) : base(repository) { }

        public override bool Exists(Colaborador colaborador) {
            if (base.Exists(colaborador)) return true;
            if (_repository.Get(e => e.EID == colaborador.EID) != null) return true;
            if (_repository.Get(e => e.PID == colaborador.PID) != null) return true;
            else return false;
        }
    }
}
