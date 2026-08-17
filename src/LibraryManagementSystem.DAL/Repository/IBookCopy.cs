using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.DAL.Repository;

public interface IBookCopy
{
    public Task<BookCopy> CreateBookCopy(BookCopy bookCopy, CancellationToken cancellationToken);
    public Task<BookCopy> UpdateBookCopy(BookCopy bookCopy, CancellationToken cancellationToken);
    public Task<bool> DeleteBookCopy(int CopyId, CancellationToken cancellationToken);
    public Task<BookCopy> GetBookCopyById(int CopyId, CancellationToken cancellationToken);
}

public class BookCopy : IBookCopy
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