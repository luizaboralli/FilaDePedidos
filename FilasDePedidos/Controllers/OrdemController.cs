using FilasDePedidos.Domain.PedidosDomain;
using Microsoft.AspNetCore.Mvc;

namespace FilasDePedidos.Controllers
{

    public class OrdemController : Controller
    {
        private Dictionary<string, Item> _catalogo;

        public OrdemController()
        {
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
                    if (_catalogo.TryGetValue(item))
                    {

                    }
                   
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

                
    