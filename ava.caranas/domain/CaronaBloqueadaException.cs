using System;

namespace ava.caronas.domain {
    public class CaronaBloqueadaException : Exception {
        public CaronaBloqueadaException() {}
        public override string Message => "Carona bloqueada!!";
    }
}