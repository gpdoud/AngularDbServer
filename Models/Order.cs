using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularDbServer.Models;

public class Order {
    public int Id { get; set; } = 0;
    [StringLength(30)]
    public string Description { get; set; }
    [Column(TypeName = "decimal(11,2)")]
    public decimal Total { get; set; } = 0;

    public int? CustomerId { get; set; }
    public virtual Customer? Customer { get; set; } = null;
}
