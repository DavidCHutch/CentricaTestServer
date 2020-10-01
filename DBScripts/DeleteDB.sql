USE CentricaTest

DROP TABLE OrderProduct
DROP TABLE [Order]
DROP TABLE Store
DROP TABLE Product
DROP TABLE SalesmanDistrict
DROP TABLE District
DROP TABLE Salesman
DROP TABLE [Address]



DROP PROCEDURE IF EXISTS dbo.Get_SalesMan_In_District, dbo.Insert_SalesMan_To_District, dbo.Update_SalesMan_In_District;  
GO  