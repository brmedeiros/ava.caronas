using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ava.caronas.domain;

namespace UnitTests {
    [TestClass]
    public class CaronaTest {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Carona_NaoPodeSerInstanciadaSemOfertante() {
            var carona = Carona.CreateCarona(2, null);
        }

        //[TestInitialize]
        //public void InitColaborador() {
        //    var ofertante = Colaborador.CreateColaborador("nome", "nome.n", 4525);
        //}

        [TestMethod]
        [ExpectedException(typeof(VagasNaoPositivasException))]
        public void Carona_NaoPodeSerInstanciadaComNumeroDeVagasMenorQue1() {
            var carona = Carona.CreateCarona(0, Colaborador.CreateColaborador("nome", "nome.n", 4525));
        }

        [TestMethod]
        [ExpectedException(typeof(VagasMaioresQueOLimiteException))]
        public void Carona_NaoPodeSerInstanciadaComNumeroDeVagasMaiorQueOLimite() {
            var carona = Carona.CreateCarona(7, Colaborador.CreateColaborador("nome", "nome.n", 4525));
        }

        [TestMethod]
        public void OcuparVaga_ReduzONumeroDeVagasDisponiveisCorretamente() {
            var carona = Carona.CreateCarona(5, Colaborador.CreateColaborador("nome", "nome.n", 4525));
            carona.OcuparVagas();
            int vagasRestantes = 4;
            Assert.AreEqual(0, carona.ID);
            Assert.AreEqual(vagasRestantes, carona.VagasDisponiveis);
        }

        [TestMethod]
        [ExpectedException(typeof(NaoHaVagasDisponiveisException))]
        public void OcuparVaga_NaoPermiteOcuparSeONumeroDeVagasDisponiveisFor0() {
            var carona = Carona.CreateCarona(1, Colaborador.CreateColaborador("nome", "nome.n", 4525));
            carona.OcuparVagas();
            carona.OcuparVagas();
        }
    }

    [TestClass]
    public class ColaboradorTest {
        [TestMethod]
        [ExpectedException(typeof(FormatoDeEIDInvalidoException))]
        public void Colaborador_NaoPodeSerInstaciadaComEIDsMenoresQue3Caracteres() {
            var carona = Carona.CreateCarona(5, Colaborador.CreateColaborador("nome", "nm", 4525));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatoDeEIDInvalidoException))]
        public void Colaborador_NaoPodeSerInstaciadaComEIDsMaioresQue20Caracteres() {
            var carona = Carona.CreateCarona(5, Colaborador.CreateColaborador("nome", "nomesnomesnomes.nomes", 4525));
        }
    }
}
