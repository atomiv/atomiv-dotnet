using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Atomiv.Test.AspNetCore
{
    public abstract class BaseProcessRunner : IDisposable
    {
        protected Process _process;

        public BaseProcessRunner(bool waitForExit)
        {
            WaitForExit = waitForExit;
        }

        public bool WaitForExit { get; }

        public void Run()
        {
            PreProcess();

            _process = CreateProcess();

            _process.Start();

            if (WaitForExit)
            {
                _process.WaitForExit();
            }

            // TODO: VC: Detect process start error

            if (_process.HasExited && _process.ExitCode != 0)
            {
                var error = _process.StandardError.ReadToEnd();

                throw new Exception($"Failed to publish, exit code {_process.ExitCode}, error: {error}");
            }

            PostProcess();
        }

        public Task ReadOutputAsync()
        {
            return _process.StandardOutput.ReadToEndAsync();
        }

        public Task ReadErrorAsync()
        {
            return _process.StandardError.ReadToEndAsync();
        }

        public void Dispose()
        {
            if (_process != null)
            {
                if (!_process.HasExited)
                {
                    _process.Kill();
                }

                _process.Close();
                _process.Dispose();
            }
        }

        protected abstract Process CreateProcess();

        protected virtual void PreProcess()
        {
            // NOTE: By default, no action
        }

        protected virtual void PostProcess()
        {
            // NOTE: By default, no action
        }
    }
}