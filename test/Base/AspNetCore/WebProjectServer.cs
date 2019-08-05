using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Optivem.Framework.Test.AspNetCore
{
    public class WebProjectServer : IDisposable
    {
        private Process _process;

        private const string DotNetFileName = "dotnet";
        private const string RunArg = "run";
        private const string ProjectParam = "project";

        public WebProjectServer(string projectPath)
        {
            if(!File.Exists(projectPath))
            {
                throw new ArgumentException($"File does not exist: {projectPath}");
            }

            _process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    // WorkingDirectory = 
                    FileName = DotNetFileName,
                    Arguments = $"{RunArg} --project {ProjectPath}",
                },
            };
        }

        public string ProjectPath { get; }

        public void Start()
        {
            _process.Start();
        }

        public void Dispose()
        {
            if(!_process.HasExited)
            {
                _process.Kill();
            }
        }
    }
}
