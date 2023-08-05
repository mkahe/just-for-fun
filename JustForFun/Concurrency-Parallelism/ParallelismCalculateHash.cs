using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

[LoadOnDemand("Concurrency-Parallelism - " + nameof(ParallelismCalculateHash))]
class ParallelismCalculateHash : IExecutable
{
    public void Main()
    {
        var complexity = 5;
        Helper.LogDuration(nameof(RunParallel), () => RunParallel(16, complexity));
        Helper.LogDuration(nameof(RunParallel), () => RunParallel(8, complexity));
        Helper.LogDuration(nameof(RunParallel), () => RunParallel(4, complexity));
        Helper.LogDuration(nameof(RunParallel), () => RunParallel(2, complexity));
    }

    void LogDuration(Action<int, int> method, int maxDegree, int complexity)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        method(maxDegree, complexity);
        stopwatch.Stop();
        Console.WriteLine($"Method execution took: {stopwatch.Elapsed.TotalMilliseconds} milliseconds");
    }

    void RunParallel(int maxDegree, int complexity)
    {
        ParallelOptions options = new ParallelOptions
        {
            MaxDegreeOfParallelism = maxDegree // Set the maximum degree of parallelism to 3
        };

        ParallelLoopResult result = Parallel.For(0, int.MaxValue, options, (i, loopState) =>
        {
            string randomStr = GetRandomString();
            string hash = CalculateHash(randomStr, complexity);
            //Console.WriteLine($"Thread {Task.CurrentId}: Random String: {randomStr}, Hash: {hash}");

            if (ComplyDigits(hash, complexity))
            {
                Console.WriteLine($"Thread {Task.CurrentId}: Found the hash with random number: {randomStr}, The has is {hash}");
                loopState.Stop(); // Stop the parallel loop once a hash is found
            }
        });
    }

    bool ComplyDigits(string hash, int complexity)
    {
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < complexity; i++)
        {
            stringBuilder.Append("0");
        }

        return stringBuilder.ToString().Equals(hash);
    }

    string GetRandomString()
    {
        byte[] buffer = new byte[4]; // We generate a 4-byte random number (32-bit)
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(buffer);
        }

        int randomNumber = BitConverter.ToInt32(buffer, 0);
        return randomNumber.ToString("X"); // Convert the random number to hexadecimal string
    }

    string CalculateHash(string input, int complexity)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(bytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").Substring(0, complexity); // Get the first two characters of the hash
        }
    }
}