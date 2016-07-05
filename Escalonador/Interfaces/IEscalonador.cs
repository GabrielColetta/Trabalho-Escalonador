using System.Collections.Generic;

namespace Escalonador.Interfaces
{
    public interface IEscalonador
    {
        List<ITarefa> Tarefas { get; }
        IAlgoritmo Algoritmos { get; }

        void AdicionarTarefa();
        void RodarTarefa();
        void RodarTodosAlgoritmos();
    }
}
