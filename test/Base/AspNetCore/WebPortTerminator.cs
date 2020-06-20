using System;

namespace Atomiv.Test.AspNetCore
{
    public class WebPortTerminator
    {
        private WebPortProcessFinder _portProcessFinder;
        private ProcessTerminator _processTerminator;

        public WebPortTerminator()
        {
            _portProcessFinder = new WebPortProcessFinder();
            _processTerminator = new ProcessTerminator();
        }

        // netstat -ano | findstr :5109
        // TCP    127.0.0.1:5109         0.0.0.0:0              LISTENING       14624
        // taskkill /PID 14624 /F
        // SUCCESS: The process with PID 14624 has been terminated.

        public void EnsureTerminated(int port)
        {
            var processId = _portProcessFinder.FindProcessId(port);

            if (processId == null)
            {
                throw new Exception($"Failed to find process for port {port}");
            }

            _processTerminator.Terminate(processId.Value);
        }
    }
}