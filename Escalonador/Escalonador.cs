using Escalonador.Enums;
using Escalonador.Interfaces;
using System;
using System.Collections.Generic;

namespace Escalonador
{
    public class Escalonador : IEscalonador
    {
        public List<ITarefa> Tarefas { get; private set; }
        public IAlgoritmo Algoritmos { get; private set; }

        public void AdicionarTarefa()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Digite um identificador para a tarefa: ");
                var identificador = int.Parse(Console.ReadLine());

                Console.WriteLine("Agora é necessário um nome para a tarefa:");
                var nome = Console.ReadLine();

                Console.WriteLine("O tempo de duração, em segundos para facilitar o exemplo.");
                var tempoDuracao = double.Parse(Console.ReadLine());

                Console.WriteLine("Agora escolha a prioridade: ALTA(1), MEDIA(2) ou BAIXA(3).");
                Console.WriteLine("Caso digitado incorreto, o valor default é BAIXA(3)");
                var prioridadeNumerico = int.Parse(Console.ReadLine());
                Prioridades prioridade = (Prioridades)prioridadeNumerico;
                Tarefas.Add(new Tarefa(identificador, nome, tempoDuracao, prioridade));
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Você esta adicionando valores não aceitos!");
                Console.ReadKey();
            }
            
        }

        public void RodarTarefa()
        {
            if (this.HasTarefas())
            {
                Console.Clear();
                Console.WriteLine("Escolha entre os seguintes algoritmos:");
                Console.WriteLine("1 - Chaveamento Circular!");
                Console.WriteLine("2 - Algoritmo de Loteria!");
                Console.WriteLine("3 - Escalonamento por Prioridades!");
                Console.WriteLine("4 - Primeiro a chegar, primeiro a ser executado!");
                Console.WriteLine("5 - Tarefa mais curta primeiro!");
                Console.WriteLine("0 - Voltar!");
                var escolha = int.Parse(Console.ReadLine());
                switch (escolha)
                {
                    case 1:
                        Algoritmos.ChaveamentoCircular(this.Tarefas); break;
                    case 2:
                        Algoritmos.ChaveamentoLoteria(this.Tarefas); break;
                    case 3:
                        Algoritmos.EscalonamentoPorPrioridades(this.Tarefas); break;
                    case 4:
                        Algoritmos.PrimeiroChegarPrimeiroServido(this.Tarefas); break;
                    case 5:
                        Algoritmos.TarefaMaisCurta(this.Tarefas); break;
                    case 0:
                        return;
                    default:
                        break;
                }
            }
        }

        public void RodarTodosAlgoritmos()
        {
            if (this.HasTarefas())
            {
                Algoritmos.ChaveamentoCircular(this.Tarefas);

                Algoritmos.ChaveamentoLoteria(this.Tarefas);

                Algoritmos.EscalonamentoPorPrioridades(this.Tarefas);

                Algoritmos.PrimeiroChegarPrimeiroServido(this.Tarefas);

                Algoritmos.TarefaMaisCurta(this.Tarefas);
            }
        }

        public bool HasTarefas()
        {
            try
            {
                if(Tarefas.Count <= 0)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    return true;
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Não existe nenhuma tarefa para ser processada");
                return false;
            }
        }
    }
}
