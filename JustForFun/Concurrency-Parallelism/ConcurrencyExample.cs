
[LoadOnDemand]
internal class ConcurrencyExample : IExecutable
{
    public ConcurrencyExample()
    {
    }

    public void Main()
    {
        Thread thread1 = new Thread(() => DoTask("Task1", 1000));
        Thread thread2 = new Thread(() => DoTask("Task1", 1000));
        thread1.Start();
        thread2.Start();
        // Main thread may do other tasks concurrently while the two threads run in the background
        Console.WriteLine("Two tasks started.");
        // Main thread waits for both thread to complete their jobs and then go to next WriteLine
        thread1.Join();
        thread2.Join();
        Console.WriteLine("All tasks completed.");
    }

    static void DoTask(string taskName, int interval)
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"{taskName} - Step " + i);
            Thread.Sleep(interval); // Simulating some work
        }
    }
}