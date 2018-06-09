using System;

namespace ava.caranas.domain {
    public class FormatoDeEIDInvalidoException : Exception {
        public FormatoDeEIDInvalidoException() {}
        public override string Message => "EID deve conter entre 3 e 20 caracteres.";
    }
}