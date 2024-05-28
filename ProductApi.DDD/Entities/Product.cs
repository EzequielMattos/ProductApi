using System.ComponentModel.DataAnnotations;

namespace ProductApi.Domain.Entities;

public class Product
{
    [Key]
    public string Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }
    public string Estoque { get; set; }
}