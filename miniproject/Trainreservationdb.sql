--drop database TrainReservationDB

--GO
--CREATE USER [INFICS\vilvapriyam] FOR LOGIN [INFICS\vilvapriyam];
--ALTER ROLE db_owner ADD MEMBER [INFICS\vilvapriyam];


CREATE DATABASE TrainReservationDB;
GO

USE TrainReservationDB;
GO

-- USERS TABLE
CREATE TABLE Users
(
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(50) NOT NULL,
    RoleName VARCHAR(20) NOT NULL
);

----------------------------------------------------------

-- TRAINS TABLE
CREATE TABLE Trains
(
    TrainNo INT PRIMARY KEY,
    TrainName VARCHAR(100),
    FromStation VARCHAR(100),
    ToStation VARCHAR(100),

    -- 2AC
    Total2ACSeats INT,
    Available2ACSeats INT,
    Charge2AC DECIMAL(10,2),

    -- 3AC
    Total3ACSeats INT,
    Available3ACSeats INT,
    Charge3AC DECIMAL(10,2),

    -- Sleeper
    TotalSleeperSeats INT,
    AvailableSleeperSeats INT,
    ChargeSleeper DECIMAL(10,2),

    IsDeleted BIT DEFAULT 0
);

----------------------------------------------------------

-- BOOKINGS TABLE
CREATE TABLE Bookings
(
    BookingId INT PRIMARY KEY IDENTITY(1,1),
    BookDate DATETIME DEFAULT GETDATE(),
    TravelDate DATE,
    UserId INT,
    TrainNo INT,
    TravelClass VARCHAR(20),
    PassengerCount INT,
    Amount DECIMAL(10,2),
    BookingStatus VARCHAR(20) DEFAULT 'Active',

    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (TrainNo) REFERENCES Trains(TrainNo)
);

----------------------------------------------------------

-- PASSENGERS TABLE
CREATE TABLE Passengers
(
    PassengerId INT PRIMARY KEY IDENTITY(1,1),
    BookingId INT,
    PassengerName VARCHAR(100),
    Age INT,
    Gender VARCHAR(10),
    IdProofType VARCHAR(30),
    IdProofNumber VARCHAR(50),
    Occupation VARCHAR(50),
    PhoneNumber VARCHAR(15),

    FOREIGN KEY (BookingId) REFERENCES Bookings(BookingId)
);

----------------------------------------------------------

-- CANCELLATIONS TABLE
CREATE TABLE Cancellations
(
    CancellationId INT PRIMARY KEY IDENTITY(1,1),
    BookingId INT,
    CancellationDate DATETIME DEFAULT GETDATE(),
    RefundAmount DECIMAL(10,2),

    FOREIGN KEY (BookingId) REFERENCES Bookings(BookingId)
);

----------------------------------------------------------

-- DEFAULT ADMIN
INSERT INTO Users (Username, Password, RoleName)
VALUES ('admin', 'admin123', 'Admin');

ALTER TABLE Trains
ADD
DepartureTime TIME,
ArrivalTime TIME,
JourneyDuration VARCHAR(50);

CREATE TABLE TrainStops
(
    StopId INT PRIMARY KEY IDENTITY(1,1),

    TrainNo INT,

    StationName VARCHAR(100),

    ArrivalTime TIME,

    DepartureTime TIME,

    StopOrder INT,

    FOREIGN KEY(TrainNo)
    REFERENCES Trains(TrainNo)
);


ALTER TABLE Passengers
ADD SeatNumber VARCHAR(20);

ALTER TABLE Bookings
ADD BookingType VARCHAR(20) DEFAULT 'Confirmed';






INSERT INTO Trains
(
    TrainNo,
    TrainName,
    FromStation,
    ToStation,

    DepartureTime,
    ArrivalTime,
    JourneyDuration,

    Total2ACSeats,
    Available2ACSeats,
    Charge2AC,

    Total3ACSeats,
    Available3ACSeats,
    Charge3AC,

    TotalSleeperSeats,
    AvailableSleeperSeats,
    ChargeSleeper,

    IsDeleted
)
VALUES
(
    12637,
    'Pandian Express',
    'Chennai',
    'Madurai',

    '21:30',
    '05:40',
    '8 Hours 10 Minutes',

    50,
    50,
    1850.00,

    100,
    100,
    1250.00,

    200,
    200,
    550.00,

    0
);

INSERT INTO TrainStops
(
    TrainNo,
    StationName,
    ArrivalTime,
    DepartureTime,
    StopOrder
)
VALUES
(12637,'Chennai','21:00','21:30',1),

(12637,'Tambaram','21:55','22:00',2),

(12637,'Villupuram','23:30','23:35',3),

(12637,'Trichy','03:00','03:10',4),

(12637,'Dindigul','04:30','04:35',5),

(12637,'Madurai','05:40','05:40',6);



--2
INSERT INTO Trains
(
    TrainNo,
    TrainName,
    FromStation,
    ToStation,
    DepartureTime,
    ArrivalTime,
    JourneyDuration,
    Total2ACSeats,
    Available2ACSeats,
    Charge2AC,
    Total3ACSeats,
    Available3ACSeats,
    Charge3AC,
    TotalSleeperSeats,
    AvailableSleeperSeats,
    ChargeSleeper,
    IsDeleted
)
VALUES
(
    12627,
    'Karnataka Express',
    'Bangalore',
    'New Delhi',
    '19:20',
    '11:40',
    '40 Hours 20 Minutes',
    60,
    60,
    2100.00,
    120,
    120,
    1500.00,
    300,
    300,
    750.00,
    0
);


INSERT INTO TrainStops (TrainNo, StationName, ArrivalTime, DepartureTime, StopOrder) VALUES
(12627,'Bangalore','18:50','19:20',1),
(12627,'Anantapur','22:30','22:35',2),
(12627,'Guntakal','00:15','00:25',3),
(12627,'Nagpur','10:00','10:10',4),
(12627,'Jhansi','05:30','05:40',5),
(12627,'New Delhi','11:40','11:40',6);


--3

INSERT INTO Trains
(
    TrainNo, TrainName, FromStation, ToStation,
    DepartureTime, ArrivalTime, JourneyDuration,
    Total2ACSeats, Available2ACSeats, Charge2AC,
    Total3ACSeats, Available3ACSeats, Charge3AC,
    TotalSleeperSeats, AvailableSleeperSeats, ChargeSleeper,
    IsDeleted
)
VALUES
(
    12760, 'Charminar Express', 'Hyderabad', 'Chennai',
    '17:00', '06:30', '13 Hours 30 Minutes',
    50, 50, 1700.00,
    100, 100, 1100.00,
    250, 250, 600.00,
    0
);

INSERT INTO TrainStops VALUES
(12760,'Hyderabad','16:30','17:00',1),
(12760,'Nalgonda','19:00','19:05',2),
(12760,'Guntur','22:30','22:40',3),
(12760,'Nellore','03:30','03:35',4),
(12760,'Chennai','06:30','06:30',5);

--5
INSERT INTO Trains
(
    TrainNo, TrainName, FromStation, ToStation,
    DepartureTime, ArrivalTime, JourneyDuration,
    Total2ACSeats, Available2ACSeats, Charge2AC,
    Total3ACSeats, Available3ACSeats, Charge3AC,
    TotalSleeperSeats, AvailableSleeperSeats, ChargeSleeper,
    IsDeleted
)
VALUES
(
    11, 'madurai Express', 'Madurai', 'Chennai',
    '11:00', '18:35', '8 Hours 35 Minutes',
    55, 55, 2000.00,
    110, 110, 1400.00,
    280, 280, 700.00,
    0
);
INSERT INTO TrainStops
(
    TrainNo,
    StationName,
    ArrivalTime,
    DepartureTime,
    StopOrder
)
VALUES
(11, 'Madurai',   '10:30', '11:00', 1),
(11, 'Dindigul',  '11:40', '11:45', 2),
(11, 'Trichy',    '13:00', '13:10', 3),
(11, 'Villupuram','16:00', '16:05', 4),
(11, 'Tambaram',  '18:05', '18:10', 5),
(11, 'Chennai',   '18:35', '18:35', 6);


----





