namespace LibraryManagementSystem.BLL.Service;

public interface IBorrowRecordService
{
    public Task<BorrowRecordDto> CreateBorrowRecordAsync(BorrowRecordDto borrowRecordDto, CancellationToken cancellationToken);
    public Task<bool> UpdateBorrowRecordAsync(BorrowRecordDto borrowRecordDto, CancellationToken cancellationToken);
    public Task<bool> DeleteBorrowBookAsync(int borrowId, CancellationToken cancellationToken);

    public Task<BorrowRecordDto> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken);
}

public class BorrowRecordService : IBorrowRecordService
{
    private readonly IBorrowRecordRepository _borrowRecordRepository;

    public BorrowRecordService(IBorrowRecordRepository borrowRecordRepository)
    {
        _borrowRecordRepository = borrowRecordRepository;
    }
    public async Task<BorrowRecordDto> CreateBorrowRecordAsync(BorrowRecordDto borrowRecordDto, CancellationToken cancellationToken)
    {
        var borrowRecord = borrowRecordDto.Adapt<BorrowRecord>();

        var createdBorrowRecord =
            await _borrowRecordRepository.CreateBorrowRecordAsync(
                borrowRecord,
                cancellationToken);

        borrowRecordDto.BorrowId = createdBorrowRecord.BorrowId;

        return borrowRecordDto;
    }

    public async Task<bool> DeleteBorrowBookAsync(int borrowId, CancellationToken cancellationToken)
    {
        var IsDeleted = await _borrowRecordRepository.DeleteBorrowBookAsync(borrowId, cancellationToken);
        if (!IsDeleted)
                throw new InvalidOperationException("Borrowed record not deleted.");
        return IsDeleted;
    }

    public Task<BorrowRecordDto> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateBorrowRecordAsync(BorrowRecordDto borrowRecordDto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
