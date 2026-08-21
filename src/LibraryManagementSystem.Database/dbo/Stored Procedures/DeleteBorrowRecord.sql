CREATE   PROCEDURE [dbo].[DeleteBorrowRecord]
   @BorrowId int
AS
BEGIN
DELETE FROM [dbo].[BorrowRecord]
      WHERE BorrowId =  @BorrowId
END