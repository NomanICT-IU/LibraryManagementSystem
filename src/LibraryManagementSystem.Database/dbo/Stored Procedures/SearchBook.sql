CREATE   PROCEDURE [dbo].[SearchBook]
    @SearchBy   NVARCHAR(50) = NULL,
    @SearchText NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Clean search text
    SET @SearchText = NULLIF(TRIM(@SearchText), '');

    -- Validate SearchBy
    IF @SearchBy IS NOT NULL
       AND @SearchBy NOT IN ('Title', 'Author', 'ISBN')
    BEGIN
        RAISERROR(
            'Invalid SearchBy value. Use Title, Author, or ISBN.',
            16,
            1
        );

        RETURN;
    END;

    SELECT
        b.BookId,
        b.Title,
        b.Author,
        b.ISBN,
        bc.CopyCode,

        CASE bc.Status
            WHEN 1 THEN 'Available'
            WHEN 2 THEN 'Borrowed'
            ELSE 'Unknown'
        END AS Status,

        m.Name AS BorrowedBy,
        br.DueDate

    FROM dbo.Book AS b

    LEFT JOIN dbo.BookCopy AS bc
        ON b.BookId = bc.BookId

    LEFT JOIN dbo.BorrowRecord AS br
        ON bc.CopyId = br.CopyId

    LEFT JOIN dbo.Member AS m
        ON br.MemberId = m.MemberId

    WHERE
        @SearchText IS NULL

        OR (
            @SearchBy = 'Title'
            AND b.Title LIKE '%' + @SearchText + '%'
        )

        OR (
            @SearchBy = 'Author'
            AND b.Author LIKE '%' + @SearchText + '%'
        )

        OR (
            @SearchBy = 'ISBN'
            AND b.ISBN LIKE '%' + @SearchText + '%'
        );
END;