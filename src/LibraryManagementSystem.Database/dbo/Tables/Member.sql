CREATE TABLE [dbo].[Member] (
    [MemberId]   INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50)  NOT NULL,
    [MemberCode] NVARCHAR (20)  NOT NULL,
    [Phone]      NVARCHAR (20)  NOT NULL,
    [Email]      NVARCHAR (50)  NULL,
    [Address]    NVARCHAR (100) NOT NULL,
    [Status]     BIT            NOT NULL,
    CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED ([MemberId] ASC),
    CONSTRAINT [CK_Member_MemberCode] CHECK ([MemberCode] like 'M-[0-9][0-9]'),
    CONSTRAINT [UQ_Member_Email] UNIQUE NONCLUSTERED ([Email] ASC),
    CONSTRAINT [UQ_Member_MemberCode] UNIQUE NONCLUSTERED ([MemberCode] ASC),
    CONSTRAINT [UQ_Member_Phone] UNIQUE NONCLUSTERED ([Phone] ASC)
);

