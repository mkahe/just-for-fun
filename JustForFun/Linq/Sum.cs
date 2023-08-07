[LoadOnDemand("Linq - " + nameof(SumCalculator))]
public class SumCalculator : IExecutable
{
    public void Main()
    {
        DoSum();
    }

    void DoSum()
    {
        int[] numbers = new int[] { 1, 2, 3, 4, 5};

        var summationAll = numbers.Sum();
        var summationOdds = numbers.Sum(x =>
        {
            if(x%2 == 0) return 0;
            return x;
        });
        Console.WriteLine($"Summation of all numbers: {summationAll}\nSummation of odds: {summationOdds}");
    }
}
