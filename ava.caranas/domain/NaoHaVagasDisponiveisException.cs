using System;

namespace ava.caranas.domain {
    public class NaoHaVagasDisponiveisException : Exception {
        public NaoHaVagasDisponiveisException() {}
        public override string Message => "Não há vagas disponíveis nesta carona.";
    }
}