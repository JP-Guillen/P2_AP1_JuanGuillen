using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_AP1_JuanGuillen.Models;

public class PedidosDetalles
{
    [Key]
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public int ComponenteId { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero.")]
    public int Cantidad { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
    public float precio { get; set; }

    [ForeignKey("PedidoId")]
    public virtual Pedidos pedidos { get; set; }

    [ForeignKey("ComponenteId")]
    public virtual Componentes Componentes { get; set; }

}
