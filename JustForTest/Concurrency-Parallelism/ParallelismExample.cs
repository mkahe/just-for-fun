
[LoadOnDemand]
class ParallelismExample : IExecutable
{
    public void Main()
    {
        Parallel.Invoke(
            () => DoTask("Task1", 1000),
            () => DoTask("Task1", 1000)
        );

        Console.WriteLine("All tasks completed.");
    }

    void DoTask(string taskName, int interval)
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"{taskName} - Step " + i);
            Thread.Sleep(interval); // Simulating some work
        }
    }
}