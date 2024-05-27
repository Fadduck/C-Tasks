using System;

public interface ISwimmable
{
    void Swim();
}

public interface IFlyable
{
    int MaxHeight { get; }
    void Fly();
}

public interface IRunnable
{
    int MaxSpeed { get; }
    void Run();
}

public interface IAnimal
{
    int LifeExpectancy { get; }
    void MakeSound();
    void DisplayInformation();
}

public class Cat : IAnimal, IRunnable
{
    public int LifeExpectancy { get; } = 7; 
    public int MaxSpeed { get; } = 60;

    public void MakeSound()
    {
        Console.WriteLine(":3");
    }

    public void Run()
    {
        Console.WriteLine($"I can run up to {MaxSpeed} km per h speed! ");
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"I live for {LifeExpectancy} y");
    }
}

public class Eagle : IAnimal, IFlyable
{
    public int LifeExpectancy { get; } = 20; 
    public int MaxHeight { get; } = 8000;

    public void MakeSound()
    {
        Console.WriteLine("Aaaaaar!");
    }

    public void Fly()
    {
        Console.WriteLine($"I can flight up to {MaxHeight} meters!");
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"My lifespan is about {LifeExpectancy} years.");
    }
}

public class Shark : IAnimal, ISwimmable
{
    public int LifeExpectancy { get; } = 45; 

    public void MakeSound()
    {
        Console.WriteLine("bul bul");
    }

    public void Swim()
    {
        Console.WriteLine("I can swim (pog) ");
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"I can live {LifeExpectancy} years before i eat some humans.");
    }
}

class Program
{
    static void Main(string[] args)
    {

        Cat cat = new Cat();
        cat.DisplayInformation(); 
        cat.MakeSound();          
        cat.Run();               

        Console.WriteLine();

        Eagle eagle = new Eagle();
        eagle.DisplayInformation(); 
        eagle.MakeSound();          
        eagle.Fly();               

        Console.WriteLine();

        Shark shark = new Shark();
        shark.DisplayInformation();
        shark.MakeSound();          
        shark.Swim();              
    }
}