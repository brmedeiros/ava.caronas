using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ava.caranas.domain {
    class Carona {
        [Required]
        public Colaborador Ofertante { get; set; }
        [Required]
        public int VagasTotais { get; set; }
        private int _vagasDisponiveis { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public Endereco EnderecoSaida { get; set; }
        public Endereco EnderecoChegada { get; set; }

        private Carona(int vagas, Colaborador ofertante) {
            VagasTotais = _vagasDisponiveis = vagas;
            Ofertante = ofertante;
        }
    }
}
