
namespace LibraryManagementSystem.DAL.Repository;

public interface IBookCopyRepository
{
    public Task<BookCopy> CreateBookCopyAsync(BookCopy bookCopy, CancellationToken cancellationToken);
    public Task<bool> UpdateBookCopyAsync(BookCopy bookCopy, CancellationToken cancellationToken);
    public Task<bool> DeleteBookCopyAsync(int CopyId, CancellationToken cancellationToken);
    public Task<BookCopy> GetBookCopyByIdAsync(int CopyId, CancellationToken cancellationToken);
}

public class BookCopyRepository : IBookCopyRepository
{
    private readonly IDbConnection _dbConnection;

    public BookCopyRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<BookCopy> CreateBookCopyAsync(BookCopy bookCopy, CancellationToken cancellationToken)
    {
        var command = "dbo.CreateBookCopy";

        var parameters = new DynamicParameters();
        parameters.Add("@CopyCode", bookCopy.CopyCode);
        parameters.Add("@BookId", bookCopy.BookId);
        parameters.Add("@Status", bookCopy.Status);
        return await _dbConnection.QuerySingleAsync<BookCopy>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> DeleteBookCopyAsync(int CopyId, CancellationToken cancellationToken)
    {
        var command = "dbo.DeleteBookCopy";
        var parameters = new DynamicParameters();
        parameters.Add("@CopyId", CopyId);
        var effectedRows = await _dbConnection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);

        return effectedRows > 0;
    }

    public async Task<BookCopy> GetBookCopyByIdAsync(int CopyId, CancellationToken cancellationToken)
    {
        var command = "GetBookCopyById";
        var parameters = new DynamicParameters();
        parameters.Add("@CopyId", CopyId);

        return await _dbConnection.QuerySingleAsync<BookCopy>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdateBookCopyAsync(BookCopy bookCopy, CancellationToken cancellationToken)
    {
        var command = "UpdateBookCopy";
        var parameters = new DynamicParameters();
        parameters.Add("@CopyId", bookCopy.CopyId);
        parameters.Add("@CopyCode", bookCopy.CopyCode);
        parameters.Add("@BookId", bookCopy.BookId);
        parameters.Add("@Status", bookCopy.Status);
        var effectedRows = await _dbConnection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRows > 0;
    }
}