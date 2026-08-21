namespace LibraryManagementSystem.BLL.Dtos;

public class BorrowDetailsDto
{
    public string Title { get; set; }
    public string CopyCode { get; set; }
    public string Name { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; }
}
