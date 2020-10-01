USE CentricaTest
DECLARE @addressID UNIQUEIDENTIFIER
DECLARE @districtID UNIQUEIDENTIFIER 
SET @districtID = '7F948F8A-8B22-487C-90DB-24C73CBA9615'
DECLARE @salesmanID UNIQUEIDENTIFIER 
--SET @salesmanID = '24488F2A-7CFB-49F1-BD40-BA8AC363D6A4'
SET @salesmanID = '5633596D-62D4-45AC-AD0A-C78979CFBD0D'

EXEC AddSalesManToDistrict @salesmanID, @districtID, @isPrimary = 1;

INSERT INTO [Address] VALUES(
	NEWID(),
	null,
	'Denmark',
	'Aalborg',
	'Gøggade',
	'2a',
	null
);

SELECT * FROM [Address]

INSERT INTO Salesman VALUES(
	NEWID(),
	'12345678',
	'Boh',
	null,
	null,
	'Boh@Boh.com',
	GETUTCDATE(),
	'EBEB7492-46DF-41F0-8D32-4C5A5296A9DE'
);
SELECT * FROM Salesman

INSERT INTO District VALUES(
	NEWID(),
	'123',
	'SUPERBOH'
);

SELECT * FROM District

SELECT * FROM SalesmanDistrict