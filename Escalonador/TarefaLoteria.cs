using Escalonador.Interfaces;
using System;

namespace Escalonador
{
    /// <summary>
    /// Classe especial para o método de loteria, onde possui atributo token para o sorteio.
    /// </summary>
    public class TarefaLoteria : Tarefa, ITarefa
    {
        public int Token { get; set; }

        /// <summary>
        /// Faz a construção de um novo objeto com o atributo token para o sorteio.
        /// </summary>
        /// <param name="TarefaAntiga"></param>
        public TarefaLoteria(ITarefa TarefaAntiga)
        {
            this.Identificador = TarefaAntiga.Identificador;
            this.Nome = TarefaAntiga.Nome;
            this.Prioridade = TarefaAntiga.Prioridade;
            this.TempoDuracao = TarefaAntiga.TempoDuracao;
            this.Token = new Random().Next(1, 10);
        }

        /// <summary>
        /// Metodo que faz o sorteio de um novo valor para ser escalonado.
        /// </summary>
        /// <returns>Retorna o valor que foi sorteado.</returns>
        public static int FazerSorteio()
        {
            return new Random().Next(1, 10); //arrumar aqui!
        }
    }
}
