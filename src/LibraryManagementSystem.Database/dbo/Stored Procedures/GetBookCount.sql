CREATE PROCEDURE [dbo].[GetBookCount]
    @Count INT OUTPUT
AS
BEGIN
    SELECT @Count = COUNT(*) FROM Book;
END;