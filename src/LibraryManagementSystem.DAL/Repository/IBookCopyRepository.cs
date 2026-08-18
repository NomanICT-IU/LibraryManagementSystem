using LibraryManagementSystem.DAL.Entities;

namespace LibraryManagementSystem.DAL.Repository;

public interface IBookCopyRepository
{
    public Task<BookCopy> CreateBookCopy(BookCopy bookCopy, CancellationToken cancellationToken);
    public Task<BookCopy> UpdateBookCopy(BookCopy bookCopy, CancellationToken cancellationToken);
    public Task<bool> DeleteBookCopy(int CopyId, CancellationToken cancellationToken);
    public Task<BookCopy> GetBookCopyById(int CopyId, CancellationToken cancellationToken);
}

public class BookCopyRepository : IBookCopyRepository
{
    public Task<BookCopy> CreateBookCopy(BookCopy bookCopy, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteBookCopy(int CopyId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BookCopy> GetBookCopyById(int CopyId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BookCopy> UpdateBookCopy(BookCopy bookCopy, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}