CREATE   PROCEDURE [dbo].[DeleteMember]
    @MemberId int
AS
BEGIN
DELETE FROM [dbo].[Member]
      WHERE MemberId =  @MemberId
END