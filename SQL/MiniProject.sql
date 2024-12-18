-- Create the database if not already created
CREATE DATABASE RailwayReservationSystem;

USE RailwayReservationSystem;

-- Table to store train information
CREATE TABLE Trains (
    TrainID INT PRIMARY KEY IDENTITY,
    TrainName VARCHAR(100),
    Source VARCHAR(100),
    Destination VARCHAR(100),
    DepartureTime DATETIME,
    ArrivalTime DATETIME,
    AvailableSeats INT
);

-- Table to store passenger information
CREATE TABLE Passengers (
    PassengerID INT PRIMARY KEY IDENTITY,
    Name VARCHAR(100),
    Age INT,
    Gender VARCHAR(10)
);

-- Table to store user bookings
CREATE TABLE Bookings (
    BookingID INT PRIMARY KEY IDENTITY,
    TrainID INT,
    UserName VARCHAR(100),
    SeatCount INT,
    BookingDate DATETIME,
    Status VARCHAR(50) DEFAULT 'Booked',
    FOREIGN KEY (TrainID) REFERENCES Trains(TrainID)
);

-- Table to store passenger bookings (many-to-many relationship between Passengers and Bookings)
CREATE TABLE PassengerBookings (
    PassengerID INT,
    BookingID INT,
    PRIMARY KEY (PassengerID, BookingID),
    FOREIGN KEY (PassengerID) REFERENCES Passengers(PassengerID),
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID)
);

-- Table to store cancellation details
CREATE TABLE Cancellations (
    CancellationID INT PRIMARY KEY IDENTITY,
    BookingID INT,
    CancellationDate DATETIME,
    Reason VARCHAR(255) NULL,
    FOREIGN KEY (BookingID) REFERENCES Bookings(BookingID)
);

-- Insert some dummy data for trains
INSERT INTO Trains (TrainName, Source, Destination, DepartureTime, ArrivalTime, AvailableSeats)
VALUES
('Express Train 1', 'bangalore', 'mumbai', '2024-12-15 10:00:00', '2024-12-15 20:00:00', 100),
('Express Train 2', 'chennai', 'Andra Pradesh', '2024-12-16 08:00:00', '2024-12-16 18:00:00', 150);

-- Insert sample passengers into the Passengers table
INSERT INTO Passengers (Name, Age, Gender)
VALUES
('Prakruthi', 22, 'FeMale'),
('Sahana', 28, 'Female'),
('Shwetha', 40, 'Female'),
('Pavan', 30, 'Male'),
('Manjula', 25, 'Female'),
('Manjunatha', 50, 'Male'),
('vidya', 33, 'Female'),
('Vinod', 45, 'Male');

-- Insert sample bookings into the Bookings table
INSERT INTO Bookings (TrainID, UserName, SeatCount, BookingDate, Status)
VALUES
(1, 'Prakruthi', 2, '2024-12-15 09:30:00', 'Booked'),
(2, 'Sahana', 3, '2024-12-16 07:45:00', 'Booked'),
(1, 'Shwetha', 1, '2024-12-17 08:00:00', 'Booked'),
(2, 'Pavan', 4, '2024-12-18 13:00:00', 'Booked'),
(1, 'Manjula', 1, '2024-12-19 06:00:00', 'Booked');

-- Insert sample passenger bookings into the PassengerBookings table
INSERT INTO PassengerBookings (PassengerID, BookingID)
VALUES
(1, 1), -- John Doe (Passenger 1) is in Booking 1
(2, 1), -- Jane Smith (Passenger 2) is in Booking 1
(3, 2), -- Mary Johnson (Passenger 3) is in Booking 2
(4, 2), -- James Brown (Passenger 4) is in Booking 2
(5, 2), -- Emily Davis (Passenger 5) is in Booking 2
(6, 3), -- Michael Wilson (Passenger 6) is in Booking 3
(7, 4), -- Sarah Moore (Passenger 7) is in Booking 4
(8, 4), -- David Taylor (Passenger 8) is in Booking 4
(1, 4), -- John Doe (Passenger 1) is in Booking 4
(2, 4), -- Jane Smith (Passenger 2) is in Booking 4
(3, 5); -- Mary Johnson (Passenger 3) is in Booking 5

-- Insert sample cancellations
INSERT INTO Cancellations (BookingID, CancellationDate, Reason)
VALUES
(1, '2024-12-15 10:00:00', 'Personal Reason'), -- Booking 1 canceled by JohnDoe
(2, '2024-12-16 09:00:00', 'Changed Travel Plans'); -- Booking 2 canceled by JaneSmith
