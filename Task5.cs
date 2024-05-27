using System;
using System.Threading.Tasks;

public class Parautility<T, TR>
{
    private Func<T, T, TR> _operation;
    private T _operand1;
    private T _operand2;

    public Parautility(Func<T, T, TR> operation, T operand1, T operand2)
    {
        _operation = operation;
        _operand1 = operand1;
        _operand2 = operand2;
    }

    public TR Result { get; private set; }

    public void SttingOpers(T operand1, T operand2)
    {
        _operand1 = operand1;
        _operand2 = operand2;
    }

    private async Task AsynhronOperat()
    {
        Result = await Task.Run(() => _operation(_operand1, _operand2));
    }

    public void Evaluate()
    {
        AsynhronOperat().GetAwaiter().GetResult();
    }
}

public static class Operations
{
    public static int Add(int x, int y) => x + y;
    public static int Subtract(int x, int y) => x - y;
    public static int Multiply(int x, int y) => x * y;
    public static double Divide(double x, double y)
    {
        if (y == 0)
            throw new DivideByZeroException("We cant divide by 0.");
        return x / y;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var addUtils = new Parautility<int, int>(Operations.Add, 7, 3);
        var subtractUtils = new Parautility<int, int>(Operations.Subtract, 10, 9);
        var multiplyUtils = new Parautility<int, int>(Operations.Multiply, 4, 7);
        var divideUtils = new Parautility<double, double>(Operations.Divide, 10.0, 2);

        addUtils.Evaluate();
        subtractUtils.Evaluate();
        multiplyUtils.Evaluate();
        divideUtils.Evaluate();

        Console.WriteLine("Sum: " + addUtils.Result);
        Console.WriteLine("Riznicya: " + subtractUtils.Result);
        Console.WriteLine("Multipliying: " + multiplyUtils.Result);
        Console.WriteLine("Division: " + divideUtils.Result);
    }
}