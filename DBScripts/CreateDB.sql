--CREATE DATABASE CentricaTest
USE CentricaTest

CREATE TABLE [Address](
	ID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	PostalCode VARCHAR(max),
	Country VARCHAR(max) not null,
	City VARCHAR(max) not null,
	Street VARCHAR(max) not null,
	StreetNumber VARCHAR(max),
	[Floor] VARCHAR(max),
);

CREATE TABLE Salesman(
	ID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	SSN VARCHAR(max) not null,
	FirstName VARCHAR(150) not null,
	LastName VARCHAR(150),
	Salary FLOAT,
	Email VARCHAR(max) not null,
	BirthDate DATETIME not null,
	AddressID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES [Address](ID) not null,
);

CREATE TABLE District(
	ID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	[Number] VARCHAR(max) not null,
	[Name] VARCHAR(max) not null,
);

CREATE TABLE SalesmanDistrict(
	SalesmanID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Salesman(ID) not null,
	DistrictID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES District(ID) not null,
	IsPrimary BIT not null default 0,
	PRIMARY KEY(SalesmanID, DistrictID)
);

CREATE TABLE Product(
	ID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	[Number] VARCHAR(max) not null,
	[Name] VARCHAR(max) not null,
	Stock INT not null default 0,
	[Description] VARCHAR(max),
	[Type] VARCHAR(max),
	Height VARCHAR(max),
	Width VARCHAR(max),
	Depth VARCHAR(max),
	MeassureUnit VARCHAR(max),
	[Weight] VARCHAR(max),
	WeightUnit VARCHAR(max)
);

CREATE TABLE Store(
	ID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	[Number] VARCHAR(max) not null,
	[Name] VARCHAR(max) not null,
	AddressID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES [Address](ID) not null,
	DistrictID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES District(ID) not null,
);

CREATE TABLE [Order](
	ID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	OrderDate DATETIME default GETUTCDATE(),
	StoreID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Store(ID) not null,
	SalesmanID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Salesman(ID) not null,
);

CREATE TABLE OrderProduct(
	ID UNIQUEIDENTIFIER PRIMARY KEY default NEWID(),
	Quantity INT not null,
	DeliveryDate DATETIME,
	ProductID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Product(ID) not null,
	OrderID UNIQUEIDENTIFIER FOREIGN KEY REFERENCES [Order](ID) not null
);




