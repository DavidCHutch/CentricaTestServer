CREATE PROCEDURE Get_Stores_In_District @DistrictID UNIQUEIDENTIFIER
	AS
	SELECT * FROM Store WHERE DistrictID = @DistrictID
GO


CREATE PROCEDURE Get_SalesMan_In_District @DistrictID UNIQUEIDENTIFIER
	AS
	SELECT SalesmanID, IsPrimary FROM SalesmanDistrict WHERE DistrictID = @DistrictID
GO

CREATE PROCEDURE Insert_SalesMan_To_District @SalesmanID UNIQUEIDENTIFIER, @DistrictID UNIQUEIDENTIFIER, @IsPrimary BIT = 0
	AS
	IF(@IsPrimary = 0)
		INSERT INTO SalesmanDistrict VALUES(@SalesmanID, @DistrictID, @IsPrimary)
	ELSE
		IF EXISTS (SELECT * FROM SalesmanDistrict AS sd WHERE sd.DistrictID = @DistrictID AND sd.IsPrimary = 1)
			BEGIN;
			THROW 51000, 'There already exists a primary salesman for this district', 1
			END;
		ELSE
			INSERT INTO SalesmanDistrict VALUES(@SalesmanID, @DistrictID, @IsPrimary)
GO


CREATE PROCEDURE Update_SalesMan_In_District @SalesmanID UNIQUEIDENTIFIER, @DistrictID UNIQUEIDENTIFIER, @IsPrimary BIT = 0
	AS
	IF(@IsPrimary = 0)
		UPDATE SalesmanDistrict SET SalesmanID = @SalesmanID, DistrictID = @DistrictID, IsPrimary = @IsPrimary
	ELSE
		IF EXISTS (SELECT * FROM SalesmanDistrict AS sd WHERE sd.DistrictID = @DistrictID AND sd.IsPrimary = 1)
			BEGIN;
			THROW 51000, 'There already exists a primary salesman for this district', 1
			END;
		ELSE
			UPDATE SalesmanDistrict SET SalesmanID = @SalesmanID, DistrictID = @DistrictID, IsPrimary = @IsPrimary
GO

CREATE PROCEDURE Remove_Salesman_From_District @SalesmanID UNIQUEIDENTIFIER, @DistrictID UNIQUEIDENTIFIER, @IsPrimary BIT = 0
AS
	IF EXISTS(SELECT SalesmanID FROM SalesmanDistrict AS sd WHERE sd.SalesmanID = @SalesmanID AND sd.IsPrimary = 0)
		DELETE FROM SalesmanDistrict Where SalesmanID = @SalesmanID
	ELSE
		BEGIN;
			THROW 51000, 'Cannot delete primary before a replacement has been made', 1
		END;
GO

