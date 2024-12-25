﻿using GTweak.Utilities.Control;
using GTweak.Utilities.Helpers;
using GTweak.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace GTweak.Utilities.Tweaks
{
    internal sealed class ServicesTweaks : Firewall
    {
        private static readonly SortedList<string, string> ProgramsUUP = new SortedList<string, string>
        {
            ["Uso"] = "usoclient.exe",
            ["Worker"] = "MoUsoCoreWorker.exe",
            ["Core"] = "wuaucltcore.exe",
            ["Agent"] = "WaaSMedicAgent.exe",
            ["Re_Uso"] = "BlockUOrchestrator-GTweak.exe",
            ["Re_Worker"] = "BlockUpdate-GTweak.exe",
            ["Re_Core"] = "BlockUpdateCore-GTweak.exe",
            ["Re_Agent"] = "BlockUpdateAgent-GTweak.exe"
        };

        private static string PathsWinUUP(string program, bool isOldWay = false)
        {
            string path = isOldWay ? string.Concat(UsePath.SystemDisk, @"Windows\System32\") : string.Concat(UsePath.SystemDisk, @"Windows\UUS\amd64\");

            if (program == "Uso" || program == "Re_Uso")
                return string.Concat(string.Concat(UsePath.SystemDisk, @"Windows\System32\"), ProgramsUUP[program]);
            else
                return string.Concat(path, ProgramsUUP[program]);
        }

        internal void ViewServices(ServicesView servicesV)
        {
            servicesV.TglButton1.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WSearch", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\fhsvc", "Start", "4");

            servicesV.TglButton2.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\XboxGipSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\XblAuthManager", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\XboxNetApiSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\XblGameSave", "Start", "4");

            servicesV.TglButton3.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WwanSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\wlpasvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\icssvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\DusmSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\autotimesvc", "Start", "4");

            servicesV.TglButton4.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WalletService", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\VacSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\spectrum", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SharedRealitySvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\perceptionsimulation", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\MixedRealityOpenXRSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\MapsBroker", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\EntAppSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\embeddedmode", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\wlidsvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WEPHOSTSVC", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\StorSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\ClipSVC", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\InstallService", "Start", "4");

            servicesV.TglButton5.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\wmiApSrv", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\pla", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\PerfHost", "Start", "4");

            servicesV.TglButton6.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WbioSrvc", "Start", "4");

            servicesV.TglButton7.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\bthserv", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\BthAvctpSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\BTAGService", "Start", "4");

            servicesV.TglButton8.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Spooler", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\PrintNotify", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\McpManagementService", "Start", "4");

            servicesV.TglButton9.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WiaRpc", "Start", "4");

            servicesV.TglButton10.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\TapiSrv", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\PhoneSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Fax", "Start", "4");

            servicesV.TglButton11.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SensrSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SensorService", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SensorDataService", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SEMgrSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\lfsvc", "Start", "4");

            servicesV.TglButton12.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\DispBrokerDesktopSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WFDSConMgrSvc", "Start", "4");

            servicesV.TglButton13.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\CDPSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\PushToInstall", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WpnService", "Start", "4");

            servicesV.TglButton14.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Netlogon", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\CscService", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\lmhosts", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\FDResPub", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\fdPHost", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\LanmanServer", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\LanmanWorkstation", "Start", "4");

            servicesV.TglButton15.StateNA = !File.Exists(PathsWinUUP("Re_Worker")) & !File.Exists(PathsWinUUP("Re_Core")) & !File.Exists(PathsWinUUP("Re_Agent")) &
                !File.Exists(PathsWinUUP("Re_Worker", true)) & !File.Exists(PathsWinUUP("Re_Core", true)) & !File.Exists(PathsWinUUP("Re_Agent", true))
                && (RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\wisvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\DmEnrollmentSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\wuauserv", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WaaSMedicSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\DoSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\UsoSvc", "Start", "4"));

            servicesV.TglButton16.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\PolicyAgent", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\IKEEXT", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\p2pimsvc", "Start", "4");

            servicesV.TglButton17.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WPDBusEnum", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WMPNetworkSvc", "Start", "4");

            servicesV.TglButton18.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\UmRdpService", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\TermService", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SessionEnv", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\DsSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\RemoteRegistry", "Start", "4");

            servicesV.TglButton19.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WerSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\wercplsupport", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\Wecsvc", "Start", "4");

            servicesV.TglButton20.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WebClient", "Start", "4");

            servicesV.TglButton21.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SCPolicySvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\ScDeviceEnum", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\SCardSvr", "Start", "4");

            servicesV.TglButton22.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\AssignedAccessManagerSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\AppReadiness", "Start", "4");

            servicesV.TglButton23.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\BDESVC", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\EFS", "Start", "4");

            servicesV.TglButton24.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\LxpSvc", "Start", "4");

            servicesV.TglButton25.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WarpJITSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\wscsvc", "Start", "4");

            servicesV.TglButton26.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WdiSystemHost", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\WdiServiceHost", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\TroubleshootingSvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\DPS", "Start", "4");

            servicesV.TglButton27.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\workfolderssvc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\dot3svc", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\DevQueryBroker", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\AppMgmt", "Start", "4");

            servicesV.TglButton28.StateNA =
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\vmicvmsession", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\vmictimesync", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\vmicshutdown", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\vmicrdv", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\vmickvpexchange", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\vmicheartbeat", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\vmicguestinterface", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\HvHost", "Start", "4") ||
                RegistryHelp.CheckValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\vmicvss", "Start", "4");
        }

        internal static void UseServices(string tweak, bool isChoose)
        {
            INIManager.TempWrite(INIManager.TempTweaksSvc, tweak, isChoose);

            switch (tweak)
            {
                case "TglButton1":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WSearch", "Start", isChoose ? 4 : 2, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\fhsvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton2":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\XboxGipSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\XblAuthManager", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\XboxNetApiSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\XblGameSave", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton3":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WwanSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\wlpasvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\icssvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\DusmSvc", "Start", isChoose ? 4 : 2, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\autotimesvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\DusmSvc", "DelayedAutoStart", isChoose ? 1 : 0, RegistryValueKind.DWord);
                    break;
                case "TglButton4":
                    Task.Run(delegate
                    {
                        string value = isChoose ? "4" : "3";
                        TrustedInstaller.CreateProcessAsTrustedInstaller(Settings.PID, $"cmd.exe /c reg add HKLM\\SYSTEM\\CurrentControlSet\\Services\\WalletService /t REG_DWORD /v Start /d {value} /f & " +
                             $"reg add HKLM\\SYSTEM\\CurrentControlSet\\Services\\VacSvc /t REG_DWORD /v Start /d {value} /f & " +
                             $"reg add HKLM\\SYSTEM\\CurrentControlSet\\Services\\spectrum /t REG_DWORD /v Start /d {value} /f & " +
                             $"reg add HKLM\\SYSTEM\\CurrentControlSet\\Services\\SharedRealitySvc /t REG_DWORD /v Start /d {value} /f & " +
                             $"reg add HKLM\\SYSTEM\\CurrentControlSet\\Services\\perceptionsimulation /t REG_DWORD /v Start /d {value} /f & " +
                             $"reg add HKLM\\SYSTEM\\CurrentControlSet\\Services\\MixedRealityOpenXRSvc /t REG_DWORD /v Start /d {value} /f & " +
                             $"reg add HKLM\\SYSTEM\\CurrentControlSet\\Services\\MapsBroker /t REG_DWORD /v Start /d {value} /f & " +
                             $"reg add HKLM\\SYSTEM\\CurrentControlSet\\Services\\EntAppSvc /t REG_DWORD /v Start /d {value} /f & " +
                             $"reg add HKLM\\SYSTEM\\CurrentControlSet\\Services\\embeddedmode /t REG_DWORD /v Start /d {value} /f & " +
                             $"reg add HKLM\\SYSTEM\\CurrentControlSet\\Services\\wlidsvc /t REG_DWORD /v Start /d {value} /f & " +
                             $"reg add HKLM\\SYSTEM\\CurrentControlSet\\Services\\WEPHOSTSVC /t REG_DWORD /v Start /d {value} /f & " +
                             $"reg add HKLM\\SYSTEM\\CurrentControlSet\\Services\\StorSvc /t REG_DWORD /v Start /d {value} /f & " +
                             $"reg add HKLM\\SYSTEM\\CurrentControlSet\\Services\\ClipSVC /t REG_DWORD /v Start /d {value} /f & " +
                             $"reg add HKLM\\SYSTEM\\CurrentControlSet\\Services\\InstallService /t REG_DWORD /v Start /d {value} /f");
                    });
                    break;
                case "TglButton5":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\wmiApSrv", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\pla", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\PerfHost", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton6":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WbioSrvc", "Start", isChoose ? 4 : 2, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WbioSrvc", "DelayedAutoStart", isChoose ? 1 : 0, RegistryValueKind.DWord);
                    break;
                case "TglButton7":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\bthserv", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\BthAvctpSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\BTAGService", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton8":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\Spooler", "Start", isChoose ? 4 : 2, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\PrintNotify", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\McpManagementService", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\Spooler", "DelayedAutoStart", isChoose ? 1 : 0, RegistryValueKind.DWord);
                    break;
                case "TglButton9":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WiaRpc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton10":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\TapiSrv", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\PhoneSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\Fax", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton11":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\SensrSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\SensorService", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\SensorDataService", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\SEMgrSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\lfsvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton12":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\DispBrokerDesktopSvc", "Start", isChoose ? 4 : 2, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WFDSConMgrSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton13":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\CDPSvc", "Start", isChoose ? 4 : 2, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\PushToInstall", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WpnService", "Start", isChoose ? 4 : 2, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\CDPSvc", "DelayedAutoStart", isChoose ? 1 : 0, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WpnService", "DelayedAutoStart", isChoose ? 1 : 0, RegistryValueKind.DWord);
                    break;
                case "TglButton14":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\Netlogon", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\CscService", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\lmhosts", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\FDResPub", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\fdPHost", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\LanmanServer", "Start", isChoose ? 4 : 2, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\LanmanWorkstation", "Start", isChoose ? 4 : 2, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\LanmanServer", "DelayedAutoStart", isChoose ? 1 : 0, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\LanmanWorkstation", "DelayedAutoStart", isChoose ? 1 : 0, RegistryValueKind.DWord);
                    break;
                case "TglButton15":
                    BlockWindowsUpdate(isChoose);
                    ChangeAccessUpdateFolders(isChoose);

                    using (BackgroundWorker backgroundWorker = new BackgroundWorker())
                    {
                        backgroundWorker.DoWork += delegate
                        {
                            TrustedInstaller.CreateProcessAsTrustedInstaller(Settings.PID, $"cmd.exe /c {(isChoose ? "rename " + PathsWinUUP("Worker") + " " + ProgramsUUP["Re_Worker"] : "rename " + PathsWinUUP("Re_Worker") + " " + ProgramsUUP["Worker"])} & " +
                                $"{(isChoose ? "rename " + PathsWinUUP("Core") + " " + ProgramsUUP["Re_Core"] : "rename " + PathsWinUUP("Re_Core") + " " + ProgramsUUP["Core"])} & " +
                                $"{(isChoose ? "rename " + PathsWinUUP("Agent") + " " + ProgramsUUP["Re_Agent"] : "rename " + PathsWinUUP("Re_Agent") + " " + ProgramsUUP["Agent"])} & " +
                                $"{(isChoose ? "rename " + PathsWinUUP("Uso") + " " + ProgramsUUP["Re_Uso"] : "rename " + PathsWinUUP("Re_Uso") + " " + ProgramsUUP["Uso"])} & " +
                                $"{(isChoose ? "rename " + PathsWinUUP("Worker", true) + " " + ProgramsUUP["Re_Worker"] : "rename " + PathsWinUUP("Re_Worker", true) + " " + ProgramsUUP["Worker"])} & " +
                                $"{(isChoose ? "rename " + PathsWinUUP("Core", true) + " " + ProgramsUUP["Re_Core"] : "rename " + PathsWinUUP("Re_Core", true) + " " + ProgramsUUP["Core"])} & " +
                                $"{(isChoose ? "rename " + PathsWinUUP("Agent", true) + " " + ProgramsUUP["Re_Agent"] : "rename " + PathsWinUUP("Re_Agent", true) + " " + ProgramsUUP["Agent"])} ");
                        };
                        backgroundWorker.RunWorkerAsync();
                    }

                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\wisvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\DmEnrollmentSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\wuauserv", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WaaSMedicSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\DoSvc", "Start", isChoose ? 4 : 2, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\UsoSvc", "Start", isChoose ? 4 : 2, RegistryValueKind.DWord);

                    if (isChoose)
                    {
                        RegistryHelp.Write(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\WindowsUpdate\AU", "AllowMUUpdateService", 1, RegistryValueKind.DWord);
                        RegistryHelp.Write(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\WindowsUpdate\AU", "AUOptions", 2, RegistryValueKind.DWord);
                        RegistryHelp.Write(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\WindowsUpdate\AU", "AutomaticMaintenanceEnabled", 1, RegistryValueKind.DWord);
                        RegistryHelp.Write(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\WindowsUpdate\AU", "NoAutoUpdate", 1, RegistryValueKind.DWord);
                        RegistryHelp.Write(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\WindowsUpdate\AU", "NoAutoRebootWithLoggedOnUsers", 1, RegistryValueKind.DWord);
                        RegistryHelp.Write(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\WindowsUpdate\AU", "ScheduledInstallTime", 3, RegistryValueKind.DWord);
                        RegistryHelp.Write(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\WindowsUpdate\AU", "ScheduledInstallDay", 0, RegistryValueKind.DWord);
                    }
                    else
                        RegistryHelp.DeleteFolderTree(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\WindowsUpdate");
                    break;
                case "TglButton16":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\PolicyAgent", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\IKEEXT", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\p2pimsvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton17":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WPDBusEnum", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WMPNetworkSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton18":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\UmRdpService", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\TermService", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\SessionEnv", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\DsSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\RemoteRegistry", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton19":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WerSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\wercplsupport", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\Wecsvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton20":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WebClient", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton21":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\SCPolicySvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\ScDeviceEnum", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\SCardSvr", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\CertPropSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton22":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\AssignedAccessManagerSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\AppReadiness", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton23":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\BDESVC", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\EFS", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton24":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\LxpSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
                case "TglButton25":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\wscsvc", "Start", isChoose ? 4 : 2, RegistryValueKind.DWord, true);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\wscsvc", "DelayedAutoStart", isChoose ? 1 : 0, RegistryValueKind.DWord, true);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WarpJITSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord, true);
                    break;
                case "TglButton26":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WdiServiceHost", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord, true);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\WdiSystemHost", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord, true);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\TroubleshootingSvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord, true);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\DPS", "Start", isChoose ? 4 : 2, RegistryValueKind.DWord, true);
                    break;
                case "TglButton27":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\workfolderssvc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord, true);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\dot3svc", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord, true);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\DevQueryBroker", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord, true);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\AppMgmt", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord, true);
                    break;
                case "TglButton28":
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\vmicvmsession", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\vmictimesync", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\vmicshutdown", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\vmicrdv", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\vmickvpexchange", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\vmicheartbeat", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\vmicguestinterface", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\HvHost", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    RegistryHelp.Write(Registry.LocalMachine, @"SYSTEM\CurrentControlSet\Services\vmicvss", "Start", isChoose ? 4 : 3, RegistryValueKind.DWord);
                    break;
            }
        }

        private static void ChangeAccessUpdateFolders(bool isDenyAccess)
        {
            Task.Run(delegate
            {
                string cachePath = Path.Combine(UsePath.SystemDisk, @"Windows\SoftwareDistribution\Download");

                string[] WinUpdateTasks = new string[] {
                         @"Microsoft\Windows\UpdateOrchestrator\Report policies",
                         @"Microsoft\Windows\UpdateOrchestrator\Schedule Scan",
                         @"Microsoft\Windows\UpdateOrchestrator\Schedule Scan Static Task",
                         @"Microsoft\Windows\UpdateOrchestrator\Schedule Work",
                         @"Microsoft\Windows\UpdateOrchestrator\Start Oobe Expedite Work",
                         @"Microsoft\Windows\UpdateOrchestrator\StartOobeAppsScanAfterUpdate",
                         @"Microsoft\Windows\UpdateOrchestrator\StartOobeAppsScan_LicenseAccepted",
                         @"Microsoft\Windows\UpdateOrchestrator\USO_UxBroker",
                         @"Microsoft\Windows\UpdateOrchestrator\UUS Failover Task",
                         @"Microsoft\Windows\WindowsUpdate\Refresh Group Policy Cache",
                         @"Microsoft\Windows\WindowsUpdate\Scheduled Start"};

                try
                {
                    if (isDenyAccess)
                    {
                        using (ServiceController updateService = new ServiceController("wuauserv"))
                        {
                            if (updateService.Status == ServiceControllerStatus.Running)
                            {
                                updateService.Stop();
                                updateService.WaitForStatus(ServiceControllerStatus.Stopped);
                            }

                            if (Directory.Exists(cachePath))
                                Directory.Delete(cachePath, true);
                        }

                        SetTaskStateOwner(WinUpdateTasks, false);
                    }
                    else
                        SetTaskStateOwner(WinUpdateTasks, true);
                }
                catch (Exception ex) { Debug.WriteLine(ex); }
            });
        }
    }
}
