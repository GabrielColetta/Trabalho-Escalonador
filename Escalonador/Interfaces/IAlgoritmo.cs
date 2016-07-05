using System.Collections.Generic;

namespace Escalonador.Interfaces
{
    public interface IAlgoritmo
    {
        List<ITarefa> ChaveamentoCircular(List<ITarefa> Tarefas);
        List<ITarefa> ChaveamentoLoteria(List<ITarefa> Tarefas);
        List<ITarefa> EscalonamentoPorPrioridades(List<ITarefa> Tarefas);
        List<ITarefa> PrimeiroChegarPrimeiroServido(List<ITarefa> Tarefas);
        List<ITarefa> TarefaMaisCurta(List<ITarefa> Tarefas);
    }
}
