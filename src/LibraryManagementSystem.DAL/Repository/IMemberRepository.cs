using LibraryManagementSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.DAL.Repository;

public interface IMemberRepository
{
    public Task<Member> CreateMember(Member member, CancellationToken cancellationToken);
    public Task<Member> UpdateMember(Member member, CancellationToken cancellationToken);
    public Task<bool> DeleteMember(int memberId, CancellationToken cancellationToken);
    public Task<Member> GetMemberById(int memberId, CancellationToken cancellationToken);
}

public class MemberRepository : IMemberRepository
{
    public Task<Member> CreateMember(Member member, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteMember(int memberId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Member> GetMemberById(int memberId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Member> UpdateMember(Member member, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}