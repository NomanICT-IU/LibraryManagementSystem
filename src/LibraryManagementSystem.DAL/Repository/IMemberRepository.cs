using Dapper;
using LibraryManagementSystem.DAL.Entities;
using System.Data;

namespace LibraryManagementSystem.DAL.Repository;

public interface IMemberRepository
{
    public Task<Member> CreateMember(Member member, CancellationToken cancellationToken);
    public Task<bool> UpdateMember(Member member, CancellationToken cancellationToken);
    public Task<bool> DeleteMember(int memberId, CancellationToken cancellationToken);
    public Task<Member> GetMemberById(int memberId, CancellationToken cancellationToken);
}

public class MemberRepository : IMemberRepository
{
    private readonly IDbConnection _dbConnection;

    public MemberRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Member> CreateMember(
      Member member,
      CancellationToken cancellationToken)
    {
        string command = "dbo.CreateMember";
        var parameters = new DynamicParameters();
        parameters.Add("@Name", member.Name);
        parameters.Add("@MemberCode", member.MemberCode);
        parameters.Add("@Phone", member.Phone);
        parameters.Add("@Email", member.Email);
        parameters.Add("@Address", member.Address);
        parameters.Add("@Status", member.Status);

        return await _dbConnection.QuerySingleAsync<Member>(command, parameters, commandType: CommandType.StoredProcedure);
    }
    public Task<bool> DeleteMember(int memberId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Member> GetMemberById(int memberId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateMember(Member member, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}