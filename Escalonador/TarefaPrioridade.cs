using Escalonador.Enums;
using Escalonador.Interfaces;
using System;
using System.Collections.Generic;

namespace Escalonador
{
    /// <summary>
    /// Classe especial para o metodo de escalonamento com prioridade.
    /// </summary>
    class TarefaPrioridade : Tarefa, ITarefa
    {
        public SegundaPrioridades PrioridadeExtra { get; set; }

        public TarefaPrioridade(ITarefa AntigaTarefa)
        {
            SegundaPrioridades[] todosEnums = {
                SegundaPrioridades.Um,
                SegundaPrioridades.Dois,
                SegundaPrioridades.Tres,
                SegundaPrioridades.Quatro,
                SegundaPrioridades.Cinco,
                SegundaPrioridades.Seis};
            Random aleatorio = new Random();

            this.Identificador = AntigaTarefa.Identificador;
            this.Nome = AntigaTarefa.Nome;
            this.Prioridade = AntigaTarefa.Prioridade;
            this.TempoDuracao = AntigaTarefa.TempoDuracao;
            this.PrioridadeExtra = todosEnums[aleatorio.Next(todosEnums.Length)];
        }

        private TarefaPrioridade() { }


        /// <summary>
        /// Metodo que faz a seleção do valor com maior prioridade entre eles.
        /// </summary>
        /// <param name="Valores"></param>
        /// <returns></returns>
        public static TarefaPrioridade EncontrarTarefaComMaiorPrioridade(List<TarefaPrioridade> Valores)
        {
            var prioridadeProcurar = Prioridades.Alta;
            var segundaPrioridadeProcurar = SegundaPrioridades.Seis;
            foreach (var item in Valores)
            {
                while (segundaPrioridadeProcurar != SegundaPrioridades.Zero)
                {
                    if (item.Prioridade == prioridadeProcurar)
                    {
                        if (item.PrioridadeExtra == segundaPrioridadeProcurar)
                        {
                            return item;
                        }
                        else
                        {
                            segundaPrioridadeProcurar = segundaPrioridadeProcurar - 1;
                        }
                    }
                    else
                    {
                        prioridadeProcurar = prioridadeProcurar - 1;
                        segundaPrioridadeProcurar = SegundaPrioridades.Seis;
                    }
                }

            }
            return new TarefaPrioridade();
        }
    }
}
