
CREATE   PROCEDURE [dbo].[UpdateBook]
    @BookId int,
    @Title NVARCHAR(255),
    @Author NVARCHAR(100),
    @ISBN NVARCHAR(50) = NULL,
    @Category NVARCHAR(50)
AS
BEGIN
 SET NOCOUNT ON;
UPDATE [dbo].[Book]
   SET [Title] =  @Title,
      [Author] = @Author,
      [ISBN] = @ISBN,
      [Category] = @Category
 WHERE BookId =  @BookId

END