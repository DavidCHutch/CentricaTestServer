CREATE PROCEDURE GetAll_In_District 
	@DistrictID UNIQUEIDENTIFIER
	AS
	SELECT sd.DistrictID, sd.SalesmanID, sd.IsPrimary,  d.[Name] AS DistrictName, d.Number AS DistrictNumber, s.ID AS StoreID, s.[Name] AS StoreName, s.Number AS StoreNumber
	FROM SalesmanDistrict sd
	INNER JOIN District d ON sd.DistrictID = d.ID
	INNER JOIN Store s ON s.DistrictID = d.ID
	INNER JOIN Salesman sm ON sm.ID = sd.SalesmanID
	WHERE sd.DistrictID = @DistrictID
GO

CREATE PROCEDURE GetAll_Stores_In_District 
	@DistrictID UNIQUEIDENTIFIER
	AS
	SELECT s.ID, s.[Name], s.Number, s.AddressID, a.Country, a.City, a.PostalCode, a.Street, a.StreetNumber, a.[Floor]
	FROM Store s
	INNER JOIN [Address] a ON s.AddressID = a.ID
	WHERE DistrictID = @DistrictID
GO

CREATE PROCEDURE GetAll_SalesMan_In_District 
	@DistrictID UNIQUEIDENTIFIER
	AS
	SELECT sd.SalesmanID, sd.IsPrimary, s.FirstName, s.LastName, s.Email, s.BirthDate, s.Salary, s.SSN, s.AddressID, a.Country, a.City, a.PostalCode, a.Street, a.StreetNumber, a.[Floor]
	FROM SalesmanDistrict sd 
	INNER JOIN Salesman s ON sd.SalesmanID = s.ID
	INNER JOIN [Address] a ON s.AddressID = a.ID
	WHERE DistrictID = @DistrictID
GO

CREATE PROCEDURE Add_SalesMan_To_District @SalesmanID UNIQUEIDENTIFIER, @DistrictID UNIQUEIDENTIFIER
	AS
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
GO

CREATE PROCEDURE Swap_PrimarySalesMan_In_District @PromoteSM UNIQUEIDENTIFIER, @DemoteSM UNIQUEIDENTIFIER, @DistrictID UNIQUEIDENTIFIER
	AS
	IF EXISTS (SELECT * FROM SalesmanDistrict AS sd WHERE sd.DistrictID = @DistrictID)
		IF EXISTS(SELECT IsPrimary FROM SalesmanDistrict AS sd WHERE sd.DistrictID = @DistrictID AND sd.SalesmanID = @PromoteSM AND IsPrimary = 1)
			BEGIN;
			THROW 51000, 'Can not promote a salesman in the same district if it is already primary', 1
			END;
		ELSE
			IF EXISTS(SELECT IsPrimary FROM SalesmanDistrict AS sd WHERE sd.DistrictID = @DistrictID AND sd.SalesmanID = @DemoteSM AND IsPrimary = 1)
				IF EXISTS(SELECT IsPrimary FROM SalesmanDistrict AS sd WHERE sd.DistrictID = @DistrictID AND sd.SalesmanID = @PromoteSM AND IsPrimary = 0)
					UPDATE SalesmanDistrict
					SET SalesmanDistrict.IsPrimary  = CASE
										WHEN SalesmanDistrict.SalesmanID = @DemoteSM THEN 0 
										WHEN SalesmanDistrict.SalesmanID = @PromoteSM THEN 1 
										ELSE SalesmanDistrict.IsPrimary
										END
					WHERE SalesmanDistrict.SalesmanID IN(@PromoteSM, @DemoteSM)
				ELSE
					BEGIN;
					THROW 51000, 'Could not promote new primary salesman', 1
					END;
			ELSE
				BEGIN;
				THROW 51000, 'Can not demote salesman that is already secondary', 1
				END;
	ELSE
		BEGIN;
		THROW 51000, 'District does not exist', 1
		END;
	GO

CREATE PROCEDURE Remove_Salesman_From_District @SalesmanID UNIQUEIDENTIFIER, @DistrictID UNIQUEIDENTIFIER
AS
	IF EXISTS (SELECT * FROM SalesmanDistrict AS sd WHERE sd.DistrictID = @DistrictID AND sd.SalesmanID = @SalesmanID)
		IF EXISTS (SELECT SalesmanID FROM SalesmanDistrict AS sd WHERE sd.DistrictID = @DistrictID AND sd.SalesmanID = @SalesmanID AND sd.IsPrimary = 0)
			DELETE FROM SalesmanDistrict Where SalesmanID = @SalesmanID
		ELSE
			BEGIN;
				THROW 51000, 'Cannot delete primary before a replacement has been made', 1
			END;
	ELSE
		BEGIN;
		THROW 51000, 'District or salesman does not exist', 1
		END;
GO

