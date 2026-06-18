namespace BuildFlow.Modules.Runners.Application.Dtos;

public record ExecutionResult(
    string Output,
    int Error
    );