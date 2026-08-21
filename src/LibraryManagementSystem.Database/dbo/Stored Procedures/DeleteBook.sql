
CREATE   PROCEDURE [dbo].[DeleteBook]
    @BookId int
AS
BEGIN
DELETE FROM [dbo].[Book]
      WHERE BookId =  @BookId
END