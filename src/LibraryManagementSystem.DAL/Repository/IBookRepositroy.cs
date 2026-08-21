namespace LibraryManagementSystem.DAL.Repository;

public interface IBookRepositroy
{
    public Task<Book> CreateBookAsync(Book book, CancellationToken cancellationToken);
    public Task<bool> UpdateBookAsync(Book book, CancellationToken cancellationToken);
    public Task<bool> DeleteBookAsync(int bookId, CancellationToken cancellationToken);

    public Task<Book> GetBookByIdAsync(int bookId, CancellationToken cancellationToken);
    public Task<IEnumerable<BookSearchDetail>> SearchBooksAsync(string searchBy, string searchText,  CancellationToken cancellationToken);


}


public class BookRepositroy : IBookRepositroy
{
    private readonly IDbConnection _connection;
    public BookRepositroy(IDbConnection connection)
    {
        _connection = connection;
    }


    public async Task<Book> CreateBookAsync(Book book, CancellationToken cancellationToken)
    {
        string command = "dbo.CreateBook";
        var parameters = new DynamicParameters();
        parameters.Add("@Title", book.Title);
        parameters.Add("@Author", book.Author);
        parameters.Add("@ISBN", book.ISBN);
        parameters.Add("@Category", book.Category);
        return await _connection.QuerySingleAsync<Book>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> DeleteBookAsync(int bookId, CancellationToken cancellationToken)
    {
        string command = "dbo.DeleteBook";
        var parameters = new DynamicParameters();
        parameters.Add("@BookId", bookId);
        int effectedRows=  await _connection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRows > 0;
    }

    public async Task<Book> GetBookByIdAsync(int bookId, CancellationToken cancellationToken)
    {
        string command = "dbo.GetBookById";
        var parameters = new DynamicParameters();
        parameters.Add("@BookId", bookId);
        return await _connection.QuerySingleOrDefaultAsync<Book>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<BookSearchDetail>> SearchBooksAsync(string searchBy, string searchText, CancellationToken cancellationToken)
    {
        var command = "dbo.SearchBook";
        var parameters = new DynamicParameters();
        parameters.Add("@SearchBy", searchBy);
        parameters.Add("@SearchText", searchText);

        return await _connection.QueryAsync<BookSearchDetail>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdateBookAsync(Book book, CancellationToken cancellationToken)
    {
        string command = "dbo.CreateBook";
        var parameters = new DynamicParameters();
        parameters.Add("@BookId", book.BookId);
        parameters.Add("@Title", book.Title);
        parameters.Add("@Author", book.Author);
        parameters.Add("@ISBN", book.ISBN);
        parameters.Add("@Category", book.Category);
        int effectedRows = await _connection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRows > 0;
    }
}