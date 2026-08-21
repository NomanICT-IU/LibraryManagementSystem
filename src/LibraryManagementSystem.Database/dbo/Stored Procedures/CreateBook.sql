
CREATE   PROCEDURE [dbo].[CreateBook]
    @Title NVARCHAR(255),
    @Author NVARCHAR(100),
    @ISBN NVARCHAR(50) = NULL,
    @Category NVARCHAR(50)
AS
BEGIN
 SET NOCOUNT ON;
    INSERT INTO [dbo].[Book]
        ([Title],
         [Author],
         [ISBN],
         [Category])
         output inserted.*
    VALUES
        (@Title, @Author, @ISBN, @Category);
END;