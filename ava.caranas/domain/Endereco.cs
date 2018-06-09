using System;
using System.Collections.Generic;
using System.Text;

namespace ava.caronas.domain {
    public class Endereco : ABaseEntitiy {
        public string Logradouro { get; set; }
        public string Numero { get; set; } //string type accomodates 's/n' entries
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}
