using System;

namespace ava.caronas.Business {
    public class ColaboradorJaExistenteException : Exception {
        public ColaboradorJaExistenteException() {}
        public override string Message => "ID já existente...";
    }
}