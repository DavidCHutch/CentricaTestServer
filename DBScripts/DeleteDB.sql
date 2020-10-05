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
	dbo.Remove_Salesman_From_District,
	dbo.GetAll_In_District,
	dbo.GetAll_Stores_In_District, 
	dbo.GetAll_SalesMan_In_District, 
	dbo.Add_SalesMan_To_District, 
	dbo.Update_SalesMan_In_District, 
	dbo.Swap_PrimarySalesMan_In_District,
	dbo.AddSalesManToDistrict;  
GO  