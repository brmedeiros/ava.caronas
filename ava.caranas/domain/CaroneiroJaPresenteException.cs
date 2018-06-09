using System;

namespace ava.caronas.domain {
    public class CaroneiroJaPresenteException : Exception {
        public CaroneiroJaPresenteException() {}
        public override string Message => "Caroneiro já presente nesta carona.";
    }
}