using System;

namespace ava.caronas.domain {
    public class CaroneiroNaoEstaPresenteException : Exception {
        public CaroneiroNaoEstaPresenteException() {}
        public override string Message => "Caroneiro não está presente na carona.";
    }
}