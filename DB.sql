Create Table Ñompanies 
(
id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
companyName nvarchar(250) NOT NULL,
companyForm nvarchar(20) NOT NULL
)

Create Table Employees
(
id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
surname nvarchar(30) NOT NULL,
name nvarchar(30) NOT NULL,
patronymic nvarchar(30) NOT NULL,
employmentDate Date NOT NULL,
position nvarchar(15) NOT NULL,
companyId int NOT NULL,
CONSTRAINT FK_TempSales_SalesReason FOREIGN KEY (companyId) REFERENCES Ñompanies (id) ON DELETE CASCADE
)

Select *, companyForm, companyName From Employees join Ñompanies on Ñompanies.id = Employees.companyId;
