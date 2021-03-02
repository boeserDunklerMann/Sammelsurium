using System.Diagnostics;

namespace DA.Commons.Hodgepodge.NetCore.Commons
{
	/// <ChangeLog>
	/// <Create Datum="14.02.2021" Entwickler="DA" />
	/// </ChangeLog>
	/// <remarks>https://loune.net/2017/06/running-shell-bash-commands-in-net-core/</remarks>
	public static class ShellHelper
    {
        public static string Bash(this string cmd, bool waitForExit)
        {

            var process = new Process()
            {
                StartInfo = cmd.PrepareBash()
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            if (waitForExit)
                process.WaitForExit();
            return result;
        }

        public static ProcessStartInfo PrepareBash(this string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = $"-c \"{escapedArgs}\"",
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };
            return psi;
        }
    }
}
