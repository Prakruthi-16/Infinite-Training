
-- Create Database
CREATE DATABASE RailwayReservationSystem7;


USE RailwayReservationSystem7;


-- Create Tables
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50),
    Username NVARCHAR(50) UNIQUE,
    Password NVARCHAR(50)
);

CREATE TABLE Admins (
    AdminId INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) UNIQUE,
    Password NVARCHAR(50)
);

CREATE TABLE Trains (
    TrainNo INT,
    TrainName NVARCHAR(50),
    FromStation NVARCHAR(50),
    Destination NVARCHAR(50),
    Price DECIMAL(10,2),
    ClassOfTravel NVARCHAR(20),
    TrainStatus NVARCHAR(20),
    SeatsAvailable INT,
    PRIMARY KEY (TrainNo, ClassOfTravel)
);

CREATE TABLE Bookings (
    BookingId INT PRIMARY KEY IDENTITY,
    UserId INT,
    TrainNo INT,
    ClassOfTravel NVARCHAR(20),
    SeatsBooked INT,
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (TrainNo, ClassOfTravel) REFERENCES Trains(TrainNo, ClassOfTravel)
);

CREATE TABLE Cancellations (
    CancellationId INT PRIMARY KEY IDENTITY,
    BookingId INT,
    SeatsCancelled INT,
    FOREIGN KEY (BookingId) REFERENCES Bookings(BookingId)
);

----Admin Credentials
INSERT INTO Admins (Username, Password)
VALUES ('admin', 'Admin@123');

--drop table Bookings
--drop table Cancellation

SELECT * FROM Trains
SELECT * FROM Users
SELECT * FROM Admins
SELECT * FROM Bookings
SELECT * FROM Cancellations

