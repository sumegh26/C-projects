CREATE TABLE [dbo].[student] (
    [ROLLNO]  INT        NOT NULL,
    [NAME]     CHAR(100) NULL,
    [DATEOFBIRTH]      NCHAR (100) NULL,
    [COURSEID] INT        NULL,
    PRIMARY KEY CLUSTERED ([ROLLNO] ASC), 
    CONSTRAINT [FK_student_course] FOREIGN KEY ([courseID]) REFERENCES [course]([COURSEID])
);

