
[LoadOnDemand("Lock - " + nameof(LockScenarios))]
public class LockScenarios : IExecutable
{
    static readonly object _object = new object();
    static readonly object _monitorObject = new object();

    public void Main()
    {
        Console.WriteLine("Before");
        Task.Run(() => Console.WriteLine(IWillBeBack())).GetAwaiter().GetResult();
        Console.WriteLine("After");
    }

    public void DoOther()
    {
        lock (_object)
        {
            Thread.Sleep(1000);
            Console.WriteLine(Environment.TickCount);
            Console.WriteLine("Task thread ID: {0}", Thread.CurrentThread.ManagedThreadId);
        }

        Monitor.Enter(_monitorObject);
        Thread.Sleep(100);
        Console.WriteLine(Environment.TickCount);
        Console.WriteLine("Task thread ID: {0}", Thread.CurrentThread.ManagedThreadId);
        Monitor.Exit(_monitorObject);
    }

    private static string IWillBeBack()
    {
        Thread.Sleep(3000);
        Console.WriteLine("Task thread ID: {0}", Thread.CurrentThread.ManagedThreadId);
        return "I will be back";
    }

}

