namespace LibraryManagementSystem.BLL.Dtos;

public class FindMemberDto
{
    public string Name { get; set; }
    public string MemberId { get; set; }
    public string Phone { get; set; }
    public int Borrowed { get; set; }
}
