CREATE TABLE [dbo].[Doctor] (
    [DoctorID]     INT          IDENTITY (1, 1) NOT NULL,
    [Doctorname]   VARCHAR (50) NOT NULL,
    [Time]         VARCHAR (50) NOT NULL,
    [Illnesses ID] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([DoctorID] ASC)
);

