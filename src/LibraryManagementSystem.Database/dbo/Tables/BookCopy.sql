CREATE TABLE [dbo].[BookCopy] (
    [CopyId]   INT           IDENTITY (1, 1) NOT NULL,
    [CopyCode] NVARCHAR (20) NOT NULL,
    [BookId]   INT           NOT NULL,
    [Status]   INT           NOT NULL,
    CONSTRAINT [PK_BookCopy] PRIMARY KEY CLUSTERED ([CopyId] ASC),
    CONSTRAINT [CK_BookCopy_CopyCode] CHECK ([CopyCode] like 'C-[0-9][0-9]'),
    CONSTRAINT [FK_BookCopy_Book] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Book] ([BookId]),
    CONSTRAINT [UQ_BookCopy_BookId] UNIQUE NONCLUSTERED ([BookId] ASC),
    CONSTRAINT [UQ_BookCopy_CopyCode] UNIQUE NONCLUSTERED ([CopyCode] ASC)
);

