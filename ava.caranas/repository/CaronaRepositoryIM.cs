using System;
using System.Collections.Generic;
using System.Text;
using ava.caronas.domain;

namespace ava.caronas.repository {
    public class CaronaRepositoryIM : ARepositoryIM<Carona> {
        public IEnumerable<Carona> ListCaronasDoOfertante(string eid) {
            return List(c => c.Ofertante.EID == eid);
        }
    }
}
