namespace LibraryManagementSystem.DAL.Repository;

public interface IMemberSearchRepository
{
    public Task<FindMember> SearchMember(string searchText, CancellationToken cancellationToken);
}
public class MemberSearchRepository : IMemberSearchRepository
{
    private readonly IDbConnection _dbConnection;

    public MemberSearchRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<FindMember> SearchMember(string searchText, CancellationToken cancellationToken)
    {
        var command = "dbo.FindMember";
        var parameters = new DynamicParameters();
        parameters.Add("@searchText", searchText);

        return await _dbConnection.QuerySingleAsync<FindMember>(command, parameters, commandType: CommandType.StoredProcedure);
    }
}