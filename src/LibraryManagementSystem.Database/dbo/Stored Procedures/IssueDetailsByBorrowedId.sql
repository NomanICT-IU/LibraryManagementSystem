CREATE   PROCEDURE [dbo].[IssueDetailsByBorrowedId]
    @BorrowId INT
AS
BEGIN

    SELECT 
        b.Title,
        bc.CopyCode,
        m.Name,
        br.DueDate,
        CASE bc.Status
            WHEN 1 THEN 'Available'
            WHEN 2 THEN 'Borrowed'
            ELSE 'Unknown'
        END AS Status 
    FROM BorrowRecord AS br
    JOIN BookCopy AS bc
        ON br.CopyId = bc.CopyId
    JOIN Book AS b
        ON bc.BookId = b.BookId
    JOIN Member AS m
        ON br.MemberId = m.MemberId
    WHERE br.BorrowId = @BorrowId;
END;