using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Test.AspNetCore
{
    // TODO: VC: Rename to ProcessTestServer and return also the client

    public class WebProjectServer : IDisposable
    {
        private Process _process;

        private const string DotNetFileName = "dotnet";
        private const string RunArg = "run";
        private const string ProjectParam = "project";

        private const long MaxRetries = 30;

        private const int Pause = 1000;

        public WebProjectServer(string projectPath, string url, string pingPath, WebPinger pinger)
        {
            if(!File.Exists(projectPath))
            {
                throw new ArgumentException($"File does not exist: {projectPath}");
            }

            ProjectPath = projectPath;
            Url = url;
            PingPath = pingPath;
            Pinger = pinger;
        }

        public string ProjectPath { get; }

        public string Url { get; }

        public string PingPath { get; }

        public WebPinger Pinger { get; }

        public async Task Start()
        {
            var running = await Pinger.PingAsync(Url, PingPath);

            // TODO: VC: check

            if(running)
            {
                return;
            }

            if(running)
            {
                throw new Exception($"Web server is already running at {Url}");
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

            // TODO: VC: Check there is no connection
            _process.Start();

            var currentAttempt = 0;

            while(!running && currentAttempt < MaxRetries)
            {
                running = await Pinger.PingAsync(Url, PingPath);

                if(!running)
                {
                    currentAttempt += 1;
                    Thread.Sleep(Pause);
                }
            }

            if(!running)
            {
                throw new Exception($"Failed to contact web server at {Url}");
            }
        }

        public void Dispose()
        {
            if(_process != null && !_process.HasExited)
            {
                _process.Kill();
                _process = null;
            }
        }
    }
}
