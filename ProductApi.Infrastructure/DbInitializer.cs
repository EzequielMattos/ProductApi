using ProductApi.Domain.Entities;
using ProductApi.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApi.Infrastructure;

public static class DbInitializer
{
    public static void Initialize(DataContext context)
    {
        context.Database.EnsureCreated();

        if (context.Products.Any())
        {
            return;   // DB has been seeded
        }

        var products = new Product[]
        {
            new Product{Id= "1", Nome="Produto Quente 1", Preco=10.0, Quantidade=5, Estoque="24E10"},
            new Product{Id= "2", Nome="Produto Quente 2", Preco=20.0, Quantidade=5, Estoque="24E10"},
            new Product{Id= "3", Nome="Produto Frio 1", Preco=30.0, Quantidade=5, Estoque="24E11"},
            new Product{Id= "4", Nome="Produto Frio 2", Preco=40.0, Quantidade=5, Estoque="24E11"},
            new Product{Id= "5", Nome="Produto Morno", Preco=50.0, Quantidade=5, Estoque="24E12"},
        };

        foreach (Product p in products)
        {
            context.Products.Add(p);
        }
        context.SaveChanges();
    }
}
