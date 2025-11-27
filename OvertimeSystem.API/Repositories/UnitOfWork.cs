using OvertimeSystem.API.Data;

namespace OvertimeSystem.API.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly OvertimeSystemDbContext _context;

    public UnitOfWork(OvertimeSystemDbContext context)
    {
        _context = context;
    }

    public async Task CommitTransactionAsync(Func<Task> action, CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await action();
            await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch 
        {
            await transaction.RollbackAsync(cancellationToken);
            throw; 
        }
    }

    public Task ClearTracksAsync(CancellationToken cancellationToken)
    {
        _context.ChangeTracker.Clear();
        return Task.CompletedTask;
    }
}