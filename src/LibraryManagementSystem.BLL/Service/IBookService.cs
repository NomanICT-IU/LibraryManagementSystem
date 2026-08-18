using LibraryManagementSystem.BLL.Dtos;
using LibraryManagementSystem.DAL.Entities;
using LibraryManagementSystem.DAL.Repository;

namespace LibraryManagementSystem.BLL.Service;

public interface IBookService
{
    public Task<BookDto> CreateBook(BookDto book, CancellationToken cancellationToken);
    public Task<bool> UpdateBook(BookDto book, CancellationToken cancellationToken);
    public Task<bool> DeleteBook(int bookId, CancellationToken cancellationToken);

    public Task<BookDto> GetBookById(int bookId, CancellationToken cancellationToken);
}

public class BookService : IBookService
{
    private readonly IBookRepositroy _bookRepository;
    public BookService(IBookRepositroy bookRepositroy)
    {
        _bookRepository = bookRepositroy;
    }
    public async Task<BookDto> CreateBook(BookDto bookDto, CancellationToken cancellationToken)
    {
        Book book = new Book
        {
            Title = bookDto.Title,
            Author = bookDto.Author,
            ISBN = bookDto.ISBN,
            Category = bookDto.Category
        };

        book = await _bookRepository.CreateBook(book, cancellationToken);

        return new BookDto(book.BookId, book.Title, book.Author, book.ISBN, book.Category);
    }

    public async Task<bool> DeleteBook(int bookId, CancellationToken cancellationToken)
    {
        var isDeleted = await _bookRepository.DeleteBook(bookId, cancellationToken);

        if (!isDeleted)
            throw new InvalidOperationException("Book not deleted.");

        return isDeleted;
    }

    public async Task<BookDto> GetBookById(int bookId, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetBookById(bookId, cancellationToken);
        if (book is null)
        {
            throw new KeyNotFoundException($"Book with ID {bookId} was not found.");
        }
        return new BookDto(book.BookId, book.Title, book.Author, book.ISBN, book.Category);

    }

    public async Task<bool> UpdateBook(BookDto bookDto, CancellationToken cancellationToken)
    {
        Book book = new Book
        {
            BookId = bookDto.BookId,
            Title = bookDto.Title,
            Author = bookDto.Author,
            ISBN = bookDto.ISBN,
            Category = bookDto.Category
        };

        var isUpdated = await _bookRepository.UpdateBook(book , cancellationToken);

        if (!isUpdated)
            throw new InvalidOperationException("Book not updated.");

        return isUpdated;
    }
}