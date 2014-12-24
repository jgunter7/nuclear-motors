using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

/// <summary>
/// Summary description for CPU
/// </summary>
public class CPU
{
    public CPU()
    {  
    }

    public static string getCurrentCpuUsage()
    {
        PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
        cpuCounter.NextValue();
        System.Threading.Thread.Sleep(500);
        return cpuCounter.NextValue() + "%";
    }

    public static string getAvailableRAM()
    {
        PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        return ramCounter.NextValue() + "MB";
    }

    public static string GetUpTime()
    {
        long ticks = Stopwatch.GetTimestamp();
        double uptime = ((double)ticks) / Stopwatch.Frequency;
        TimeSpan uptimeSpan = TimeSpan.FromSeconds(uptime);
        return uptimeSpan.ToString(@"d\.hh\:mm\:ss");
    }
}