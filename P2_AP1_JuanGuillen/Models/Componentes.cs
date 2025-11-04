using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_AP1_JuanGuillen.Models;

public class Componentes
{
    [Key]
    public int ComponenteId { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
    public decimal Precio { get; set; }
    public int Existencia { get; set; }
    public ICollection<PedidosDetalles> PedidosDetalles { get; set; } = new List<PedidosDetalles>();
}
