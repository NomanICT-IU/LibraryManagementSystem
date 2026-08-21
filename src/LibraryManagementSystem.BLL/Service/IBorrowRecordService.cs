namespace LibraryManagementSystem.BLL.Service;

public interface IBorrowRecordService
{
    public Task<BorrowRecordDto> CreateBorrowRecordAsync(BorrowRecordDto borrowRecordDto, CancellationToken cancellationToken);
    public Task<bool> UpdateBorrowRecordAsync(BorrowRecordDto borrowRecordDto, CancellationToken cancellationToken);
    public Task<bool> DeleteBorrowBookAsync(int borrowId, CancellationToken cancellationToken);

    public Task<BorrowRecordDto> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken);

    public Task<BorrowDetailsDto> IssueDetailsByBorrowedId(int borrowId, CancellationToken cancellationToken);
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

    public async Task<BorrowRecordDto> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken)
    {
        var borrowRecord = await _borrowRecordRepository.GetBorrowRecordByIdAsync(borrowId, cancellationToken);

        var borrowRecordDto = borrowRecord.Adapt<BorrowRecordDto>();
        borrowRecordDto.BorrowId = borrowId;

        return borrowRecordDto;
    }

    public async Task<BorrowDetailsDto> IssueDetailsByBorrowedId(int borrowId, CancellationToken cancellationToken)
    {
        var borrowDetails = await _borrowRecordRepository.IssueDetailsByBorrowedId(borrowId, cancellationToken);

        var borrowDetailsDto = borrowDetails.Adapt<BorrowDetailsDto>();

        return borrowDetailsDto;
    }

    public async Task<bool> UpdateBorrowRecordAsync(BorrowRecordDto borrowRecordDto, CancellationToken cancellationToken)
    {
        var borrowRecord = borrowRecordDto.Adapt<BorrowRecord>();

        var isUpdated = await _borrowRecordRepository.UpdateBorrowRecordAsync(borrowRecord, cancellationToken);

        if (!isUpdated)
            throw new InvalidOperationException("Borrowed record not Updated.");
        return isUpdated;
    }
}
