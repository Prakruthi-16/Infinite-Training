create database prakruthi
use prakruthi



CREATE TABLE Trains (
    TrainNo INT PRIMARY KEY,
    TrainName VARCHAR(100),
    Class VARCHAR(50),
    TotalBerths INT,
    AvailableBerths INT,
    Source VARCHAR(50),
    Destination VARCHAR(50),
    IsActive BIT
);

CREATE TABLE Bookings (
    BookingID INT IDENTITY(1,1) PRIMARY KEY,
    TrainNo INT,
    UserName VARCHAR(100),
    SeatsBooked INT,
    BookingDate DATETIME,
    FOREIGN KEY (TrainNo) REFERENCES Trains(TrainNo)
);

