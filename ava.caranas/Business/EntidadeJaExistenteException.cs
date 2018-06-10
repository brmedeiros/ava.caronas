using System;

namespace ava.caronas.Business {
    public class EntidadeJaExistenteException : Exception {
        public EntidadeJaExistenteException() { }
        public override string Message => "Registro já existente...";
    }
}