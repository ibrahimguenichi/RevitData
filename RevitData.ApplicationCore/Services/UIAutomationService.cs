using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using RevitData.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Automation;

namespace RevitData.ApplicationCore.Services
{
    public class UIAutomationService
    {
        public bool IsRevitStarted { get; set; } = false;
        public Process RevitProcess { get; set; }

        public string GetLatestInstalledRevitVersion()
        {
            string[] possibleVersions = { "2025", "2024", "2023", "2022", "2021", "2020", "2019", "2018", "2017", "2016", "2015" };

            foreach (string version in possibleVersions)
            {
                if (System.IO.File.Exists($@"C:\Program Files\Autodesk\Revit {version}\Revit.exe"))
                {
                    return version;
                }
            }
            return "No Revit version found";
        }

        public void LaunchRevitAsProcess(string revitPath)
        {
            string revitVersion = GetLatestInstalledRevitVersion();

            if (revitVersion == "No Revit version found")
            {
                throw new Exception("No Revit version found");
            }
            else
            {
                Process revitProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = $@"C:\Program Files\Autodesk\Revit {revitVersion}\Revit.exe",
                        Arguments = $"\"{revitPath}\" --run-external-command",
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                this.RevitProcess = revitProcess;
                this.IsRevitStarted = true;

                revitProcess.Start();
                revitProcess.WaitForInputIdle();
                System.Threading.Thread.Sleep(30000);
            }
        }

        public void CloseRevit()
        {
            if (this.IsRevitStarted)
            {
                this.RevitProcess.Kill();
                this.RevitProcess = null;
                this.IsRevitStarted = false;
            }
        }

        public void AutomateAddInTrigger(string addInName)
        {
            using (var automation = new UIA3Automation())
            {
                var app = FlaUI.Core.Application.Attach(RevitProcess);
                var mainWindow = app.GetMainWindow(automation);

                if (mainWindow == null)
                {
                    Console.WriteLine("Failed to find the revit main window");
                    return;
                }

                Console.WriteLine("Successfully attached to revit main window");

                //Navigate to the Add-Ins tab
                var ribbonTab = mainWindow.FindFirstDescendant(cf => cf.ByName("Add-Ins"));

                if (ribbonTab != null)
                {
                    mainWindow.Focus();
                    FlaUI.Core.Input.Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.LMENU); // Alt key
                    FlaUI.Core.Input.Keyboard.Release(FlaUI.Core.WindowsAPI.VirtualKeyShort.LMENU);
                    System.Threading.Thread.Sleep(1500);
                    FlaUI.Core.Input.Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.KEY_D);
                    FlaUI.Core.Input.Keyboard.Release(FlaUI.Core.WindowsAPI.VirtualKeyShort.KEY_D);
                    System.Threading.Thread.Sleep(1500);
                    FlaUI.Core.Input.Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.KEY_E);
                    FlaUI.Core.Input.Keyboard.Release(FlaUI.Core.WindowsAPI.VirtualKeyShort.KEY_E);
                    System.Threading.Thread.Sleep(1500);
                    FlaUI.Core.Input.Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.DOWN);
                    FlaUI.Core.Input.Keyboard.Release(FlaUI.Core.WindowsAPI.VirtualKeyShort.DOWN);
                    System.Threading.Thread.Sleep(1500);
                    FlaUI.Core.Input.Keyboard.Press(FlaUI.Core.WindowsAPI.VirtualKeyShort.RETURN);
                    FlaUI.Core.Input.Keyboard.Release(FlaUI.Core.WindowsAPI.VirtualKeyShort.RETURN);

                    Console.WriteLine("Triggered Add-Ins tab using keyboard shortcut.");
                }
                else
                {
                    Console.WriteLine("Add-Ins tab not found");
                }
            }
        }

        public void AutomateDocumentExtraction(string revitPath, string addInName)
        {
            LaunchRevitAsProcess(revitPath);

            AutomateAddInTrigger(addInName);

            //CloseRevit();
        }
    }
}

