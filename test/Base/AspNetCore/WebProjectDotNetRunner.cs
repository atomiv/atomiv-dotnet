using System;
using System.Diagnostics;

namespace Optivem.Atomiv.Test.AspNetCore
{
    public class WebProjectDotNetRunner : BaseProcessRunner
    {
        private const string DotNet = "dotnet";
        private const string Environment = "--environment";

        public WebProjectDotNetRunner(WebProjectPaths paths, string environmentName)
            : base(false)
        {
            Paths = paths;
            EnvironmentName = environmentName;
        }

        public WebProjectPaths Paths { get; }

        public string EnvironmentName { get; }

        protected override Process CreateProcess()
        {
            var startInfo = new ProcessStartInfo
            {
                // WorkingDirectory = Paths.ProjectDirectoryPath,
                FileName = DotNet,
                Arguments = $"run --project {Paths.ProjectFilePath} {Environment} {EnvironmentName}",
                UseShellExecute = false,
                CreateNoWindow = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };

            var process = new Process
            {
                StartInfo = startInfo
            };

            // TODO: VC: Move to base?

            process.OutputDataReceived += Process_OutputDataReceived;
            process.ErrorDataReceived += Process_ErrorDataReceived;

            return process;
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            throw new Exception($"Detected process error: {e.Data}");
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
        }
    }
}