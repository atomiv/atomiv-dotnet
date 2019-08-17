using System;
using System.Diagnostics;

namespace Optivem.Framework.Test.AspNetCore
{
    public class ProcessTerminator
    {
        public void Terminate(int processId)
        {
            using (var process = CreateProcess(processId))
            {
                process.Start();

                process.WaitForExit();

                var exitCode = process.ExitCode;

                if(exitCode != 0)
                {
                    throw new Exception($"Failed to terminate process {processId}");
                }
            }
        }

        private Process CreateProcess(int processId)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "taskkill",
                Arguments = $"/PID {processId} /F",
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            return new Process
            {
                StartInfo = startInfo
            };
        }
    }
}
