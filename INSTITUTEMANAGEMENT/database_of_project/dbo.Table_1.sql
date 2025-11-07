CREATE TABLE [dbo].[attendance]
(
	[deptid] TEXT NOT NULL PRIMARY KEY, 
    [stuid] TEXT NOT NULL, 
    [courseid] INT NOT NULL, 
    [sub] INT NOT NULL, 
    [attenpercentage] INT NOT NULL
)
