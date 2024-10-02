CREATE TABLE Number (
   ID INT NOT NULL PRIMARY KEY IDENTITY(1,1), -- New primary key column
    Value INT NOT NULL,
    IsPrime BIT NOT NULL DEFAULT 0
);


CREATE TABLE Number (
   id INTEGER PRIMARY KEY AUTOINCREMENT, -- New primary key column
   "Value" INTEGER NOT NULL,
  "IsPrime" INTEGER NOT NULL DEFAULT 0
);