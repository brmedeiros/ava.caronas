using System;

namespace ava.caronas.domain {
    public class CaroneiroNaoEstaPresenteException : Exception {
        public CaroneiroNaoEstaPresenteException() {}
        public override string Message => "Caroneir@ não está presente na carona.";
    }
}