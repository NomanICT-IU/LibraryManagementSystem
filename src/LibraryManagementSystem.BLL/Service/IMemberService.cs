using LibraryManagementSystem.BLL.Dtos;
using LibraryManagementSystem.DAL.Entities;
using LibraryManagementSystem.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.BLL.Service;

public interface IMemberService
{
    public Task<MemberDto> CreateMember(MemberDto memberDto, CancellationToken cancellationToken);
    public Task<bool> UpdateMember(MemberDto member, CancellationToken cancellationToken);
    public Task<bool> DeleteMember(int memberId, CancellationToken cancellationToken);
    public Task<MemberDto> GetMemberById(int memberId, CancellationToken cancellationToken);
}

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;

    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }
    public async Task<MemberDto> CreateMember(MemberDto memberDto, CancellationToken cancellationToken)
    {
        Member member = new Member
        {
            MemberId = memberDto.MemberId,
            Name = memberDto.Name,
            MemberCode = memberDto.MemberCode,
            Phone = memberDto.Phone,
            Email = memberDto.Email,
            Address = memberDto.Address,
            Status = memberDto.Status
        };

        member = await _memberRepository.CreateMember(member, cancellationToken);

        return new MemberDto
        {
            MemberId = member.MemberId,
            Name = member.Name,
            MemberCode = member.MemberCode,
            Phone = member.Phone,
            Email = member.Email,
            Address = member.Address,
            Status = member.Status
        };

    }

    public Task<bool> DeleteMember(int memberId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<MemberDto> GetMemberById(int memberId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateMember(MemberDto member, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}