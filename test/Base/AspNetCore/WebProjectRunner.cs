using System;
using System.Diagnostics;

namespace Optivem.Atomiv.Test.AspNetCore
{
    public class WebProjectRunner : BaseProcessRunner
    {
        private const string DotNet = "dotnet";
        private const string Environment = "--environment Staging";

        public WebProjectRunner(WebProjectPaths paths)
            : base(false)
        {
            Paths = paths;
        }

        public WebProjectPaths Paths { get; }

        protected override Process CreateProcess()
        {
            var startInfo = new ProcessStartInfo
            {
                WorkingDirectory = Paths.PublishDirectoryPath,
                FileName = DotNet,
                Arguments = $"{Paths.PublishFileName} {Environment}",
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

        protected override void PreProcess()
        {
            if (!Paths.ExistsPublishFilePath())
            {
                throw new Exception($"Cannot run because publish file does not exist: {Paths.PublishFilePath}");
            }
        }
    }
}