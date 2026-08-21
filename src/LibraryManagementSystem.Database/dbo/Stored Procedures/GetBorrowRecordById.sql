create    PROCEDURE [dbo].[GetBorrowRecordById]
    @BorrowId INT
AS
BEGIN
select [CopyId],[MemberId], [IssueDate],[DueDate],[ReturnDate]  from [dbo].[BorrowRecord]
    WHERE BorrowId = @BorrowId;
END