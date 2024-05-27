using System;

public class Employer
{
    internal string name;
    private DateTime dateofhiring;

    public Employer(string name, DateTime hiringDate)
    {
        this.name = name;
        this.dateofhiring = hiringDate;
    }

    public int yearsofwork()
    {
        DateTime today = DateTime.Today;
        int experienceYears = today.Year - dateofhiring.Year;

       
        if (dateofhiring > today.AddYears(-experienceYears))
        {
            experienceYears--;
        }

        return experienceYears;
    }

    public virtual void ShowInfo()
    {
        int yearsOfExperience = yearsofwork();
        Console.WriteLine($"{name} has {yearsOfExperience} year(s) of experience");
    }
}

public class Devolop : Employer
{
    private string programmingLanguage;

    public Devolop(string name, DateTime hiringDate, string programmingLanguage)
        : base(name, hiringDate)
    {
        this.programmingLanguage = programmingLanguage;
    }

    public override void ShowInfo()
    {
        base.ShowInfo(); 
        Console.WriteLine($"{name} is a {programmingLanguage} programmer");
    }
}

public class QaProgrammer : Employer
{
    private bool isAutomation;

    public QaProgrammer(string name, DateTime hiringDate, bool isAutomation)
        : base(name, hiringDate)
    {
        this.isAutomation = isAutomation;
    }

    public override void ShowInfo()
    {
        int yearsOfExperience = yearsofwork();
        string testerType = isAutomation ? "automated" : "manual";
        Console.WriteLine($"{name} is {testerType} tester and has {yearsOfExperience} year(s) of experience");
    }
}

class Program
{
    static void Main()
    {
        Devolop dev = new Devolop("John Doe", new DateTime(2010, 5, 15), "C#");
        dev.ShowInfo();
        Console.WriteLine();

        QaProgrammer automatedTester = new QaProgrammer("Alice Smith", new DateTime(2015, 8, 20), true);
        automatedTester.ShowInfo();
        Console.WriteLine();

        QaProgrammer manualTester = new QaProgrammer("Bob Johnson", new DateTime(2013, 10, 10), false);
        manualTester.ShowInfo();
    }
}