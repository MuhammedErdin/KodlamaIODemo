Create table Courses 
(
Id int, CourseName varchar(255), CategoryId int, InstructorId int, 
Descriptions varchar(255), Price Decimal(10,2) 
);
INSERT INTO Courses (Id, CourseName, CategoryId, InstructorId, Descriptions, Price) VALUES 
(1, 'C#', 1, 1, 'C# Yazılım Geliştirici Yetiştirme Kampı', 154.99),
(2, 'Python', 1, 2, 'Python-Selenium Yazılım Geliştirici Yetiştirme Kampı', 124.99),
(3, 'Java', 1, 1, 'Java Yazılım Geliştirici Yetiştirme Kampı', 149.99),
(4, 'JavaScript', 2, 1, 'JavaScript Yazılım Geliştirici Yetiştirme Kampı', 119.99);

Create table Instructors
(
InstructorId int, FirstName varchar(255), LastName varchar(255) Primary Key
);
INSERT INTO Instructors (InstructorId, FirstName, LastName) VALUES 
(1, 'Engin', 'Demiroğ'),
(2, 'Halit Enes', 'Kalaycı');

Create table Categories
(
CategoryId int, CategoryName varchar(255)
);
INSERT INTO Categories (CategoryId, CategoryName) VALUES 
(1, 'Back-End'),
(2, 'Front-End'),
(3, 'DataBases');

--Drop table Courses;
