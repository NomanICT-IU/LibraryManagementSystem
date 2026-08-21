namespace LibraryManagementSystem.DAL.Repository;

public interface IBorrowRecordRepository
{
    public Task<BorrowRecord> CreateBorrowRecordAsync(BorrowRecord borrowRecord, CancellationToken cancellationToken);
    public Task<bool> UpdateBorrowRecordAsync(BorrowRecord borrowRecord, CancellationToken cancellationToken);
    public Task<bool> DeleteBorrowBookAsync(int borrowId, CancellationToken cancellationToken);

    public Task<BorrowRecord> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken);

    public Task<BorrowDetails> IssueDetailsByBorrowedId(int borrowId, CancellationToken cancellationToken);
}

public class BorrowRecordRepository : IBorrowRecordRepository
{
    private readonly IDbConnection _dbConnection;

    public BorrowRecordRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<BorrowRecord> CreateBorrowRecordAsync(BorrowRecord borrowRecord, CancellationToken cancellationToken)
    {

        var command = "dbo.CreateBorrowRecord";
        var parameters = new DynamicParameters();
        parameters.Add("@CopyId", borrowRecord.CopyId);
        parameters.Add("@MemberId", borrowRecord.MemberId);
        parameters.Add("@IssueDate", borrowRecord.IssueDate);
        parameters.Add("@DueDate", borrowRecord.DueDate);

        return await _dbConnection.QuerySingleAsync<BorrowRecord>(command, parameters, commandType: CommandType.StoredProcedure);

    }

    public async Task<bool> DeleteBorrowBookAsync(int borrowId, CancellationToken cancellationToken)
    {
        var command = "dbo.DeleteBorrowRecord";
        var parameters = new DynamicParameters();

        parameters.Add("@BorrowId", borrowId);

        int effectedRows = await _dbConnection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);

        return (effectedRows > 0);
    }

    public async Task<BorrowRecord> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken)
    {
        var command = "dbo.GetBorrowRecordById";
        var parameters = new DynamicParameters();
        parameters.Add("@BorrowId", borrowId);

        return await _dbConnection.QuerySingleAsync<BorrowRecord>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<BorrowDetails> IssueDetailsByBorrowedId(int borrowId, CancellationToken cancellationToken)
    {
        var command = "dbo.IssueDetailsByBorrowedId";
        var parameters = new DynamicParameters();
        parameters.Add("@BorrowId", borrowId);

        return await _dbConnection.QuerySingleAsync<BorrowDetails>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdateBorrowRecordAsync(BorrowRecord borrowRecord, CancellationToken cancellationToken)
    {
        var command = "dbo.UpdateBorrowRecord";
        var parameters = new DynamicParameters();
        parameters.Add("@BorrowId", borrowRecord.BorrowId);
        parameters.Add("@CopyId", borrowRecord.CopyId);
        parameters.Add("@MemberId", borrowRecord.MemberId);
        parameters.Add("@IssueDate", borrowRecord.IssueDate);
        parameters.Add("@DueDate", borrowRecord.DueDate);

        int effectedRows = await _dbConnection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRows > 0;


    }
}