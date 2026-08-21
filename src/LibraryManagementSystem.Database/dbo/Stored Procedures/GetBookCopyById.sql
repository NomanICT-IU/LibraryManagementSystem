CREATE   PROCEDURE [dbo].[GetBookCopyById]
    @CopyId int
AS
BEGIN
select [CopyCode],[BookId],[Status] from [dbo].[BookCopy]
where CopyId = @CopyId 
END