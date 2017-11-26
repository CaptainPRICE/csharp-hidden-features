using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static NativeMethods;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        scanf("%s", __arglist(out var name)); // <= This line of code makes Visual Studio crash! :)
        if (String.IsNullOrEmpty(name))
        {
            name = "World!";
        }
        printf("Hello %s!\n", __arglist(name));
        Foo(__arglist(1, true, Math.PI, '!', args));
        Bar(__arglist(1, false, Math.PI, '!', args));
        await Task.Delay(-1);
    }

    private static void Foo(__arglist)
    {
        ArgIterator argIterator = new ArgIterator(__arglist);
        //for (int remainingCount = 0; remainingCount < argIterator.GetRemainingCount(); ++remainingCount)
        for (int remainingCount = argIterator.GetRemainingCount(); remainingCount > 0; --remainingCount)
        {
            HiddenFeatureserence HiddenFeatureserence = argIterator.GetNextArg();
            object obj = HiddenFeatureserence.ToObject(HiddenFeatureserence);
            //Console.Out.WriteLine(obj);
            printf("%s\n", __arglist(obj.ToString()));
        }
    }

    private static void Bar(__arglist)
    {
        ArgIterator argIterator = new ArgIterator(__arglist);
        while (argIterator.GetRemainingCount() > 0)
        {
            HiddenFeatureserence HiddenFeatureserence = argIterator.GetNextArg();
            object obj = HiddenFeatureserence.ToObject(HiddenFeatureserence);
            //Console.Out.WriteLine(obj);
            printf("%s\n", __arglist(obj.ToString()));
        }
    }
}

internal static class NativeMethods
{
    [DllImport(ExternDll.msvcrt, CallingConvention = CallingConvention.Cdecl, SetLastError = true, CharSet = CharSet.Ansi)]
    internal static extern int printf(string format, __arglist);

    [DllImport(ExternDll.msvcrt, CallingConvention = CallingConvention.Cdecl, SetLastError = true, CharSet = CharSet.Ansi)]
    internal static extern int scanf(string format, __arglist);
}

internal static class ExternDll
{
    internal const string msvcrt = "msvcrt.dll";
}