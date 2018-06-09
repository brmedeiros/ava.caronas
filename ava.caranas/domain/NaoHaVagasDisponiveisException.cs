using System;

namespace ava.caronas.domain {
    public class NaoHaVagasDisponiveisException : Exception {
        public NaoHaVagasDisponiveisException() {}
        public override string Message => "Não há vagas disponíveis nesta carona.";
    }
}