[LoadOnDemand("Linq - " + nameof(Aggregate))]
public class Aggregate : IExecutable
{
    public void Main()
    {
        SumWithAggregate();
        SumWithAggregateSeed();
        JoinWithAggregate();
        ToPersianNumbers();
    }

    private void SumWithAggregate()
    {
        int[] numbers = { 1, 2, 3 };
        var sum = numbers.Aggregate((acc, next) => acc + next);
        Console.WriteLine($"Summation of array {numbers.AsString()} with Aggregate function is {sum}\n");
    }

    private void SumWithAggregateSeed()
    {
        int[] numbers = { 1, 2, 3 };
        // Calculate the sum of all numbers using Aggregate with seed value
        int initialSeed = 10;
        int sumWithSeed = numbers.Aggregate(initialSeed, (acc, num) => acc + num);

        Console.WriteLine($"Sum of array {numbers.AsString()} with seed: {sumWithSeed}\n");
    }

    private void JoinWithAggregate1()
    {
        string[] numbers = new string[] { "One", "Two", "Three", "Four" };

        var joinedStr1 = numbers.Aggregate(
            seed: "["
            , func: (str1, str2) => str1 + ", " + str2
            , resultSelector: str => str + "]");

    }

    private void JoinWithAggregate()
    {
        string[] numbers = new string[] { "One", "Two", "Three", "Four" };

        var joinedStr = numbers.Aggregate(
            seed: "",
            func: (str1, str2) => str1 + ", " + str2,
            resultSelector: str =>
            {
                str = str.Remove(0, 2); return $"[{str}]";
            });

        Console.WriteLine($"Array join will be {joinedStr}\n");
    }

    private void ToPersianNumbers()
    {
        var persianDict = new Dictionary<string, string>() {
            { "1", "۱" },
            { "2", "۲" },
            { "3", "۳" },
            { "4", "۴" },
            { "5", "۵" },
            { "6", "۶" },
            { "7", "۷" },
            { "8", "۸" },
            { "9", "۹" },
            { "0", "۰" }
        };

        var sampleNumber = "44764202-42";

        var persianString = persianDict.Aggregate(
            seed: sampleNumber
            , func: (current, item) => current.Replace(item.Key, item.Value));

        Console.WriteLine($"For the input {sampleNumber} the persian numbers using aggregate method is {persianString}\n");
    }
}
