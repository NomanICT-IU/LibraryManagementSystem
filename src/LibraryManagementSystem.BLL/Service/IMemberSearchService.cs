namespace LibraryManagementSystem.BLL.Service;

public interface IMemberSearchService
{
    public Task<FindMemberDto> SearchMember(string searchText, CancellationToken cancellationToken);
}
public class MemberSearchService : IMemberSearchService
{
    private readonly IMemberSearchRepository _memberSearchRepository;

    public MemberSearchService(IMemberSearchRepository memberSearchRepository)
    {
        _memberSearchRepository = memberSearchRepository;
    }
    public async Task<FindMemberDto> SearchMember(string searchText, CancellationToken cancellationToken)
    {
        var member = await _memberSearchRepository.SearchMember(searchText, cancellationToken);

        var memberDto = member.Adapt<FindMemberDto>();
        return memberDto;
    }
}