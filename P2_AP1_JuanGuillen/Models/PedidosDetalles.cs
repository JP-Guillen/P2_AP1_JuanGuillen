using System.ComponentModel.DataAnnotations;

namespace P2_AP1_JuanGuillen.Models;

public class PedidosDetalles
{
    [Key]
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public int Componente { get; set; }
    public int Cantidad { get; set; }
    public float precio { get; set; }
}
