using System;

public class MyAccessModifiers
{
    private int birthYear;


    protected string personalInfo;

    internal string IdNumber;


    public MyAccessModifiers(int birthYear, string idNumber, string personalInfo)
    {
        this.birthYear = birthYear;
        IdNumber = idNumber;
        this.personalInfo = personalInfo;
    }


    public int Age
    {
        get
        {
            
            int currentYear = DateTime.Now.Year;
            return currentYear - birthYear;
        }
    }

    
    private static byte averageMiddleAge = 50;

   
    public string Name { get; set; }

    
    public string NickName { get; internal set; }

    
    protected internal void HasLivedHalfOfLife()
    {
       
    }

  
    public static bool operator ==(MyAccessModifiers obj1, MyAccessModifiers obj2)
    {
      
        if (ReferenceEquals(obj1, obj2) || obj1 is null || obj2 is null)
        {
            return ReferenceEquals(obj1, obj2);
        }

        
        return obj1.Name == obj2.Name && obj1.Age == obj2.Age && obj1.personalInfo == obj2.personalInfo;
    }

 
    public static bool operator !=(MyAccessModifiers obj1, MyAccessModifiers obj2)
    {
        return !(obj1 == obj2);
    }

    
    public override bool Equals(object obj)
    {
        if (obj is MyAccessModifiers myObject)
        {
            return this == myObject;
        }
        return false;
    }

  
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        MyAccessModifiers person = new MyAccessModifiers(1990, "ID12345", "John Doe");

    
        person.Name = "John";
        person.NickName = "Johnny";

     
        Console.WriteLine($"Name: {person.Name}");
        Console.WriteLine($"NickName: {person.NickName}");
        Console.WriteLine($"Age: {person.Age}");

        
        person.HasLivedHalfOfLife();

        
        MyAccessModifiers person2 = new MyAccessModifiers(1990, "ID22345", "John Doe");
        Console.WriteLine($"Are persons equal? {person == person2}");
    }
}
