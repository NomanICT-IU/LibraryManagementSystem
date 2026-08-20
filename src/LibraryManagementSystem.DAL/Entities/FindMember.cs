namespace LibraryManagementSystem.DAL.Entities;

public class FindMember
{
    public string Name { get; set; }
    public string MemberId { get; set; }
    public string Phone { get; set; }
    public int Borrowed { get; set; }
}
