
CREATE   PROCEDURE [dbo].[UpdateBookCopy]
    @CopyId int,
    @CopyCode nvarchar(20),
    @BookId int,
    @Status int
AS
BEGIN

UPDATE [dbo].[BookCopy]
   SET 
      [CopyCode] = @CopyCode,
      [BookId] = @BookId,
      [Status] = @Status
 WHERE CopyId =  @CopyId
END