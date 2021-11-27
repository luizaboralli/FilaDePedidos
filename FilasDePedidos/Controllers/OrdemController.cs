using FilasDePedidos.Domain.PedidosDomain;
using FilasDePedidos.Domain.FilaDomain;
using Microsoft.AspNetCore.Mvc;

namespace FilasDePedidos.Controllers
{

    public class OrdemController : Controller
    {
        private Dictionary<string, Item> _catalogo;

        private readonly IServicoDeFila _servicoDeFila;

        public OrdemController(IServicoDeFila servicoDeFila)
        {
            _servicoDeFila  = servicoDeFila;
            _catalogo = InicializarDicionario();
        }

        [HttpPost("itens/")]
        public async Task<IActionResult> Post([FromBody] Pedido pedido)
        {
            try
            {
                var itens = pedido.Itens.Split(",");
                foreach (var item in itens)
                {
                    if (_catalogo.TryGetValue(item.Trim(), out var it))
                    {
                        _servicoDeFila.AdicionarNaFila(it);
                    }
                   
                }

              return Ok();

            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("filas/")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = new List<Fila>();
                list.Add(_servicoDeFila.FilaDeLanches);
                list.Add(_servicoDeFila.FilaDeSobremesas);
                list.Add(_servicoDeFila.FilaDeBebidas);
                list.Add(_servicoDeFila.FilaDeAcompanhamentos);


                return Ok(list);

            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("filas/{nome}")]
        public async Task<IActionResult> Get(string nome)
        {
            try
            {
                switch (nome)
                {
                    case "lanches":
                        return Ok(_servicoDeFila.FilaDeLanches);

                    case "bebidas":
                        return Ok(_servicoDeFila.FilaDeBebidas);

                    case "acompanhamentos":
                        return Ok(_servicoDeFila.FilaDeAcompanhamentos);

                    case "sobremesas":
                        return Ok(_servicoDeFila.FilaDeSobremesas);

                    default:
                        return NotFound("Essa fila não existe!");
                }
                return Ok();

            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private Dictionary<string, Item> InicializarDicionario()
        {
            return new Dictionary<string, Item>()
            {


                { "bigmac", new Item { Nome = "Big Mac", Categoria = CategoriasDeItem.Lanches } },
                { "bigtasty", new Item { Nome = "Big Tasty", Categoria = CategoriasDeItem.Lanches } },
                { "guarana", new Item { Nome = "Gurarana", Categoria = CategoriasDeItem.Bebidas } },
                { "cocacola", new Item { Nome = "Coca-Cola", Categoria = CategoriasDeItem.Bebidas } },
                { "batata", new Item { Nome = "Batata", Categoria = CategoriasDeItem.Acompanhamentos } },
                { "chickennugget", new Item { Nome = "Chicken Nugget", Categoria = CategoriasDeItem.Acompanhamentos } },
                { "tortinha", new Item { Nome = "Tortinha", Categoria = CategoriasDeItem.Sobremesas } },
                { "mcflury", new Item { Nome = "Mc Flury", Categoria = CategoriasDeItem.Sobremesas } },
                { "mcshake", new Item { Nome = "Mc Shake", Categoria = CategoriasDeItem.Sobremesas } }
            };


        }

    }
}

                
    