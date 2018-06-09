using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ava.caronas.domain;
using ava.caronas.repository;

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
            var colaborador = Colaborador.CreateColaborador("nome", "nm", 4525);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatoDeEIDInvalidoException))]
        public void Colaborador_NaoPodeSerInstaciadaComEIDsMaioresQue20Caracteres() {
            var colaborador = Colaborador.CreateColaborador("nome", "nomesnomesnomes.nomes", 4525);
        }

        [TestMethod]
        public void Colaborador_EhEstanciadoCorretamente() {
            var colaborador = Colaborador.CreateColaborador("nome", "nome.n", 1000);
            Assert.AreEqual(1000, colaborador.PID);
        }
    }

    [TestClass]
    public class CaronaRepositoryTest {
        //[TestInitialize]
        //public void CaronasParaAdicionar() {
        //    int numeroDeCaronasAdicioanadas = 4;
        //}

        [TestMethod]
        public void Add_IncrementaOTamanhoDaListaDeCaronas() {
            var repository = new CaronaRepositoryIM();
            int numeroDeCaronasAdicioanadas = 4;
            for (int i = 0; i < numeroDeCaronasAdicioanadas; ++i) {
                var carona = Carona.CreateCarona(5, Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i));
                repository.Add(carona);
            }
            Assert.AreEqual(numeroDeCaronasAdicioanadas, repository.Entities.Count);
        }

        [TestMethod]
        public void Add_RetornaACaronaCorreta() {
            var repository = new CaronaRepositoryIM();
            int numeroDeCaronasAdicioanadas = 4;
            for (int i = 0; i < numeroDeCaronasAdicioanadas; ++i) {
                var carona = Carona.CreateCarona(5, Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i));
                repository.Add(carona);
            }
            var caronaParaRetornar = Carona.CreateCarona(2, Colaborador.CreateColaborador("especial", "esp.al", 2000));
            var caronaTeste = repository.Add(caronaParaRetornar);
            Assert.IsTrue(caronaParaRetornar.Equals(caronaTeste));
        }

        [TestMethod]
        public void Add_AtribuiOIDCorreto() {
            var repository = new CaronaRepositoryIM();
            int numeroDeCaronasAdicioanadas = 4;
            for (int i = 0; i < numeroDeCaronasAdicioanadas; ++i) {
                var carona = Carona.CreateCarona(5, Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i));
                repository.Add(carona);
            }
            var caronaParaRetornar = repository.Get(c => c.Ofertante.PID == 1002);
            Assert.AreEqual(3, caronaParaRetornar.ID);
        }

        [TestMethod]
        public void Get_RetornaACaronaCorreta() {
            var repository = new CaronaRepositoryIM();
            int numeroDeCaronasAdicioanadas = 4;
            for (int i = 0; i < numeroDeCaronasAdicioanadas; ++i) {
                var carona = Carona.CreateCarona(5, Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i));
                repository.Add(carona);
            }
            var caronaParaRetornar = repository.Get(c => c.Ofertante.EID == "nome.2");
            Assert.AreEqual("nome.2", caronaParaRetornar.Ofertante.EID);
        }

        [TestMethod]
        public void Get_RetornaNullQuandoNãoHaNadaParaAchar() {
            var repository = new CaronaRepositoryIM();
            int numeroDeCaronasAdicioanadas = 4;
            for (int i = 0; i < numeroDeCaronasAdicioanadas; ++i) {
                var carona = Carona.CreateCarona(5, Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i));
                repository.Add(carona);
            }
            var caronaParaRetornar = repository.Get(c => c.Ofertante.EID == "nome.10");
            Assert.IsNull(caronaParaRetornar);
        }

        [TestMethod]
        public void GetByID_RetornaACaronaCorreta() {
            var repository = new CaronaRepositoryIM();
            int numeroDeCaronasAdicioanadas = 4;
            for (int i = 0; i < numeroDeCaronasAdicioanadas; ++i) {
                var carona = Carona.CreateCarona(5, Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i));
                repository.Add(carona);
            }
            var caronaParaRetornar = repository.GetByID(3);
            Assert.AreEqual("nome2", caronaParaRetornar.Ofertante.Nome);
        }

        [TestMethod]
        public void List_RetornaAListaDeCaronasComOTamanhoCorreto() {
            var repository = new CaronaRepositoryIM();
            int numeroDeCaronasAdicioanadas = 6;
            int numeroDeCaronasRemovidas = 3;
            for (int i = 0; i < numeroDeCaronasAdicioanadas; ++i) {
                var carona = Carona.CreateCarona(5, Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i));
                repository.Add(carona);
            }
            for (int i = numeroDeCaronasRemovidas; i > 0; --i) {
                var carona = repository.GetByID(i);
                repository.Delete(carona);
            }
            Assert.AreEqual(numeroDeCaronasAdicioanadas - numeroDeCaronasRemovidas, repository.Entities.Count);
        }

        [TestMethod]
        public void ListCaronas_RetornaAListaDeCaronasDoOfertante() {
            var repository = new CaronaRepositoryIM();
            var colaboradorTeste = Colaborador.CreateColaborador("nome teste", $"nome.teste", 1000);

            int numeroDeCaronasDoColaboradorTeste = 2;
            for (int i = 0; i < numeroDeCaronasDoColaboradorTeste; ++i) {
                var carona = Carona.CreateCarona(5, colaboradorTeste);
                repository.Add(carona);

            }
            int numeroDeCaronasDeOutrosColaboradores = 4;
            for (int i = 0; i < numeroDeCaronasDeOutrosColaboradores; ++i) {
                var outrosColaborador = Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1001 + i);
                var carona = Carona.CreateCarona(5, outrosColaborador);
                repository.Add(carona);
            }

            var listaDeCaronasDoColaboradorTeste = repository.ListCaronasDoOfertante(colaboradorTeste.EID);
            int count = 0;
            foreach (var carona in listaDeCaronasDoColaboradorTeste) ++count;
            Assert.AreEqual(numeroDeCaronasDoColaboradorTeste, count);
        }
    }

    [TestClass]
    public class ColaboradorRepositoryTest {
        //[TestInitialize]
        //public void ColaboradoresParaAdicionar() {
        //    int numeroDeColaboradoresAdicioanados = 4;
        //}

        [TestMethod]
        public void Add_IncrementaOTamanhoDaListaDeColaboradores() {
            var repository = new ColaboradorRepositoryIM();
            int numeroDeColaboradoresAdicioanados = 4;
            for (int i = 0; i < numeroDeColaboradoresAdicioanados; ++i) {
                var colaborador = Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i);
                repository.Add(colaborador);
            }
            Assert.AreEqual(numeroDeColaboradoresAdicioanados, repository.Entities.Count);
        }

        [TestMethod]
        public void Add_RetornaOColaboradorCorreto() {
            var repository = new ColaboradorRepositoryIM();
            int numeroDeColaboradoresAdicioanados = 4;
            for (int i = 0; i < numeroDeColaboradoresAdicioanados; ++i) {
                var colaborador = Colaborador.CreateColaborador("nome{i}", $"nome.{i}", 1000 + i);
                repository.Add(colaborador);
            }
            var colaboradorParaRetornar = Colaborador.CreateColaborador("especial", "esp.al", 2000);
            var colaboradorTeste = repository.Add(colaboradorParaRetornar);
            Assert.IsTrue(colaboradorParaRetornar.Equals(colaboradorTeste));
        }

        [TestMethod]
        public void Add_AtribuiOIDCorreto() {
            var repository = new ColaboradorRepositoryIM();
            int numeroDeColaboradoresAdicioanados = 4;
            for (int i = 0; i < numeroDeColaboradoresAdicioanados; ++i) {
                var colaborador = Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i);
                repository.Add(colaborador);
            }
            var ColaboradorParaRetornar = repository.Get(c => c.PID == 1002);
            Assert.AreEqual(3, ColaboradorParaRetornar.ID);
        }

        [TestMethod]
        public void Get_RetornaOColaboradorCorreto() {
            var repository = new ColaboradorRepositoryIM();
            int numeroDeColaboradoresAdicioanados = 4;
            for (int i = 0; i < numeroDeColaboradoresAdicioanados; ++i) {
                var colaborador = Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i);
                repository.Add(colaborador);
            }
            var colaboradorParaRetornar = repository.Get(c => c.EID == "nome.2");
            Assert.AreEqual("nome.2", colaboradorParaRetornar.EID);
        }

        [TestMethod]
        public void Get_RetornaNullQuandoNãoHaNadaParaAchar() {
            var repository = new ColaboradorRepositoryIM();
            int numeroDeColaboradoresAdicioanados = 4;
            for (int i = 0; i < numeroDeColaboradoresAdicioanados; ++i) {
                var colaborador = Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i);
                repository.Add(colaborador);
            }
            var colaboradorParaRetornar = repository.Get(c => c.EID == "nome.10");
            Assert.IsNull(colaboradorParaRetornar);
        }

        [TestMethod]
        public void GetByID_RetornaOColaboradorCorreto() {
            var repository = new ColaboradorRepositoryIM();
            int numeroDeColaboradoresAdicioanados = 4;
            for (int i = 0; i < numeroDeColaboradoresAdicioanados; ++i) {
                var colaborador = Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i);
                repository.Add(colaborador);
            }
            var colaboradorParaRetornar = repository.GetByID(3);
            Assert.AreEqual("nome2", colaboradorParaRetornar.Nome);
        }

        [TestMethod]
        public void List_RetornaAListaDeColaboradoresComOTamanhoCorreto() {
            var repository = new ColaboradorRepositoryIM();
            int numeroDeColaboradoresAdicioanados = 6;
            int numeroDeColaboradoresRemovidas = 3;
            for (int i = 0; i < numeroDeColaboradoresAdicioanados; ++i) {
                var colaborador = Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i);
                repository.Add(colaborador);
            }
            for (int i = numeroDeColaboradoresRemovidas; i > 0; --i) {
                var Colaborador = repository.GetByID(i);
                repository.Delete(Colaborador);
            }
            Assert.AreEqual(numeroDeColaboradoresAdicioanados - numeroDeColaboradoresRemovidas, repository.Entities.Count);
        }

        [TestMethod]
        public void GetByEID_RetornaOColaboradorCorreto() {
            var repository = new ColaboradorRepositoryIM();
            int numeroDeColaboradoresAdicioanados = 4;
            for (int i = 0; i < numeroDeColaboradoresAdicioanados; ++i) {
                var colaborador = Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i);
                repository.Add(colaborador);
            }
            var colaboradorParaRetornar = repository.GetbyEID("nome.0");
            Assert.AreEqual(1, colaboradorParaRetornar.ID);
        }

        [TestMethod]
        public void GetByPID_RetornaOColaboradorCorreto() {
            var repository = new ColaboradorRepositoryIM();
            int numeroDeColaboradoresAdicioanados = 4;
            for (int i = 0; i < numeroDeColaboradoresAdicioanados; ++i) {
                var colaborador = Colaborador.CreateColaborador($"nome{i}", $"nome.{i}", 1000 + i);
                repository.Add(colaborador);
            }
            var colaboradorParaRetornar = repository.GetByPID(1003);
            Assert.AreEqual(4, colaboradorParaRetornar.ID);
        }
    }
}