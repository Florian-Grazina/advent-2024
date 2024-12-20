using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        string exePath = "C:\\Users\\fgrazina.PPI\\Source\\repos\\Florian-Grazina\\advent-2024\\17\\bin\\Debug\\net8.0\\17.exe"; 

        for (int i = 1; i <= 10; i++)
        {
            int start = 100000000 * i;

            string arguments = $"{start}"; // Replace with your arguments logic

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = arguments,
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                UseShellExecute = true,
                CreateNoWindow = false
            };

            try
            {
                Process process = Process.Start(startInfo);
                Console.WriteLine($"Started instance {i} with arguments: {arguments} (PID: {process?.Id})");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to start instance {i}: {ex.Message}");
            }
        }
    }
}
