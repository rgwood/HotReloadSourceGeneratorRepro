namespace HotReloadRepro;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Windows.Win32;

class Program
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            // this breaks: use GetCurrentThreadId from the source-generated code
            uint threadId = PInvoke.GetCurrentThreadId();

            // this works: use a regular PInvoke, no source generator
            //uint threadId = GetCurrentThreadId();

            Console.WriteLine($"Hello from thread {threadId}");
            await Task.Delay(1000);
        }
    }

    // PInvoke definition copied directly from CsWin32 generated source
    [DllImport("Kernel32", ExactSpelling = true)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    [SupportedOSPlatform("windows5.1.2600")]
    internal static extern uint GetCurrentThreadId();
}