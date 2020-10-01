USE CentricaTest

DROP TABLE OrderProduct
DROP TABLE [Order]
DROP TABLE Store
DROP TABLE Product
DROP TABLE SalesmanDistrict
DROP TABLE District
DROP TABLE Salesman
DROP TABLE [Address]



DROP PROCEDURE IF EXISTS 
	Remove_Salesman_From_District, 
	GetAll_Stores_In_District, GetAll_SalesMan_In_District, 
	dbo.Insert_SalesMan_To_District, 
	dbo.Update_SalesMan_In_District, 
	dbo.AddSalesManToDistrict;  
GO  