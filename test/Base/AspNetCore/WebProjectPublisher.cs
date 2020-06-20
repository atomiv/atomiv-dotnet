using System;
using System.Diagnostics;

// TODO: VC: Based on https://github.com/Tomamais/StartAndStopDotNetCoreApp/blob/master/StartAndStopDotNetCoreApp/Program.cs

namespace Atomiv.Test.AspNetCore
{
    public class WebProjectPublisher : BaseProcessRunner
    {
        private const string DotNet = "dotnet";

        private const string Publish = "publish -o";

        public WebProjectPublisher(WebProjectPaths paths)
            : base(true)
        {
            Paths = paths;
        }

        public WebProjectPaths Paths { get; }

        protected override Process CreateProcess()
        {
            var startInfo = new ProcessStartInfo
            {
                WorkingDirectory = Paths.ProjectDirectoryPath,
                FileName = DotNet,
                Arguments = $"{Publish} {Paths.PublishDirectoryPath}",
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            return new Process
            {
                StartInfo = startInfo
            };
        }

        protected override void PreProcess()
        {
            if (!Paths.ExistsProjectDirectory())
            {
                throw new Exception($"Cannot publish because directory does not exist: {Paths.ProjectDirectoryPath}");
            }
        }

        protected override void PostProcess()
        {
            if (!Paths.ExistsPublishFilePath())
            {
                throw new Exception($"Publish has failed because file was not generated: {Paths.PublishFilePath}");
            }
        }
    }
}