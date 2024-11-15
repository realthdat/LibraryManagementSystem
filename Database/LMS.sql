-- Tạo database LibraryManagement
CREATE DATABASE LibraryManagement;
GO

DROP DATABASE LibraryManagement;

-- Chuyển vào database LibraryManagement
USE LibraryManagement;
GO


-- Tạo bảng Book
CREATE TABLE Book (
    BookID INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255) NOT NULL,
    Author NVARCHAR(255) NOT NULL,
    PublicationYear INT,
    Genre NVARCHAR(100),
    ISBN NVARCHAR(13) UNIQUE,
    Status NVARCHAR(20) DEFAULT 'available',
    Location NVARCHAR(50),
	Totalcopies INT,
	Price DECIMAL(10, 2)
);


-- Tạo bảng User
CREATE TABLE [User] (
    UserID INT PRIMARY KEY IDENTITY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) DEFAULT 'reader', -- Vai trò (thư viện viên hoặc độc giả)
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PhoneNo NVARCHAR(15), -- Số điện thoại
    Address NVARCHAR(255), -- Địa chỉ
    Status NVARCHAR(20) DEFAULT 'active', -- Trạng thái (active, inactive, etc.)
);

-- Tạo bảng Loan
CREATE TABLE Loan (
    LoanID INT PRIMARY KEY IDENTITY,
    UserID INT FOREIGN KEY REFERENCES [User](UserID),
    BookID INT FOREIGN KEY REFERENCES Book(BookID),
    LoanDate DATE NOT NULL,
    ReturnDate DATE NOT NULL,
    ActualReturnDate DATE,
    Fine DECIMAL(10, 2) DEFAULT 0,
	Status NVARCHAR(20) DEFAULT 'pending',
	RefCode NVARCHAR(20) UNIQUE
);

-- Tạo bảng Reservation
CREATE TABLE Reservation (
    ReservationID INT PRIMARY KEY IDENTITY,
    UserID INT FOREIGN KEY REFERENCES [User](UserID),
    BookID INT FOREIGN KEY REFERENCES Book(BookID),
    ReservationDate DATE NOT NULL,
    Status NVARCHAR(20) DEFAULT 'active',
	RefCode NVARCHAR(20) UNIQUE
);

-- Tạo bảng Report
CREATE TABLE Report (
    ReportID INT PRIMARY KEY IDENTITY,
    ReportDate DATE NOT NULL,
    ReportType NVARCHAR(20),
    TotalLoans INT DEFAULT 0,
    TotalReservations INT DEFAULT 0,
    TotalUsers INT DEFAULT 0
);


-- Insert sample data into User table
INSERT INTO [User] (Username, PasswordHash, Role, FullName, Email, PhoneNo, Address) VALUES
    ('johndoe', 'e10adc3949ba59abbe56e057f20f883e', 'admin', 'John Doe', 'jdoe@example.com', '1234567890', '123 Elm St'),
    ('alicesmith', 'e10adc3949ba59abbe56e057f20f883e', 'reader', 'Alice Smith', 'asmith@example.com', '0987654321', '456 Maple Ave'),
    ('jones', 'e10adc3949ba59abbe56e057f20f883e', 'librarian', 'Mary Jones', 'mjones@example.com', '1122334455', '789 Oak Blvd'),
    ('johnson', 'e10adc3949ba59abbe56e057f20f883e', 'reader', 'David Johnson', 'djohnson@example.com', '2233445566', '101 Pine Cir'),
    ('williams', 'e10adc3949ba59abbe56e057f20f883e', 'reader', 'Rachel Williams', 'rwilliams@example.com', '3344556677', '202 Birch Dr'),
	('michael', 'e10adc3949ba59abbe56e057f20f883e', 'reader', 'Michael Brown', 'mbrown@example.com', '5566778899', '111 Cedar St'),
    ('emilyt', 'e10adc3949ba59abbe56e057f20f883e', 'reader', 'Emily Turner', 'eturner@example.com', '6677889900', '222 Willow Ln'),
    ('sarahk', 'e10adc3949ba59abbe56e057f20f883e', 'librarian', 'Sarah King', 'sking@example.com', '7788990011', '333 Oak St'),
    ('danielh', 'e10adc3949ba59abbe56e057f20f883e', 'reader', 'Daniel Harris', 'dharris@example.com', '8899001122', '444 Ash Ave'),
    ('chrisp', 'e10adc3949ba59abbe56e057f20f883e', 'reader', 'Chris Peterson', 'cpeterson@example.com', '9900112233', '555 Pine St'),
    ('laurac', 'e10adc3949ba59abbe56e057f20f883e', 'reader', 'Laura Carter', 'lcarter@example.com', '1122334455', '666 Maple Dr'),
    ('kevins', 'e10adc3949ba59abbe56e057f20f883e', 'reader', 'Kevin Scott', 'kscott@example.com', '2233445566', '777 Birch Blvd'),
    ('victorial', 'e10adc3949ba59abbe56e057f20f883e', 'reader', 'Victoria Lee', 'vlee@example.com', '3344556677', '888 Elm Cir'),
    ('robertm', 'e10adc3949ba59abbe56e057f20f883e', 'reader', 'Robert Martin', 'rmartin@example.com', '4455667788', '999 Cedar Ave'),
    ('nancyd', 'e10adc3949ba59abbe56e057f20f883e', 'reader', 'Nancy Davis', 'ndavis@example.com', '5566778899', '1010 Oak Ln');

INSERT INTO Book (Title, Author, PublicationYear, Genre, ISBN, Status, Location, Totalcopies, Price) VALUES
    ('1984', 'George Orwell', 1949, 'Dystopian', '1234567890123', 'available', 'Aisle 1', 5, 9.99),
    ('To Kill a Mockingbird', 'Harper Lee', 1960, 'Fiction', '2345678901234', 'available', 'Aisle 2', 3, 12.50),
    ('Pride and Prejudice', 'Jane Austen', 1813, 'Romance', '3456789012345', 'available', 'Aisle 3', 7, 15.75),
    ('The Great Gatsby', 'F. Scott Fitzgerald', 1925, 'Classic', '4567890123456', 'available', 'Aisle 4', 4, 10.00),
    ('Moby Dick', 'Herman Melville', 1851, 'Adventure', '5678901234567', 'available', 'Aisle 5', 2, 8.95),
	('The Catcher in the Rye', 'J.D. Salinger', 1951, 'Fiction', '6789012345678', 'available', 'Aisle 6', 4, 11.99),
    ('Brave New World', 'Aldous Huxley', 1932, 'Dystopian', '7890123456789', 'available', 'Aisle 7', 6, 13.50),
    ('The Hobbit', 'J.R.R. Tolkien', 1937, 'Fantasy', '8901234567890', 'available', 'Aisle 8', 8, 14.99),
    ('War and Peace', 'Leo Tolstoy', 1869, 'Historical', '9012345678901', 'available', 'Aisle 9', 3, 19.99),
    ('Hamlet', 'William Shakespeare', 1603, 'Tragedy', '0123436789312', 'available', 'Aisle 10', 5, 9.50),
    ('The Odyssey', 'Homer', 1800, 'Epic', '1234509876543', 'available', 'Aisle 11', 2, 8.75),
    ('Macbeth', 'William Shakespeare', 1606, 'Tragedy', '2345678987654', 'available', 'Aisle 12', 6, 10.50),
    ('Great Expectations', 'Charles Dickens', 1861, 'Classic', '3456789098765', 'available', 'Aisle 13', 7, 12.00),
    ('The Iliad', 'Homer', 1750, 'Epic', '4567830123456', 'available', 'Aisle 14', 4, 14.20),
    ('Frankenstein', 'Mary Shelley', 1818, 'Gothic', '5672901234567', 'available', 'Aisle 15', 3, 10.75);


-- Insert dữ liệu vào bảng Loan với RefCode 'REFLN0001', 'REFLN0002', v.v.
INSERT INTO Loan (UserID, BookID, LoanDate, ReturnDate, ActualReturnDate, Fine, Status, RefCode) VALUES
    (1, 1, '2024-10-01', '2024-10-15', '2024-10-14', 0.00, 'pending', 'REFLN0001'),
    (2, 2, '2024-10-03', '2024-10-17', NULL, 0.00, 'active', 'REFLN0002'),
    (3, 3, '2024-10-05', '2024-10-19', NULL, 0.00, 'active', 'REFLN0003'),
    (4, 4, '2024-10-07', '2024-10-21', '2024-10-22', 2.00, 'pending', 'REFLN0004'),
    (5, 5, '2024-10-09', '2024-10-23', '2024-10-24', 3.50, 'pending', 'REFLN0005'),
    (6, 7, '2024-10-10', '2024-10-24', '2024-10-23', 0.00, 'pending', 'REFLN0006'),
    (7, 8, '2024-10-11', '2024-10-25', NULL, 0.00, 'active', 'REFLN0007'),
    (8, 9, '2024-10-12', '2024-10-26', '2024-10-27', 1.00, 'pending', 'REFLN0008'),
    (9, 10, '2024-10-13', '2024-10-27', NULL, 0.00, 'active', 'REFLN0009'),
    (10, 6, '2024-10-14', '2024-10-28', '2024-10-29', 2.50, 'pending', 'REFLN0010'),
    (1, 7, '2024-10-15', '2024-10-29', NULL, 0.00, 'active', 'REFLN0011'),
    (2, 8, '2024-10-16', '2024-10-30', NULL, 0.00, 'active', 'REFLN0012'),
    (3, 9, '2024-10-17', '2024-10-31', NULL, 0.00, 'active', 'REFLN0013'),
    (4, 10, '2024-10-18', '2024-11-01', NULL, 0.00, 'active', 'REFLN0014'),
    (5, 6, '2024-10-19', '2024-11-02', NULL, 0.00, 'active', 'REFLN0015');


-- Insert dữ liệu vào bảng Reservation với RefCode 'REFRS0001', 'REFRS0002', v.v.
INSERT INTO Reservation (UserID, BookID, ReservationDate, Status, RefCode) VALUES
	(1, 2, '2024-11-01', 'active', 'REFRS0001'),
	(2, 3, '2024-11-02', 'active', 'REFRS0002'),
	(3, 4, '2024-11-03', 'active', 'REFRS0003'),
	(4, 5, '2024-11-04', 'cancelled', 'REFRS0004'),
	(5, 1, '2024-11-05', 'completed', 'REFRS0005'),
	(6, 7, '2024-11-06', 'active', 'REFRS0006'),
    (7, 8, '2024-11-07', 'active', 'REFRS0007'),
    (8, 9, '2024-11-08', 'active', 'REFRS0008'),
    (9, 10, '2024-11-09', 'cancelled', 'REFRS0009'),
    (10, 6, '2024-11-10', 'completed', 'REFRS0010'),
    (1, 7, '2024-11-11', 'active', 'REFRS0011'),
    (2, 8, '2024-11-12', 'active', 'REFRS0012'),
    (3, 9, '2024-11-13', 'completed', 'REFRS0013'),
    (4, 10, '2024-11-14', 'active', 'REFRS0014'),
    (5, 6, '2024-11-15', 'active', 'REFRS0015');

-- Insert sample data into Report table
INSERT INTO Report (ReportDate, ReportType, TotalLoans, TotalReservations, TotalUsers) VALUES
    ('2024-01-31', 'monthly', 20, 10, 50),
    ('2024-02-29', 'monthly', 25, 15, 55),
    ('2024-03-31', 'monthly', 30, 20, 60),
    ('2024-04-30', 'monthly', 28, 18, 58),
    ('2024-05-31', 'monthly', 35, 25, 65),
	('2024-06-30', 'monthly', 40, 30, 70),
    ('2024-07-31', 'monthly', 42, 32, 72),
    ('2024-08-31', 'monthly', 45, 35, 75),
    ('2024-09-30', 'monthly', 48, 36, 78),
    ('2024-10-31', 'monthly', 50, 38, 80),
    ('2024-11-30', 'monthly', 55, 40, 85),
    ('2024-12-31', 'monthly', 58, 42, 88),
    ('2025-01-31', 'monthly', 60, 45, 90),
    ('2025-02-28', 'monthly', 62, 47, 92),
    ('2025-03-31', 'monthly', 65, 50, 95);