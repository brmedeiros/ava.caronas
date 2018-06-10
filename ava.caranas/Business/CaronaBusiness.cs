using System;
using System.Collections.Generic;
using System.Text;
using ava.caronas.domain;
using ava.caronas.repository;

namespace ava.caronas.Business {
    public class CaronaBusiness : ABusiness<Carona> {
        public CaronaBusiness(IRepository<Carona> repository) : base(repository) { }
    }
}
