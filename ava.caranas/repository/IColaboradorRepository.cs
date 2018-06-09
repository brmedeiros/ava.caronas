using System;
using System.Collections.Generic;
using System.Text;
using ava.caronas.domain;

namespace ava.caronas.repository
{
    public interface IColaboradorRepository {
        Colaborador GetbyEID(string eid);
        Colaborador GetByPID(int pid);
    }
}
