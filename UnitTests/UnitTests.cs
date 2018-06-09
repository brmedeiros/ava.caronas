using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ava.caranas.domain;

namespace UnitTests {
    [TestClass]
    public class CaronaTest {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Carona_NaoPodeSerInstanciadaSemOfertante() {
            var carona = Carona.CreateCarona(2, null);
        }

        [TestMethod]
        [ExpectedException(typeof(VagasNaoPositivasException))]
        public void Carona_NaoPodeSerInstanciadaComNumeroDeVagasMenorQue1() {
            var carona = Carona.CreateCarona(0, new Colaborador());
        }

        [TestMethod]
        [ExpectedException(typeof(VagasMaioresQueOLimiteException))]
        public void Carona_NaoPodeSerInstanciadaComNumeroDeVagasMaiorQueOLimite() {
            var carona = Carona.CreateCarona(7, new Colaborador());
        }

        [TestMethod]
        public void OcuparVaga_ReduzONumeroDeVagasDisponiveisCorretamente() {
            var carona = Carona.CreateCarona(5, new Colaborador());
            carona.OcuparVagas();
            int vagasRestantes = 4;
            Assert.AreEqual(0, carona.ID);
            Assert.AreEqual(vagasRestantes, carona.VagasDisponiveis);
        }

        [TestMethod]
        [ExpectedException(typeof(NaoHaVagasDisponiveisException))]
        public void OcuparVaga_NaoPermiteOcuparSeONumeroDeVagasDisponiveisFor0() {
            var carona = Carona.CreateCarona(1, new Colaborador());
            carona.OcuparVagas();
            carona.OcuparVagas();
        }
    }
}
