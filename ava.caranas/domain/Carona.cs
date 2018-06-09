using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ava.caronas.domain {
    public class Carona : ABaseEntityBlockable {
        private const int LIMITE_VAGAS = 6;

        public Colaborador Ofertante { get; set; }
        public ICollection<Colaborador> Caroneiros { get; set; } = new List<Colaborador>();
        public int VagasTotais { get; set; }
        public int VagasDisponiveis { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public Endereco EnderecoSaida { get; set; }
        public Endereco EnderecoChegada { get; set; }

        private Carona(int vagas, Colaborador ofertante) {
            VagasTotais = VagasDisponiveis = vagas;
            Ofertante = ofertante;
        }

        public static Carona CreateCarona(int vagas, Colaborador ofertante) {
            if (ofertante == null) throw new ArgumentNullException();
            if (vagas < 1) throw new VagasNaoPositivasException();
            if (vagas > LIMITE_VAGAS) throw new VagasMaioresQueOLimiteException();
            return new Carona(vagas, ofertante);
        }

        private bool ExistCaroneiro(string eid) {
            if (Caroneiros.Where(c => c.EID == eid).Any() == true) return true;
            return false;
        }

        public void OcuparVagas(Colaborador caroneiro) {
            if (VagasDisponiveis == 0) throw new NaoHaVagasDisponiveisException();
            if (ExistCaroneiro(caroneiro.EID)) throw new CaroneiroJaPresenteException();
            if (caroneiro.EID == Ofertante.EID) throw new OfertanteNaoPodeOcuparVagasDaCaronaException();
            Caroneiros.Add(caroneiro);
            VagasDisponiveis = VagasDisponiveis - 1;
        }
    }
}
