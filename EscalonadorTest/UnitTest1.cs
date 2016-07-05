using Microsoft.VisualStudio.TestTools.UnitTesting;
using Escalonador;
using System.Collections.Generic;
using Escalonador.Interfaces;
using Escalonador.Enums;

namespace EscalonadorTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Teste feito no metodo ChaveamentoCircular onde todas tarefa da 
        /// lista tem seu tempo de execução são diferentes.
        /// </summary>
        [TestMethod]
        public void TestChaveamentoCircular()
        {
            var ListaTarefa = new List<ITarefa>();
            ListaTarefa.Add(new Tarefa {Nome = "Teste", Identificador = 1, Prioridade = Prioridades.Alta, TempoDuracao = 30 });
            ListaTarefa.Add(new Tarefa { Nome = "Teste2", Identificador = 2, Prioridade = Prioridades.Media, TempoDuracao = 25 });
            ListaTarefa.Add(new Tarefa { Nome = "Teste3", Identificador = 3, Prioridade = Prioridades.Baixa, TempoDuracao = 60 });

            var ResultadoEsperado = new List<ITarefa>();
            ResultadoEsperado.Add(new Tarefa { Nome = "Teste", Identificador = 1, Prioridade = Prioridades.Alta, TempoDuracao = 0 });
            ResultadoEsperado.Add(new Tarefa { Nome = "Teste2", Identificador = 2, Prioridade = Prioridades.Media, TempoDuracao = 0 });
            ResultadoEsperado.Add(new Tarefa { Nome = "Teste3", Identificador = 3, Prioridade = Prioridades.Baixa, TempoDuracao = 0 });

            var AlgoritmoTeste = new Algoritmo();
            var Resultado = AlgoritmoTeste.ChaveamentoCircular(ListaTarefa);

            Assert.AreEqual(ResultadoEsperado, Resultado);
        }
    }
}
