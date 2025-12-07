-- ---------------------------------------------------------
-- 1. Create Database
-- ---------------------------------------------------------
CREATE DATABASE Bookstore;
USE Bookstore;

-- ---------------------------------------------------------
-- 2. Create Tables
-- ---------------------------------------------------------

-- Authors table with primary key
CREATE TABLE Authors (
    AuthorID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL
);

-- Books table with primary key and foreign key reference to Authors
CREATE TABLE Books (
    BookID INT AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Price DECIMAL(6,2) NOT NULL,
    AuthorID INT NOT NULL,
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID)
);

-- ---------------------------------------------------------
-- 3. Insert Sample Data
-- ---------------------------------------------------------

-- Insert authors
INSERT INTO Authors (FirstName, LastName) VALUES
('George', 'Orwell'),
('Jane', 'Austen'),
('Mark', 'Twain'),
('Toni', 'Morrison'),
('Haruki', 'Murakami');

-- Insert books (each referencing an author)
INSERT INTO Books (Title, Price, AuthorID) VALUES
('1984', 14.99, 1),
('Animal Farm', 9.99, 1),
('Pride and Prejudice', 12.50, 2),
('Beloved', 16.00, 4),
('Kafka on the Shore', 18.75, 5);

-- ---------------------------------------------------------
-- 4. Basic SELECT Statements
-- ---------------------------------------------------------

-- Select all columns from Books
SELECT * FROM Books;

-- Select specific columns from Authors
SELECT FirstName, LastName FROM Authors;

-- ---------------------------------------------------------
-- 5. Filtering with WHERE
-- ---------------------------------------------------------

-- Select books priced above $15
SELECT Title, Price
FROM Books
WHERE Price > 15;

-- ---------------------------------------------------------
-- 6. Testing Queries
-- (Manually run each query to confirm expected output)
-- ---------------------------------------------------------

-- Example: Join query to verify relationships (not required, but helpful)
SELECT b.Title, b.Price, a.FirstName, a.LastName
FROM Books b
JOIN Authors a ON b.AuthorID = a.AuthorID;
