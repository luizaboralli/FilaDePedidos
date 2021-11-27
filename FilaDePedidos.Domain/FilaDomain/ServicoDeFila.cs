namespace FilasDePedidos.Domain.ServicoDeFila;
{
    public class ServicoDeFila
    {
      public Fila FilaDeLanches { get; set; }

      public Fila FilaDeAcompanhamentos { get; set; }

      public Fila FilaDeSobremesas { get; set; }

      public Fila FilaDeBebidas { get; set; }
    
      public void AdicionarNaFila(Item item)
    {
        switch (item.Categoria)
        {
            case CategoriasDeItem.:
                Console.WriteLine($"Measured value is {measurement}; too low.");
                break;

            case > 15.0:
                Console.WriteLine($"Measured value is {measurement}; too high.");
                break;

            case double.NaN:
                Console.WriteLine("Failed measurement.");
                break;

            default:
                Console.WriteLine($"Measured value is {measurement}.");
                break;
        }

    }



}
}
