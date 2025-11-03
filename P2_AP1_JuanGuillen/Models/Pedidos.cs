using System.ComponentModel.DataAnnotations;

namespace P2_AP1_JuanGuillen.Models;

public class Pedidos
{
    [Key]
    public int PedidoId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public string NombreCliente { get; set; }
    public float Total { get; set; }


}
