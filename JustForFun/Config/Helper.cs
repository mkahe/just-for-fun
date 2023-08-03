using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Helper
{
    public static TResult LogDuration<TResult>(string methodName, Func<TResult> method)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        TResult result = method();

        sw.Stop();

        Console.WriteLine($"Method {methodName} took {sw.Elapsed.TotalMilliseconds} ms to execute.");

        return result;
    }

    public static void LogDuration(string methodName, Action method)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();

        method();

        sw.Stop();

        Console.WriteLine($"Method {methodName} took {sw.Elapsed.TotalMilliseconds} ms to execute.");
    }
}
