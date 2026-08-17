using LibraryManagementSystem.DAL.Entities;

namespace LibraryManagementSystem.DAL.Repository;

public interface IBookRepositroy
{
    public Task<Book> CreateBook(Book book, CancellationToken cancellationToken);
    public Task<Book> UpdateBook(Book book, CancellationToken cancellationToken);
    public Task<bool> DeleteBook(int bookId, CancellationToken cancellationToken);

    public Task<Book> GetBookById(int bookId, CancellationToken cancellationToken);
    
}


public class BookRepositroy : IBookRepositroy
{
    public Task<Book> CreateBook(Book book, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteBook(int bookId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetBookById(int bookId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Book> UpdateBook(Book book, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}