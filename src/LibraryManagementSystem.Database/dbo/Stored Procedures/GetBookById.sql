CREATE   PROCEDURE [dbo].[GetBookById]
    @BookId int
AS
BEGIN
select [BookId], [Title],[Author],[ISBN],[Category] from Book 
where BookId = @BookId 
END