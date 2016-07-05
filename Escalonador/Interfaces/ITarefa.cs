using Escalonador.Enums;

namespace Escalonador.Interfaces
{
    public interface ITarefa
    {
        int Identificador { get; set; }
        string Nome { get; set; }
        double TempoDuracao { get; set; }
        Prioridades Prioridade { get; set; }
    }
}
