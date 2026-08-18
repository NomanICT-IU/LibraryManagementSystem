namespace LibraryManagementSystem.DAL.Entities;

public class Member
{
    public int MemberId { get; set; }
    public string Name { get; set; }
    public string MemberCode { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public bool Status { get; set; }
}