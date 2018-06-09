using System;

namespace ava.caronas.domain {
    public class OfertanteNaoPodeOcuparVagasDaCaronaException : Exception {
        public OfertanteNaoPodeOcuparVagasDaCaronaException() {}
        public override string Message => "O ofertante não pode ocupar vagas da carona";

    }
}