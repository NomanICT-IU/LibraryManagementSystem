CREATE   PROCEDURE [dbo].[UpdateMember]
    @MemberId int,
    @MemberCode nvarchar(20),
    @Name nvarchar(50),
    @Phone nvarchar(20),
    @Email nvarchar(50) = null,
    @Address nvarchar(100),
    @Status bit
AS
BEGIN
 SET NOCOUNT ON;
UPDATE [dbo].[Member]
   SET [MemberCode] =  @MemberCode ,
      [Name] = @Name,
      [Email] = @Email,
      [Address] = @Address,
      [Status] =  @Status
 WHERE MemberId =  @MemberId
END