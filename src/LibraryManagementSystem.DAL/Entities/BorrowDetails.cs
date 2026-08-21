namespace LibraryManagementSystem.DAL.Entities;

public class BorrowDetails
{
    public string Title { get; set; }
    public string CopyCode { get; set; }
    public string Name { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; }
}
