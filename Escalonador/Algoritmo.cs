using Escalonador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Escalonador
{
    /// <summary>
    /// Classe responsável por todos algoritmos de escalonamento.
    /// </summary>
    public class Algoritmo : IAlgoritmo
    {
        /// <summary>
        /// Método responsável por simular um chaveamento circular sem o uso de Thread ou Task
        /// quantum: Recebe a média de todos os tempos.
        /// filaDeProcesso: Faz uma fila com os valores da lista de tarefa.
        /// emExecução: é a tarefa a ser executada no momento.
        /// </summary>
        /// <param name="Tarefas">É uma lista de todas tarefas que serão executadas.</param>
        /// <returns>Retorna a lista dos objetos escalonados.</returns>
        public List<ITarefa> ChaveamentoCircular(List<ITarefa> Tarefas)
        {
            double quantum = Tarefas.Select(item => item.TempoDuracao).Average();
            var filaDeProcesso = new Queue<ITarefa>(Tarefas);
            ITarefa emExecucao;

            do
            {
                emExecucao = filaDeProcesso.Peek();
                if ((emExecucao.TempoDuracao - quantum) < 0)
                {
                    Thread.Sleep(1000);
                    emExecucao.TempoDuracao = 0;
                    Console.WriteLine($"O processo {emExecucao.Identificador} foi completado!");

                    filaDeProcesso.Dequeue();
                }
                else if((emExecucao.TempoDuracao - quantum) > 0)
                {
                    Thread.Sleep(1000);
                    emExecucao.TempoDuracao = emExecucao.TempoDuracao - quantum;
                    Console.WriteLine($"O {emExecucao.Identificador} necessita de mais {emExecucao.TempoDuracao} segundos para sua finalização!");

                    filaDeProcesso.Enqueue(emExecucao);
                    filaDeProcesso.Dequeue();
                }
            } while (filaDeProcesso.Select(item => item.TempoDuracao).All(item => item == 0));

            return new List<ITarefa>(filaDeProcesso);
        }

        /// <summary>
        /// Faz o escalonamento dando valores para cada tarefa e sorteia um valor para fazer o escalonamento.
        /// quantum: Recebe a média de todos os tempos.
        /// </summary>
        /// <param name="Tarefas">É uma lista de todas tarefas que serão executadas.</param>
        /// <returns>Retorna a lista dos objetos escalonados.</returns>
        public List<ITarefa> ChaveamentoLoteria(List<ITarefa> Tarefas)
        {
            double quantum = Tarefas.Select(item => item.TempoDuracao).Average();
            int resultado = 0;
            var valoresFinalizados = new List<int>();
            ITarefa emExecucao;
            var tarefasLoterias = new List<ITarefa>();


            foreach (var item in Tarefas)
            {
                tarefasLoterias.Add(new TarefaLoteria(item));
            }

            do
            {
                do
                {
                    resultado = TarefaLoteria.FazerSorteio();
                } while (valoresFinalizados.Find(item => item == resultado) == resultado);

                emExecucao = tarefasLoterias.Find(item => item.Identificador == resultado) as TarefaLoteria;
                if (emExecucao.TempoDuracao < 0)
                {
                    emExecucao.TempoDuracao = 0;
                    valoresFinalizados.Add(resultado);
                    Console.WriteLine($"O processo {emExecucao.Nome} foi completado!");
                }
                else
                {
                    emExecucao.TempoDuracao = emExecucao.TempoDuracao - quantum;
                    Console.WriteLine($"O processo {emExecucao.Nome} ainda necessita de {emExecucao.TempoDuracao} para terminar!");
                }

            } while (tarefasLoterias.Select(item => item).All(item => item.TempoDuracao == 0));

            return new List<ITarefa>();
        }

        /// <summary>
        /// Faz o escalonamento usando o atributo prioridade, se as prioridades for iguais, utiliza outra
        /// prioridade para fazer a escolha.
        /// </summary>
        /// <param name="Tarefas">É uma lista de todas tarefas que serão executadas.</param>
        /// <returns>Retorna a lista dos objetos escalonados.</returns>
        public List<ITarefa> EscalonamentoPorPrioridades(List<ITarefa> Tarefas)
        {
            ITarefa emExecucao;
            var TarefasPrioridade = new List<TarefaPrioridade>();

            foreach (var item in Tarefas)
            {
                TarefasPrioridade.Add(new TarefaPrioridade(item));
            }

            do
            {
                emExecucao = TarefaPrioridade
                    .EncontrarTarefaComMaiorPrioridade(TarefasPrioridade
                                                        .Where(item => item.TempoDuracao != 0)
                                                        .ToList());
                Thread.Sleep(1000);
                TarefasPrioridade.First(item => item.Identificador == emExecucao.Identificador).TempoDuracao = 0;

                Console.WriteLine($"A tarefa {emExecucao.Nome} foi finalizado!");
            } while (Tarefas.Select(item => item.TempoDuracao).All(item => item == 0));
            return new List<ITarefa>(TarefasPrioridade);
        }

        /// <summary>
        /// Faz o escalonamento usando o conceito de FIFO.
        /// emExecucao: vai receber o primeiro objeto em que o TempoDuração é diferente de zero.
        /// </summary>
        /// <param name="Tarefas">É uma lista de todas tarefas que serão executadas.</param>
        /// <returns>Retorna a lista dos objetos escalonados.</returns>
        public List<ITarefa> PrimeiroChegarPrimeiroServido(List<ITarefa> Tarefas)
        {
            ITarefa emExecucao;

            do {
                emExecucao = Tarefas.Select(item => item).First(item => item.TempoDuracao != 0);
                Thread.Sleep(5000);
                Tarefas.Select(item => item).First(item => item.TempoDuracao != 0).TempoDuracao = 0;

                Console.WriteLine($"A tarefa {emExecucao.Nome} foi finalizado!");
            } while (Tarefas.Select(item => item.TempoDuracao).All(item => item == 0));
            return Tarefas;
        }

        public List<ITarefa> TarefaMaisCurta(List<ITarefa> Tarefas)
        {
            Queue<ITarefa> filaOrdenada = new Queue<ITarefa>(Tarefas.OrderBy(item => item.TempoDuracao));
            ITarefa emExecucao;

            do
            {
                emExecucao = filaOrdenada.Peek();
                Thread.Sleep(5000);
                emExecucao.TempoDuracao = 0;
                Console.WriteLine($"A tarefa {emExecucao.Nome} foi finalizada!");
                
                filaOrdenada.Dequeue();
                filaOrdenada.Enqueue(emExecucao);
            } while (filaOrdenada.Select(item => item.TempoDuracao).All(item => item == 0));
            return new List<ITarefa>(filaOrdenada);
        }
    }
}
