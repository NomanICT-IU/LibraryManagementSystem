using LibrarymanagementSystem.Shared;

namespace LibraryManagementSystem.BLL.Service;

public interface IMemberService
{
    public Task<MemberDto> CreateMemberAsync(MemberDto memberDto, CancellationToken cancellationToken);
    public Task<bool> UpdateMemberAsync(MemberDto memberDto, CancellationToken cancellationToken);
    public Task<bool> DeleteMemberAsync(int memberId, CancellationToken cancellationToken);
    public Task<MemberDto> GetMemberByIdAsync(int memberId, CancellationToken cancellationToken);
}

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;

    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }
    public async Task<MemberDto> CreateMemberAsync(MemberDto memberDto, CancellationToken cancellationToken)
    {
        //Member member = new Member
        //{
        //    Name = memberDto.Name,
        //    MemberCode = memberDto.MemberCode,
        //    Phone = memberDto.Phone,
        //    Email = memberDto.Email,
        //    Address = memberDto.Address,
        //    Status = memberDto.Status
        //};

        var member = memberDto.Adapt<Member>();

        member = await _memberRepository.CreateMember(member, cancellationToken);

        memberDto.MemberId= member.MemberId;

        return memberDto;
    }

    public async Task<bool> DeleteMemberAsync(int memberId, CancellationToken cancellationToken)
    {
        var member = await _memberRepository.GetMemberById(memberId, cancellationToken);

        var isDeleted = await _memberRepository.DeleteMember(memberId, cancellationToken);
        if (!isDeleted)
            throw new InvalidOperationException("Member not deleted.");

        return isDeleted;
    }

    public async Task<MemberDto> GetMemberByIdAsync(int memberId, CancellationToken cancellationToken)
    {

        var member = await _memberRepository.GetMemberById(memberId, cancellationToken);

        var memberDto= member.Adapt<MemberDto>();
        return memberDto;
        //return new MemberDto
        //{
        //    MemberId = member.MemberId,
        //    Name = member.Name,
        //    MemberCode = member?.MemberCode,
        //    Phone = member.Phone,
        //    Email = member.Email,
        //    Address = member.Address,
        //    Status = member.Status,
        //};

    }

    public async Task<bool> UpdateMemberAsync(MemberDto memberDto, CancellationToken cancellationToken)
    {
        var member = memberDto.Adapt<Member>();

       var isUpdated = await _memberRepository.UpdateMember(member, cancellationToken);

        if (!isUpdated)
            throw new InvalidOperationException("Member not updated.");

        return isUpdated;
    }
}