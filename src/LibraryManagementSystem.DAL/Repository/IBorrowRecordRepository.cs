using LibraryManagementSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.DAL.Repository;

public interface IBorrowRecordRepository
{
    public Task<BorrowRecord> CreateBorrowRecord(BorrowRecord borrowRecord, CancellationToken cancellationToken);
    public Task<Book> UpdateBorrowRecord(BorrowRecord borrowRecord, CancellationToken cancellationToken);
    public Task<bool> DeleteBorrowBook(int bookId, CancellationToken cancellationToken);

    public Task<BorrowRecord> GetBorrowRecordById(int bookId, CancellationToken cancellationToken);
}

public class BorrowRecordRepository : IBorrowRecordRepository
{
    public Task<BorrowRecord> CreateBorrowRecord(BorrowRecord borrowRecord, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteBorrowBook(int bookId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BorrowRecord> GetBorrowRecordById(int bookId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Book> UpdateBorrowRecord(BorrowRecord borrowRecord, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}