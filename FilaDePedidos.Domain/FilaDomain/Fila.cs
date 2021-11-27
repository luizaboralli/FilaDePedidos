using FilasDePedidos.Domain.PedidosDomain;

namespace FilasDePedidos.Domain.FilaDomain
{
    public class Fila
    {

        public string Nome { get; set; }
        public IList<Item> Itens { get; set; }     
        
        public Fila( string nome)
        {
            Nome = nome;
            Itens = new List<Item>();
        }

    }
}
