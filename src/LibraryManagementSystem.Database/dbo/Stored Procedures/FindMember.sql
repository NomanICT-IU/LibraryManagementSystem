CREATE   PROCEDURE [dbo].[FindMember]
    @SearchText NVARCHAR(50)
   
AS
BEGIN


    DECLARE @BorrowedCount INT;
    DECLARE  @MemberId INT ;

    SET @SearchText = NULLIF(TRIM(@SearchText), '');

    SELECT TOP 1
        @MemberId = m.MemberId
    FROM dbo.Member AS m
    WHERE m.MemberCode LIKE '%' + @SearchText + '%'
       OR m.Phone LIKE '%' + @SearchText + '%';

    SELECT
        @BorrowedCount = COUNT(*)
    FROM dbo.BorrowRecord AS br
    WHERE br.MemberId = @MemberId
      AND br.ReturnDate IS NULL;

    
    SELECT
        m.Name,
        m.MemberCode, 
        m.Phone,
        @BorrowedCount AS Borrowed
    FROM dbo.Member AS m
    WHERE m.MemberId = @MemberId;
END;