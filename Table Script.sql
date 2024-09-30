CREATE TABLE Number (
   ID INT NOT NULL PRIMARY KEY IDENTITY(1,1), -- New primary key column
    Value INT NOT NULL,
    IsPrime BIT NOT NULL DEFAULT 0
);