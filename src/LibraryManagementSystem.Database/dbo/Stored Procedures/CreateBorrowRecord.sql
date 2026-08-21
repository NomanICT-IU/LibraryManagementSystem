CREATE   PROCEDURE [dbo].[CreateBorrowRecord]
    @CopyId INT,
    @MemberId INT,
    @IssueDate DATETIME,
    @DueDate DATETIME,
    @ReturnDate DATETIME = NULL
AS
BEGIN
BEGIN TRANSACTION;
    UPDATE BookCopy
    SET Status = 2
    WHERE CopyId = @CopyId;
COMMIT TRANSACTION;

    INSERT INTO [dbo].[BorrowRecord]
    (
        CopyId,
        MemberId,
        IssueDate,
        DueDate,
        ReturnDate
    )
    OUTPUT INSERTED.*
    VALUES
    (
        @CopyId,
        @MemberId,
        @IssueDate,
        @DueDate,
        @ReturnDate
    );

END