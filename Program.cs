namespace HotReloadRepro;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

class Program
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            // Call GetCurrentThreadId from the source-generated code. This breaks Hot Reload 
            uint threadId = Windows.Win32.PInvoke.GetCurrentThreadId();

            // Call GetCurrentThreadId from the PInvoke below. This works in Hot Reload
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