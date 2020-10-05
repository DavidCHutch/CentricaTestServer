Use CentricaTest
SELECT * FROM District

DECLARE @DistrictID UNIQUEIDENTIFIER
SET @DistrictID = '5dcd2c5a-d895-4780-a76a-d777bedd65e9'

EXEC GetAll_SalesMan_In_District @DistrictID


DECLARE @DistrictID UNIQUEIDENTIFIER
SET @DistrictID = '5dcd2c5a-d895-4780-a76a-d777bedd65e9'
EXEC GetAll_Stores_In_District  @DistrictID

--DECLARE @DemoteSM UNIQUEIDENTIFIER
--SET @DemoteSM = '3E2EF63B-FED3-4BE7-9FE6-E4F692DD244F'
--DECLARE @PromoteSM UNIQUEIDENTIFIER
--SET @PromoteSM = 'DD82B17C-E5EB-4A87-BDAB-FC9CD5C56346'
-- DECLARE OUTSIDE DISTRICT = D73A874C-FEA9-472F-9C17-9ACD73F04769
DECLARE @DistrictID UNIQUEIDENTIFIER
SET @DistrictID = '5dcd2c5a-d895-4780-a76a-d777bedd65e9'
DECLARE @PromoteSM UNIQUEIDENTIFIER
SET @PromoteSM = '3E2EF63B-FED3-4BE7-9FE6-E4F692DD244F'
DECLARE @DemoteSM UNIQUEIDENTIFIER
SET @DemoteSM = 'DD82B17C-E5EB-4A87-BDAB-FC9CD5C56346'

EXEC Swap_PrimarySalesMan_In_District @PromoteSM, @DemoteSM, @DistrictID

SELECT * FROM SalesmanDistrict WHERE SalesmanDistrict.DistrictID = '5dcd2c5a-d895-4780-a76a-d777bedd65e9'


DECLARE @DistrictID UNIQUEIDENTIFIER
SET @DistrictID = '5dcd2c5a-d895-4780-a76a-d777bedd65e9'
--DECLARE @SalesmanID UNIQUEIDENTIFIER
--SET @SalesmanID = 'CE5AF844-53D9-4EE8-A1E8-CFD77A4D8467'
DECLARE @SalesmanID UNIQUEIDENTIFIER
SET @SalesmanID = 'DD82B17C-E5EB-4A87-BDAB-FC9CD5C56346'

	IF EXISTS(SELECT * FROM SalesmanDistrict sd WHERE sd.DistrictID = @DistrictID)
		IF EXISTS(SELECT * FROM SalesmanDistrict sd WHERE sd.DistrictID = @DistrictID AND sd.SalesmanID = @SalesmanID)
			BEGIN;
			THROW 51000, 'The salesman already belongs to this district', 1
			END;
		ELSE
			INSERT INTO SalesmanDistrict VALUES(@SalesmanID, @DistrictID, 0)
	ELSE
		BEGIN;
		THROW 51000, 'District does not exist', 1
		END;

	--IF EXISTS (SELECT * FROM SalesmanDistrict AS sd WHERE sd.DistrictID = @DistrictID AND sd.SalesmanID = @SalesmanID)
	--	IF EXISTS (SELECT SalesmanID FROM SalesmanDistrict AS sd WHERE sd.DistrictID = @DistrictID AND sd.SalesmanID = @SalesmanID AND sd.IsPrimary = 0)
	--		DELETE FROM SalesmanDistrict Where SalesmanID = @SalesmanID
	--	ELSE
	--		BEGIN;
	--			THROW 51000, 'Cannot delete primary before a replacement has been made', 1
	--		END;
	--ELSE
	--	BEGIN;
	--	THROW 51000, 'District or salesman does not exist', 1
	--	END;

DECLARE @DistrictID UNIQUEIDENTIFIER
SET @DistrictID = '5dcd2c5a-d895-4780-a76a-d777bedd65e9'
SELECT sd.DistrictID, sd.SalesmanID, s.ID AS StoreID, sd.IsPrimary,  d.[Name] AS DistrictName, d.Number AS DistrictNumber, s.[Name] AS StoreName, s.Number AS StoreNumber
	FROM SalesmanDistrict sd
	INNER JOIN District d ON sd.DistrictID = d.ID
	INNER JOIN Store s ON s.DistrictID = d.ID
	INNER JOIN Salesman sm ON sm.ID = sd.SalesmanID
	WHERE sd.DistrictID = @DistrictID