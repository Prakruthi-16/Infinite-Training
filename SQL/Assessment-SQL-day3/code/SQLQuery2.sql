-- Step 1: Create the database
CREATE DATABASE Course;


-- Step 2: Use the database
USE Course;


-- Step 3: Create the Coursedetails table
CREATE TABLE Coursedetails (
  C_id VARCHAR(255) PRIMARY KEY,
  C_Name VARCHAR(255),
  Start_date DATE,
  End_date DATE,
  Fee INT
);


-- Step 4: Insert sample data into Coursedetails
INSERT INTO Coursedetails (C_id, C_Name, Start_date, End_date, Fee) VALUES
('DN003', 'Dot Net', '2018-02-01', '2018-02-28', 15000),
('DV004', 'Data Visualization', '2018-03-01', '2018-04-15', 15000),
('JA002', 'AdvancedJava', '2018-01-02', '2018-01-20', 10000),
('JC001', 'CoreJava', '2018-01-02', '2018-01-12', 3000);


-- Step 5: Create the CalculateCourseDuration function
CREATE FUNCTION CalculateCourseDuration (
    @StartDate DATE,
    @EndDate DATE
)
RETURNS INT
AS
BEGIN
    DECLARE @Duration INT;
    SET @Duration = DATEDIFF(DAY, @StartDate, @EndDate);
    RETURN @Duration;
END;


-- Step 6: Query to display course details with duration
SELECT
    C_id,
    C_Name,
    Start_date,
    End_date,
    Fee,
    dbo.CalculateCourseDuration(Start_date, end_date) AS course_duration_in_days
FROM Coursedetails;


-- Step 7: Create the T_CourseInfo table
CREATE TABLE T_CourseInfo (
  Course_Name VARCHAR(255),
  Start_Date DATE
);


-- Step 8: Create the trigger
CREATE TRIGGER tr_CourseInfo
ON Coursedetails
AFTER INSERT
AS
BEGIN
    INSERT INTO T_CourseInfo (Course_Name, Start_Date)
    SELECT C_Name, Start_date
    FROM inserted;
END;


-- Step 9: Insert a new course to test the trigger
INSERT INTO Coursedetails (C_id, C_Name, Start_date, End_date, Fee) VALUES
('PY001', 'Python', '2023-04-01', '2023-05-01', 12000);


-- Step 10: Check the T_CourseInfo table to see if the trigger worked
SELECT * FROM T_CourseInfo;
