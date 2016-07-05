using Escalonador.Interfaces;
using System;

namespace Escalonador
{
    class Program
    {
        static void Main(string[] args)
        {
            int resultado;
            var isTrue = true;
            IEscalonador Escalonamento = new Escalonador();

            while (isTrue)
            {
                Console.Clear();
                Console.WriteLine("Escalonador em lote.");
                Console.WriteLine("Trabalho de sistema operacional do segundo bimestre!");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("1 - Adicionar tarefas!");
                Console.WriteLine("2 - Rodar tarefas com algoritmo desejado!");
                Console.WriteLine("3 - Rodar tarefas com todos os algoritmos!");
                Console.WriteLine("4 - Sair!");
                resultado = int.Parse(Console.ReadLine());
                switch (resultado)
                {
                    case 1:
                        Escalonamento.AdicionarTarefa(); break;
                    case 2:
                        Escalonamento.RodarTarefa(); break;
                    case 3:
                        Escalonamento.RodarTodosAlgoritmos(); break;
                    case 4:
                        isTrue = false; break;
                    default:
                        break;
                }
            }
        }
    }
}
