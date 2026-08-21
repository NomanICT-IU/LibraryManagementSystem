namespace LibraryManagementSystem.BLL.Dtos;

public class MemberSearchDto
{
    public string Name { get; set; }
    public string MemberCode { get; set; }
    public string Phone { get; set; }
    public int Borrowed { get; set; }
}
