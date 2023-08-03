
[LoadOnDemand]
public class DynamicFibonatcci
{
    private readonly Dictionary<int, long> memo = new Dictionary<int, long>();

    long GetNthFibonacciMemoizing(int nth)
    {
        if (nth <= 1) return nth;

        if (memo.ContainsKey(nth))
            return memo[nth];

        memo[nth] = GetNthFibonacciMemoizing(nth - 1) + GetNthFibonacciMemoizing(nth - 2);

        return memo[nth];
    }

    long GetNthFibonacciTabulation(int nth)
    {
        if (nth <= 1) return nth;

        var fib = new long[nth + 1];
        fib[0] = 0; fib[1] = 1;

        for (int i = 2; i <= nth; i++)
        {
            fib[i] = fib[i - 1] + fib[i - 2];
        }

        return fib[nth];
    }

    public void Main()
    {
        int n = 30;
        var result2 = Helper.LogDuration(nameof(GetNthFibonacciTabulation), () => GetNthFibonacciTabulation(n));
        var result1 = Helper.LogDuration(nameof(GetNthFibonacciMemoizing), () => GetNthFibonacciMemoizing(n));
        Console.WriteLine($"The {n}th Fibonacci number with Memoizing  is {result1}");
        Console.WriteLine($"The {n}th Fibonacci number with Tabulation is {result2}");
    }
}
