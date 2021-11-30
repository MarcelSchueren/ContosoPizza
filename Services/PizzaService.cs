using ContosoPizza.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContosoPizza.Services;
public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int nextId = 3;

    static PizzaService()
    {
        Pizzas = new List<Pizza>{
            new Pizza{Id = 1, Name="Margarita", IsGlutenFree=false},
            new Pizza{Id = 2, Name="Tonno", IsGlutenFree=false},
        };
    }
    public static List<Pizza> GetAll() => Pizzas;

    public static Pizza Get(int id)
    {
        foreach (Pizza pizza in Pizzas)
        {
            if (pizza.Id == id)
            {
                return pizza;
            }

            else
            {
                return Pizzas[0];
            }
        }
        return Pizzas[0];
    }

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        Pizza pizza = Get(id);
        if (pizza == null) return;
        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
        int index = Pizzas.FindIndex((p) => p.Id == pizza.Id);
        if (index == -1) return;
        Pizzas[index] = pizza;
    }
}