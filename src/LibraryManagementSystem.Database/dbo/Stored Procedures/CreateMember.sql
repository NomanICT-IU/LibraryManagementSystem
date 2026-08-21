
CREATE   PROCEDURE [dbo].[CreateMember]
    @MemberCode nvarchar(20),
    @Name nvarchar(50),
    @Phone nvarchar(20),
    @Email nvarchar(50) = null,
    @Address nvarchar(100),
    @Status bit
AS
BEGIN
 SET NOCOUNT ON;
    INSERT INTO [dbo].[Member]
           ([MemberCode]
           ,[Name]
           ,[Phone]
           ,[Email]
           ,[Address]
           ,[Status])
            output inserted.*
     VALUES(@MemberCode,@Name,@Phone,@Email,@Address,@Status)
END;