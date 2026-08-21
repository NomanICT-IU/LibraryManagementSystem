CREATE   PROCEDURE [dbo].[DeleteBookCopy]
    @CopyId int
AS
BEGIN
DELETE FROM [dbo].[BookCopy]
      WHERE CopyId =  @CopyId
END