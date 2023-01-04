using System.ComponentModel.DataAnnotations;

namespace AngularDbServer.Models;

public class Customer {
    public int Id { get; set; } = 0;
    [StringLength(30)]
    public string Name { get; set; } = string.Empty;
}
