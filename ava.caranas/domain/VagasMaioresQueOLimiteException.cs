using System;

namespace ava.caranas.domain {
    public class VagasMaioresQueOLimiteException : Exception {
        public VagasMaioresQueOLimiteException() {}
        public override string Message => "O número de vagas não deve exceder 6.";
    }
}