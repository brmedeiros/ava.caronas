﻿using System;

namespace ava.caronas.domain {
    public class VagasNaoPositivasException : Exception {
        public VagasNaoPositivasException() {}
        public override string Message => "O numero de vagas deve ser maior que zero.";
    }
}