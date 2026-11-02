-- HOUSE RENTAL MANAGEMENT DATABASE
-- Database: Projects1

IF DB_ID('Projects1') IS NULL
    CREATE DATABASE Projects1;
GO

USE Projects1;
GO

-- USERS TABLE
CREATE TABLE Users
(
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    Role VARCHAR(20) NOT NULL
);
GO

-- PROPERTY TABLE
CREATE TABLE example3
(
    PropertyId INT IDENTITY(1,1) PRIMARY KEY,
    HouseTitle VARCHAR(40) NOT NULL,
    HouseAddress VARCHAR(40) NOT NULL,
    City VARCHAR(40) NOT NULL,
    MonthlyRent INT NOT NULL CHECK (MonthlyRent > 0),
    DepositAmount INT NOT NULL CHECK (DepositAmount >= 0),
    Bedrooms INT NOT NULL CHECK (Bedrooms BETWEEN 1 AND 20),
    Bathrooms INT NOT NULL CHECK (Bathrooms BETWEEN 1 AND 20),
    PropertyType VARCHAR(40) NOT NULL,
    IsAvailable BIT NOT NULL DEFAULT 1,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedDate DATETIME NULL,
    PropertyOwner VARCHAR(40) NOT NULL,
    OwnerContact VARCHAR(40) NOT NULL
);
GO

-- STORED PROCEDURE
CREATE OR ALTER PROCEDURE ex_procedure1
(
    @Action VARCHAR(10),
    @property_id INT = NULL,
    @house_title VARCHAR(40) = NULL,
    @house_address VARCHAR(40) = NULL,
    @city VARCHAR(40) = NULL,
    @monthly_rent INT = NULL,
    @deposit_amount INT = NULL,
    @bedrooms INT = NULL,
    @bathrooms INT = NULL,
    @property_type VARCHAR(40) = NULL,
    @is_available BIT = NULL,
    @property_owner VARCHAR(40) = NULL,
    @owner_contact VARCHAR(40) = NULL
)
AS
BEGIN
    SET NOCOUNT ON;

    -- INSERT
    IF @Action = 'INSERT'
    BEGIN
        INSERT INTO example3
        (
            HouseTitle, HouseAddress, City,
            MonthlyRent, DepositAmount, Bedrooms,
            Bathrooms, PropertyType, IsAvailable,
            PropertyOwner, OwnerContact
        )
        VALUES
        (
            @house_title, @house_address, @city,
            @monthly_rent, @deposit_amount, @bedrooms,
            @bathrooms, @property_type, @is_available,
            @property_owner, @owner_contact
        );
    END

    -- UPDATE
    ELSE IF @Action = 'UPDATE'
    BEGIN
        UPDATE example3
        SET
            HouseTitle = @house_title,
            HouseAddress = @house_address,
            City = @city,
            MonthlyRent = @monthly_rent,
            DepositAmount = @deposit_amount,
            Bedrooms = @bedrooms,
            Bathrooms = @bathrooms,
            PropertyType = @property_type,
            IsAvailable = @is_available,
            PropertyOwner = @property_owner,
            OwnerContact = @owner_contact,
            UpdatedDate = GETDATE()
        WHERE PropertyId = @property_id;

        SELECT @@ROWCOUNT AS result;
    END

    -- DELETE
    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM example3
        WHERE PropertyId = @property_id;

        SELECT @@ROWCOUNT AS result;
    END

    -- DISPLAY
    ELSE IF @Action = 'DISPLAY'
    BEGIN
        SELECT * FROM example3;
    END

    ELSE
    BEGIN
        PRINT 'Invalid Action. Please enter a valid action.';
    END
END;
GO
