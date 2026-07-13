using DocQnA.Application.Common;

using Microsoft.Extensions.Logging;

namespace DocQnA.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly DocQnADbContext _dbContext;

    private readonly ILogger<UnitOfWork> _logger;

    public UnitOfWork(
        DocQnADbContext dbContext,
        ILogger<UnitOfWork> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while saving changes to the database.");
            throw;
        }
    }
}
