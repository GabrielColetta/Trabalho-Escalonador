using Escalonador.Enums;
using Escalonador.Interfaces;

namespace Escalonador
{
    /// <summary>
    /// Tarefa básica que o usuário pode criar para  fazer o escalonamento.
    /// </summary>
    public class Tarefa : ITarefa
    {
        public int Identificador { get; set; }
        public string Nome { get; set; }
        public double TempoDuracao { get; set; }
        public Prioridades Prioridade { get; set; }

        public Tarefa() { }

        /// <summary>
        /// Construtor que recebe os valores inseridos pelo usuário.
        /// </summary>
        /// <param name="identificador">O valor de seu identificador</param>
        /// <param name="nome">O nome da Tarefa</param>
        /// <param name="tempoDuracao">Seu tempo de duração</param>
        /// <param name="prioridade">Sua prioridade básica, sendo ALTA, MEDIA ou BAIXA.</param>
        public Tarefa(int identificador, string nome, double tempoDuracao, Prioridades prioridade)
        {
            this.Identificador = identificador;
            this.Nome = nome;
            this.TempoDuracao = tempoDuracao;
            this.Prioridade = prioridade;
        }
    }
}
