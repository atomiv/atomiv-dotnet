using System;
using System.Threading;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Test.AspNetCore
{
    public class WebProjectServer : IDisposable
    {
        // private WebProjectPublisher _projectPublisher;
        // private WebProjectRunner _projectRunner;
        private WebProjectDotNetRunner _projectDotNetRunner;

        private WebPortTerminator _portTerminator;

        // TODO: VC: Make configurable
        private const long MaxRetries = 60;

        private const int Pause = 1000;

        public WebProjectServer(WebProjectPaths paths, string url, int port, string pingPath, WebPinger pinger, string environment)
        {
            Paths = paths;
            Url = url;
            Port = port;
            PingPath = pingPath;
            Pinger = pinger;

            // _projectPublisher = new WebProjectPublisher(Paths);
            // _projectRunner = new WebProjectRunner(Paths);
            _projectDotNetRunner = new WebProjectDotNetRunner(Paths, environment);

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

            // _projectPublisher.Run();
            // _projectRunner.Run();
            _projectDotNetRunner.Run();

            await EnsureRunning();
        }

        public Task<WebPingResponse> Ping()
        {
            return Pinger.PingAsync(Url, PingPath);
        }

        public void Dispose()
        {
            // _projectPublisher.Dispose();
            // _projectRunner.Dispose();
            _projectDotNetRunner.Dispose();
        }

        public async Task EnsureNotRunning()
        {
            var pingResponse = await Ping();

            if (pingResponse.Success)
            {
                _portTerminator.EnsureTerminated(Port);
            }

            // TODO: VC: DELETE
            /*
            if (pingResponse)
            {
                throw new Exception($"Web server is already running at {Url}");
            }
            */
        }

        public async Task EnsureRunning()
        {
            var running = false;

            var currentAttempt = 0;

            WebPingResponse pingResponse = null;

            while (!running && currentAttempt < MaxRetries)
            {
                pingResponse = await Ping();
                running = pingResponse.Success;

                if (!running)
                {
                    currentAttempt += 1;
                    Thread.Sleep(Pause);
                }
            }

            if (!running)
            {
                throw new Exception($"Failed to contact web server at {Url}, code {pingResponse.StatusCode}, message {pingResponse.Content}");
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