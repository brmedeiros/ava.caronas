using System;

namespace ava.caronas.domain {
    public class ColaboradorBloqueadoException : Exception {
        public ColaboradorBloqueadoException() { }
        public override string Message => "Colaborador(a) bloquead@!!";
    }
}