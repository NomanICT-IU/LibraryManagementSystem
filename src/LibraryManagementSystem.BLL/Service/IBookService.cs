using LibrarymanagementSystem.Shared;

namespace LibraryManagementSystem.BLL.Service;

public interface IBookService
{
    public Task<BookDto> CreateBookAsync(BookDto book, CancellationToken cancellationToken);
    public Task<bool> UpdateBookAsync(BookDto book, CancellationToken cancellationToken);
    public Task<bool> DeleteBookAsync(int bookId, CancellationToken cancellationToken);

    public Task<BookDto> GetBookByIdAsync(int bookId, CancellationToken cancellationToken);

    public Task<IEnumerable<BookSearchDetailDto>> SearchBooksAsync(string searchBy, string searchText, CancellationToken cancellationToken);
}

public class BookService : IBookService
{
    private readonly IBookRepositroy _bookRepository;
    public BookService(IBookRepositroy bookRepositroy)
    {
        _bookRepository = bookRepositroy;
    }

    public async Task<IEnumerable<BookSearchDetailDto>> SearchBooksAsync(string searchBy, string searchText, CancellationToken cancellationToken)
    {
        var results = await _bookRepository.SearchBooksAsync(searchBy, searchText, cancellationToken);

        return results.Adapt<IEnumerable<BookSearchDetailDto>>(); 
    }
    public async Task<BookDto> CreateBookAsync(BookDto bookDto, CancellationToken cancellationToken)
    {
        Book book = new Book
        {
            Title = bookDto.Title,
            Author = bookDto.Author,
            ISBN = bookDto.ISBN,
            Category = bookDto.Category
        };

        book = await _bookRepository.CreateBookAsync(book, cancellationToken);

        return new BookDto(book.BookId, book.Title, book.Author, book.ISBN, book.Category);
    }

    public async Task<bool> DeleteBookAsync(int bookId, CancellationToken cancellationToken)
    {
        var isDeleted = await _bookRepository.DeleteBookAsync(bookId, cancellationToken);

        if (!isDeleted)
            throw new InvalidException("Book not deleted.");

        return isDeleted;
    }

    public async Task<BookDto> GetBookByIdAsync(int bookId, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetBookByIdAsync(bookId, cancellationToken);
        if (book is null)
        {
            throw new NotFoundException($"Book with ID {bookId} was not found.");
        }
        return new BookDto(book.BookId, book.Title, book.Author, book.ISBN, book.Category);

    }



    public async Task<bool> UpdateBookAsync(BookDto bookDto, CancellationToken cancellationToken)
    {
        Book book = new Book
        {
            BookId = bookDto.BookId,
            Title = bookDto.Title,
            Author = bookDto.Author,
            ISBN = bookDto.ISBN,
            Category = bookDto.Category
        };

        var isUpdated = await _bookRepository.UpdateBookAsync(book , cancellationToken);

        if (!isUpdated)
            throw new InvalidOperationException("Book not updated.");

        return isUpdated;
    }
}