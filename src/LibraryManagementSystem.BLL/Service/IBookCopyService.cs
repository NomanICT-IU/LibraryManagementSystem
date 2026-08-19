namespace LibraryManagementSystem.BLL.Service;

public interface IBookCopyService
{
    public Task<BookCopyDto> CreateBookCopyAsync(BookCopyDto bookCopyDto, CancellationToken cancellationToken);
    public Task<bool> UpdateBookCopyAsync(BookCopyDto bookCopyDto, CancellationToken cancellationToken);
    public Task<bool> DeleteBookCopyAsync(int CopyId, CancellationToken cancellationToken);
    public Task<BookCopyDto> GetBookCopyByIdAsync(int CopyId, CancellationToken cancellationToken);
}

public class BookCopyService : IBookCopyService
{
    private readonly IBookCopyRepository _bookCopyRepository;

    public BookCopyService(IBookCopyRepository bookCopyRepository)
    {
        _bookCopyRepository = bookCopyRepository;
    }
    public async Task<BookCopyDto> CreateBookCopyAsync(BookCopyDto bookCopyDto, CancellationToken cancellationToken)
    {
        var bookCopy = bookCopyDto.Adapt<BookCopy>();

        bookCopy = await _bookCopyRepository.CreateBookCopyAsync(bookCopy, cancellationToken);

        bookCopyDto.CopyId = bookCopy.CopyId;
        return bookCopyDto;
    }

    public async Task<bool> DeleteBookCopyAsync(int CopyId, CancellationToken cancellationToken)
    {
        var isDeleted = await _bookCopyRepository.DeleteBookCopyAsync(CopyId, cancellationToken);

        if (!isDeleted)
            throw new InvalidOperationException("BookCopy not deleted.");

        return isDeleted;
    }

    public async Task<BookCopyDto> GetBookCopyByIdAsync(int CopyId, CancellationToken cancellationToken)
    {
        var bookCopy = await GetBookCopyByIdAsync(CopyId, cancellationToken);

        var memberDto = bookCopy.Adapt<BookCopyDto>();
        return memberDto;
    }

    public async Task<bool> UpdateBookCopyAsync(BookCopyDto bookCopyDto, CancellationToken cancellationToken)
    {
        var bookCopy = bookCopyDto.Adapt<BookCopy>();
        var isUpdated = await _bookCopyRepository.UpdateBookCopyAsync(bookCopy, cancellationToken);
        if (!isUpdated)
            throw new InvalidOperationException("BookCopy not updated.");

        return isUpdated;
    }
}
