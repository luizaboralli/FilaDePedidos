using FilasDePedidos.Domain.FilaDomain;
using FilasDePedidos.Domain.PedidosDomain;

namespace FilasDePedidos.Domain.FilaDomain
{
    public class ServicoDeFila : IServicoDeFila
    {
          public Fila FilaDeLanches { get; set; }

          public Fila FilaDeAcompanhamentos { get; set; }

          public Fila FilaDeSobremesas { get; set; }

          public Fila FilaDeBebidas { get; set; }

        public ServicoDeFila ()
        {
            FilaDeLanches = new Fila("lanches");

            FilaDeAcompanhamentos = new Fila("acompanhamentos");

            FilaDeSobremesas = new Fila("sobremesas");

            FilaDeBebidas = new Fila("bebidas");
        }

        public void AdicionarNaFila(Item item)
            {
                switch (item.Categoria)
                {
                    case CategoriasDeItem.Acompanhamentos:
                        FilaDeAcompanhamentos.Itens.Add(item);
                        break;

                    case CategoriasDeItem.Lanches:
                        FilaDeLanches.Itens.Add(item);
                        break;

                    case CategoriasDeItem.Bebidas:
                        FilaDeBebidas.Itens.Add(item);
                        break;
                    case CategoriasDeItem.Sobremesas:
                        FilaDeSobremesas.Itens.Add(item);
                        break;

                }
             }

      }
 }

