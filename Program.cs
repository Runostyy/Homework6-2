using System;
using System.Collections.Generic;

class Tree
{
    public string Name { get; set; } // Назва дерева
    public double Price { get; set; } // Ціна дерева
    public double Height { get; set; } // Висота дерева

    public Tree(string name, double price, double height)
    {
        Name = name;
        Price = price;
        Height = height;
    }

    public override string ToString()
    {
        return $"{Name}: Ціна = {Price:C}, Висота = {Height} м";
    }
}

// Реалізація інтерфейсу IComparer для порівняння за ціною
class PriceComparer : IComparer<Tree>
{
    public int Compare(Tree x, Tree y)
    {
        if (x == null || y == null)
            throw new ArgumentNullException("Об'єкт не може бути null");

        return x.Price.CompareTo(y.Price); // Порівняння за ціною
    }
}

// Реалізація інтерфейсу IComparer для порівняння за висотою
class HeightComparer : IComparer<Tree>
{
    public int Compare(Tree x, Tree y)
    {
        if (x == null || y == null)
            throw new ArgumentNullException("Об'єкт не може бути null");

        return x.Height.CompareTo(y.Height); // Порівняння за висотою
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення списку дерев
        List<Tree> trees = new List<Tree>
        {
            new Tree("Дуб", 1500.00, 10.5),
            new Tree("Сосна", 1000.00, 15.0),
            new Tree("Береза", 1200.00, 12.0),
            new Tree("Ялина", 1800.00, 8.5)
        };

        Console.WriteLine("Список дерев:");
        foreach (var tree in trees)
        {
            Console.WriteLine(tree);
        }

        // Сортування за ціною
        Console.WriteLine("\nСписок дерев, впорядкований за ціною:");
        trees.Sort(new PriceComparer());
        foreach (var tree in trees)
        {
            Console.WriteLine(tree);
        }

        // Сортування за висотою
        Console.WriteLine("\nСписок дерев, впорядкований за висотою:");
        trees.Sort(new HeightComparer());
        foreach (var tree in trees)
        {
            Console.WriteLine(tree);
        }
    }
}
