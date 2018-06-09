using System;
using System.Collections.Generic;
using System.Text;

namespace ava.caranas.domain {
    class Endereco {
        public string Logradouro { get; set; }
        public string Numero { get; set; } //string type accomodates 's/n' entries
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}
