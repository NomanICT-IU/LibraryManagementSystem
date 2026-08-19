namespace LibraryManagementSystem.DAL.Repository;

public interface IBookRepositroy
{
    public Task<Book> CreateBookAsync(Book book, CancellationToken cancellationToken);
    public Task<bool> UpdateBookAsync(Book book, CancellationToken cancellationToken);
    public Task<bool> DeleteBookAsync(int bookId, CancellationToken cancellationToken);

    public Task<Book> GetBookByIdAsync(int bookId, CancellationToken cancellationToken);
    
}


public class BookRepositroy : IBookRepositroy
{
    private readonly IDbConnection Connection;
    public BookRepositroy(IDbConnection connection)
    {
        Connection = connection;
    }


    public async Task<Book> CreateBookAsync(Book book, CancellationToken cancellationToken)
    {
        string command = "dbo.CreateBook";
        var parameters = new DynamicParameters();
        parameters.Add("@Title", book.Title);
        parameters.Add("@Author", book.Author);
        parameters.Add("@ISBN", book.ISBN);
        parameters.Add("@Category", book.Category);
        return await Connection.QuerySingleAsync<Book>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> DeleteBookAsync(int bookId, CancellationToken cancellationToken)
    {
        string command = "dbo.DeleteBook";
        var parameters = new DynamicParameters();
        parameters.Add("@BookId", bookId);
        int effectedRows=  await Connection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRows > 0;
    }

    public async Task<Book> GetBookByIdAsync(int bookId, CancellationToken cancellationToken)
    {
        string command = "dbo.GetBookById";
        var parameters = new DynamicParameters();
        parameters.Add("@BookId", bookId);
        return await Connection.QuerySingleAsync<Book>(command, parameters, commandType: CommandType.StoredProcedure);
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
        int effectedRows = await Connection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRows > 0;
    }
}