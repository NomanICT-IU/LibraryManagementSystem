CREATE   PROCEDURE [dbo].[GetMemberById]
    @MemberId int
AS
BEGIN
select MemberCode,Name,Phone,Email,Address,Status from Member
where MemberId = @MemberId 
END