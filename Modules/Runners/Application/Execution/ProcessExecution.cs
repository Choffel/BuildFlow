using System.Diagnostics;
using BuildFlow.Modules.Runners.Application.Dtos;
using BuildFlow.Modules.Runners.Infrastructure.Execution;

namespace BuildFlow.Modules.Runners.Application;

public class ProcessExecution : ICommandExecutor
{
    public async Task<ExecutionResult> Execute(string command, string args)
    {
        var process = new Process()
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = args,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        
        process.Start();
        
        var output  = await process.StandardOutput.ReadToEndAsync();
        var error = await process.StandardError.ReadToEndAsync();
        
        process.WaitForExit();
        
        return new ExecutionResult(output, process.ExitCode);
    }
}