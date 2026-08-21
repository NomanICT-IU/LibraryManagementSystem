CREATE   PROCEDURE [dbo].[SelectBook]
    @BookId INT,
    @ReturnBookId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SET @ReturnBookId = @BookId;

    SELECT 
        b.Title,
        b.Author,
        b.ISBN,
        bc.CopyCode AS [Copy Id],
        CASE bc.Status
            WHEN 1 THEN 'Available'
            WHEN 2 THEN 'Borrowed'
            ELSE 'Unknown'
        END AS Status
    FROM Book AS b
    JOIN BookCopy AS bc
        ON b.BookId = bc.BookId
    WHERE b.BookId = @BookId;
END;