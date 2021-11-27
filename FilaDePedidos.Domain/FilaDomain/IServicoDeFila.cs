using FilasDePedidos.Domain.FilaDomain;
using FilasDePedidos.Domain.PedidosDomain;

namespace FilasDePedidos.Domain.FilaDomain
{
    public interface IServicoDeFila
    {
        Fila FilaDeLanches { get; set; }

        Fila FilaDeAcompanhamentos { get; set; }

        Fila FilaDeSobremesas { get; set; }

        Fila FilaDeBebidas { get; set; }

        void AdicionarNaFila(Item item);

    };
}
