-- YMS Pro - SQL Server Schema
-- Run after EF Core migrations OR use this for manual setup

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'YmsDb')
    CREATE DATABASE YmsDb;
GO

USE YmsDb;
GO

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY,
    FullName NVARCHAR(200) NOT NULL,
    Email NVARCHAR(256) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(500) NOT NULL,
    Role NVARCHAR(50) NOT NULL DEFAULT 'Operations',
    IsActive BIT NOT NULL DEFAULT 1,
    LastLogin DATETIME2,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0
);

CREATE TABLE Clients (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(200) NOT NULL,
    ContactPerson NVARCHAR(200),
    Phone NVARCHAR(20),
    Email NVARCHAR(256),
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0
);

CREATE TABLE Yards (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(200) NOT NULL,
    Address NVARCHAR(500),
    ManagerName NVARCHAR(200),
    ContactNumber NVARCHAR(20),
    City NVARCHAR(100) NOT NULL,
    State NVARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0
);

CREATE TABLE Vehicles (
    Id INT PRIMARY KEY IDENTITY,
    ClientId INT NOT NULL REFERENCES Clients(Id),
    YardId INT NOT NULL REFERENCES Yards(Id),
    LoanNumber NVARCHAR(100) NOT NULL,
    CustomerName NVARCHAR(200),
    BranchName NVARCHAR(200),
    RepoDate DATE,
    RegistrationNumber NVARCHAR(50) NOT NULL,
    ChassisNumber NVARCHAR(100) NOT NULL,
    EngineNumber NVARCHAR(100) NOT NULL,
    Make NVARCHAR(100),
    Model NVARCHAR(100),
    Variant NVARCHAR(100),
    FuelType NVARCHAR(50),
    TransmissionType NVARCHAR(50),
    ManufacturingYear INT,
    VehicleType NVARCHAR(50) NOT NULL,
    Color NVARCHAR(50),
    RunningStatus NVARCHAR(50) NOT NULL DEFAULT 'Running',
    KeyStatus NVARCHAR(50) NOT NULL DEFAULT 'Yes',
    RcStatus NVARCHAR(50) NOT NULL DEFAULT 'Pending',
    BatteryCondition NVARCHAR(50),
    TyreCondition NVARCHAR(50),
    OdometerReading INT,
    InsuranceAvailable BIT NOT NULL DEFAULT 0,
    ParkingCharges DECIMAL(10,2) NOT NULL DEFAULT 0,
    TowingCharges DECIMAL(10,2) NOT NULL DEFAULT 0,
    MiscCharges DECIMAL(10,2) NOT NULL DEFAULT 0,
    EntryDate DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ExitDate DATETIME2,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0
);

CREATE INDEX IX_Vehicles_ClientId ON Vehicles(ClientId);
CREATE INDEX IX_Vehicles_YardId ON Vehicles(YardId);
CREATE INDEX IX_Vehicles_RunningStatus ON Vehicles(RunningStatus);
CREATE INDEX IX_Vehicles_RegistrationNumber ON Vehicles(RegistrationNumber);
CREATE INDEX IX_Vehicles_EntryDate ON Vehicles(EntryDate);

CREATE TABLE Reports (
    Id INT PRIMARY KEY IDENTITY,
    VehicleId INT NOT NULL REFERENCES Vehicles(Id),
    ReportType NVARCHAR(100) NOT NULL,
    FileName NVARCHAR(300) NOT NULL,
    FilePath NVARCHAR(500) NOT NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT 'Pending',
    UploadedBy INT NOT NULL,
    UploadedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2,
    IsDeleted BIT NOT NULL DEFAULT 0
);

CREATE TABLE AuditLogs (
    Id INT PRIMARY KEY IDENTITY,
    UserId INT NOT NULL,
    Action NVARCHAR(200) NOT NULL,
    EntityType NVARCHAR(100) NOT NULL,
    EntityId INT,
    Details NVARCHAR(MAX),
    IpAddress NVARCHAR(50),
    Timestamp DATETIME2 NOT NULL DEFAULT GETUTCDATE()
);

-- Seed admin user (password: Admin@123)
INSERT INTO Users (FullName, Email, PasswordHash, Role)
VALUES ('Admin User', 'admin@yms.com', '$2a$11$hash_replace_with_bcrypt', 'Admin');

INSERT INTO Clients (Name, ContactPerson, Phone, Email) VALUES
    ('HDFC Bank', 'HDFC Manager', '9000000001', 'hdfc@yms.com'),
    ('ICICI Bank', 'ICICI Manager', '9000000002', 'icici@yms.com'),
    ('Axis Bank', 'Axis Manager', '9000000003', 'axis@yms.com'),
    ('SBI', 'SBI Manager', '9000000004', 'sbi@yms.com'),
    ('Kotak Mahindra Bank', 'Kotak Manager', '9000000005', 'kotak@yms.com');

INSERT INTO Yards (Name, Address, ManagerName, ContactNumber, City, State) VALUES
    ('Mumbai Yard', 'Andheri West', 'Ravi Kumar', '9111111111', 'Mumbai', 'Maharashtra'),
    ('Pune Yard', 'Kharadi', 'Suresh Patil', '9222222222', 'Pune', 'Maharashtra'),
    ('Jaipur Yard', 'Malviya Nagar', 'Ramesh Sharma', '9333333333', 'Jaipur', 'Rajasthan'),
    ('Delhi Yard', 'Dwarka', 'Amit Singh', '9444444444', 'Delhi', 'Delhi'),
    ('Chennai Yard', 'T Nagar', 'Velu Murugan', '9555555555', 'Chennai', 'Tamil Nadu');
GO
