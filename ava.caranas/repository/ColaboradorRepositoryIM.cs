using System;
using System.Collections.Generic;
using System.Text;
using ava.caronas.domain;

namespace ava.caronas.repository
{
    public class ColaboradorRepositoryIM : ARepositoryIM<Colaborador>, IColaboradorRepository {

        public Colaborador GetbyEID(string eid) {
            return Get(c => c.EID == eid);
        }

        public Colaborador GetByPID(int pid) {
            return Get(c => c.PID == pid);
        }
    }
}
