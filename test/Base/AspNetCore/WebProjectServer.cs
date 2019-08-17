using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Framework.Test.AspNetCore
{
    public class WebProjectServer : IDisposable
    {
        private WebProjectPublisher _projectPublisher;
        private WebProjectRunner _projectRunner;
        private WebPortTerminator _portTerminator;

        private const long MaxRetries = 5;

        private const int Pause = 1000;

        public WebProjectServer(WebProjectPaths paths, string url, int port, string pingPath, WebPinger pinger)
        {
            Paths = paths;
            Url = url;
            Port = port;
            PingPath = pingPath;
            Pinger = pinger;

            _projectPublisher = new WebProjectPublisher(Paths);
            _projectRunner = new WebProjectRunner(Paths);
            _portTerminator = new WebPortTerminator();
        }

        public WebProjectPaths Paths { get; }

        public string Url { get; }

        public int Port { get; }

        public string PingPath { get; }

        public WebPinger Pinger { get; }

        public async Task Start()
        {
            await EnsureNotRunning();

            _projectPublisher.Run();
            _projectRunner.Run();

            await EnsureRunning();
        }

        public Task<bool> IsRunning()
        {
            return Pinger.PingAsync(Url, PingPath);
        }

        public void Dispose()
        {
            _projectPublisher.Dispose();
            _projectRunner.Dispose();
        }

        public async Task EnsureNotRunning()
        {
            var running = await IsRunning();

            if(running)
            {
                _portTerminator.EnsureTerminated(Port);
            }

            if (running)
            {
                throw new Exception($"Web server is already running at {Url}");
            }
        }

        public async Task EnsureRunning()
        {
            var running = false;

            var currentAttempt = 0;

            while (!running && currentAttempt < MaxRetries)
            {
                running = await IsRunning();

                if (!running)
                {
                    currentAttempt += 1;
                    Thread.Sleep(Pause);
                }
            }

            if (!running)
            {
                throw new Exception($"Failed to contact web server at {Url}");
            }
        }
    }







    // TODO: VC: Rename to ProcessTestServer and return also the client





    // TODO: VC: Old implementation





    /*
    public class WebProjectServer : IDisposable
    {
        private Process _process;

        private const string DotNetFileName = "dotnet";
        private const string RunArg = "run";

        private const long MaxRetries = 30;

        private const int Pause = 1000;

        public WebProjectServer(string directoryPath, string url, string pingPath, WebPinger pinger)
        {
            if(!Directory.Exists(directoryPath))
            {
                throw new ArgumentException($"Directory does not exist: {directoryPath}");
            }

            DirectoryPath = directoryPath;
            Url = url;
            PingPath = pingPath;
            Pinger = pinger;
        }

        public string DirectoryPath { get; }

        public string ProjectPath { get; }

        public string Url { get; }

        public string PingPath { get; }

        public WebPinger Pinger { get; }

        public async Task Start()
        {
            await EnsureNotRunning();
            StartProcess();
            await EnsureRunning();
        }

        public Task<bool> IsRunning()
        {
            return Pinger.PingAsync(Url, PingPath);
        }

        public void Dispose()
        {
            if(_process != null)
            {
                _process.Kill();
                _process.Dispose();



            }
        }

        public async Task EnsureNotRunning()
        {
            var running = await IsRunning();

            if (running)
            {
                throw new Exception($"Web server is already running at {Url}");
            }
        }

        private void StartProcess()
        {
            _process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = DotNetFileName,
                    // Arguments = $"{RunArg} --project {ProjectPath} --launch-profile=Staging --environment=Staging",
                    Arguments = $"{RunArg} --launch-profile=Staging",
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WorkingDirectory = DirectoryPath,
                },
            };

            // TODO: VC: Check there is no connection
            _process.Start();
        }

        public async Task EnsureRunning()
        {
            var running = false;

            var currentAttempt = 0;

            while (!running && currentAttempt < MaxRetries)
            {
                running = await IsRunning();

                if (!running)
                {
                    currentAttempt += 1;
                    Thread.Sleep(Pause);
                }
            }

            if (!running)
            {
                throw new Exception($"Failed to contact web server at {Url}");
            }
        }
    }
    */
}
