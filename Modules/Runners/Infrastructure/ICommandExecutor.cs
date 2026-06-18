namespace BuildFlow.Modules.Runners.Infrastructure.Execution;

public interface ICommandExecutor
{
    Task<ExecutionResult> Execute(string command, string args);
}