using Dapper;
using LibraryManagementSystem.DAL.Entities;
using System.Data;

namespace LibraryManagementSystem.DAL.Repository;

public interface IBookRepositroy
{
    public Task<Book> CreateBook(Book book, CancellationToken cancellationToken);
    public Task<bool> UpdateBook(Book book, CancellationToken cancellationToken);
    public Task<bool> DeleteBook(int bookId, CancellationToken cancellationToken);

    public Task<Book> GetBookById(int bookId, CancellationToken cancellationToken);
    
}


public class BookRepositroy : IBookRepositroy
{
    private readonly IDbConnection Connection;
    public BookRepositroy(IDbConnection connection)
    {
        Connection = connection;
    }


    public async Task<Book> CreateBook(Book book, CancellationToken cancellationToken)
    {
        string command = "dbo.CreateBook";
        var parameters = new DynamicParameters();
        parameters.Add("@Title", book.Title);
        parameters.Add("@Author", book.Author);
        parameters.Add("@ISBN", book.ISBN);
        parameters.Add("@Category", book.Category);
        return await Connection.QuerySingleAsync<Book>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> DeleteBook(int bookId, CancellationToken cancellationToken)
    {
        string command = "dbo.DeleteBook";
        var parameters = new DynamicParameters();
        parameters.Add("@BookId", bookId);
        int effectedRows=  await Connection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRows > 0;
    }

    public async Task<Book> GetBookById(int bookId, CancellationToken cancellationToken)
    {
        string command = "dbo.GetBookById";
        var parameters = new DynamicParameters();
        parameters.Add("@BookId", bookId);
        return await Connection.QuerySingleAsync<Book>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdateBook(Book book, CancellationToken cancellationToken)
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