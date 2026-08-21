
CREATE   PROCEDURE [dbo].[CreateBookCopy]
    @CopyCode nvarchar(20),
    @BookId int,
    @Status bit
AS
BEGIN
 SET NOCOUNT ON;
    INSERT INTO [dbo].[BookCopy]
           ([CopyCode]
           ,[BookId]
           ,[Status])
           OUTPUT inserted.*
     VALUES(@CopyCode,@BookId,@Status)
END;