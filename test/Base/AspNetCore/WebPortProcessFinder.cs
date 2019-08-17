using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Optivem.Framework.Test.AspNetCore
{
    public class WebPortProcessFinder
    {
        private const int ProtoIndex = 0;
        private const int LocalAddressIndex = 1;
        private const int ForeignAddressIndex = 2;
        private const int StateIndex = 3;
        private const int ProcessIdIndex = 4;

        public WebPortProcessFinder()
        {
        }

        public int? FindProcessId(int port)
        {
            var output = GetOutput();
            var records = GetNetstatRecords(output);
            var processId = GetPort(records, port);

            return processId;
        }

        private string GetOutput()
        {
            using (var process = CreateProcess())
            {
                process.Start();

                var output = process.StandardOutput.ReadToEnd();
                var error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                var exitCode = process.ExitCode;



                if (exitCode != 0)
                {
                    throw new Exception($"Failed to get process id {error}");
                }

                return output;
            }
        }

        private List<NetstatRecord> GetNetstatRecords(string output)
        {
            var lines = output.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            lines = lines.Select(e => e.Trim()).Where(e => e.StartsWith("TCP")).ToArray();

            var records = lines.Select(Parse).ToList();

            return records;
        }

        private int? GetPort(List<NetstatRecord> records, int port)
        {
            var filteredRecords = records
                .Where(e => e.LocalAddress.EndsWith($":{port}") && e.State == "LISTENING")
                .ToList();

            var processIds = filteredRecords
                .Select(e => e.ProcessId)
                .Distinct()
                .ToList();

            if(processIds.Count == 0)
            {
                return null;
            }

            if(processIds.Count == 1)
            {
                return processIds.Single();
            }

            throw new Exception("Multiple process ids found");
        }

        private Process CreateProcess()
        {
            // TODO: VC: Move out to separate class for finding all active ports

            var startInfo = new ProcessStartInfo
            {
                FileName = "netstat",
                Arguments = $"-a -n -o",
                // Arguments = $"netstat -aon | find \"LISTENING\" | find \"{port}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };

            return new Process
            {
                StartInfo = startInfo
            };
        }

        private static NetstatRecord Parse(string line)
        {
            var parts = Regex.Split(line, @"\s{2,}");

            var proto = parts[ProtoIndex];
            var localAddress = parts[LocalAddressIndex];
            var foreignAddress = parts[ForeignAddressIndex];
            var state = parts[StateIndex];
            var processId = int.Parse(parts[ProcessIdIndex]);

            return new NetstatRecord
            {
                Proto = proto,
                LocalAddress = localAddress,
                ForeignAddress = foreignAddress,
                State = state,
                ProcessId = processId,
            };
        }


    }

    public class NetstatRecord
    {
        public string Proto { get; set; }

        public string LocalAddress { get; set; }

        public string ForeignAddress { get; set; }

        public string State { get; set; }

        public int ProcessId { get; set; }
    }
}
