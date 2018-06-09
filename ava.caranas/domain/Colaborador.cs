using System;
using System.Collections.Generic;
using System.Text;

namespace ava.caranas.domain {
    public class Colaborador : ABaseEntityBlockable {
        public string Nome { get; set; }
        public string EID { get; set; }
        public int PID { get; set; }

        private Colaborador(string nome, string eid, int pid) {
            Nome = nome;
            eid = EID;
            pid = PID;
        }

        public static Colaborador CreateColaborador(string nome, string eid, int pid) {
            if (nome == null || eid == null) throw new ArgumentNullException();
            if (eid.Length < 3 || eid.Length > 20) throw new FormatoDeEIDInvalidoException();
            return new Colaborador(nome, eid, pid);
        }
    }
}
