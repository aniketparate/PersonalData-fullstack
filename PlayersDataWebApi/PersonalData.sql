show search_path;
set search_path to personaldata, public;

CREATE TABLE Users (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    date_of_birth DATE NOT NULL,
    residential_address TEXT NOT NULL,
    permanent_address TEXT NOT NULL,
    phone_number VARCHAR(15) NOT NULL,
    email_address VARCHAR(255) NOT NULL UNIQUE,
    marital_status VARCHAR(50),
    gender VARCHAR(10),
    occupation VARCHAR(100),
    aadhar_card_number VARCHAR(12) UNIQUE,
    pan_number VARCHAR(10) UNIQUE,
    image TEXT
);

DROP TABLE USERS;
truncate table users;

INSERT INTO Users (
    name, 
    date_of_birth,
    residential_address, 
    permanent_address, 
    phone_number, 
    email_address, 
    marital_status, 
    gender, 
    occupation, 
    aadhar_card_number, 
    pan_number, 
    image
) 
VALUES 
(
    'John Doe', 
    '1990-05-15', 
    '123 Elm Street, Cityville', 
    '456 Oak Avenue, Townsville', 
    '9876543210', 
    'john.doe@example.com', 
    'Married', 
    'Male', 
    'Software Engineer', 
    '123456789012', 
    'ABCDE1234F', 
    'static/images/john_doe.jpg'
),
(
    'Jane Smith', 
    '1985-12-22', 
    '789 Pine Road, Metropolis', 
    '123 Birch Blvd, Suburbia', 
    '9123456789', 
    'jane.smith@example.com', 
    'Single', 
    'Female', 
    'Graphic Designer', 
    '987654321012', 
    'XYZPQ6789L', 
    'static/images/jane_smith.jpg'
),
(
    'Michael Johnson', 
    '1992-09-30', 
    '101 Maple Lane, Citytown', 
    '202 Spruce Avenue, Villagetown', 
    '9871234567', 
    'michael.johnson@example.com', 
    'Married', 
    'Male', 
    'Accountant', 
    '112233445566', 
    'ABCDE2345G', 
    'static/images/michael_johnson.jpg'
),
(
    'Emily Davis', 
    '1996-03-12', 
    '303 Willow Street, Downtown', 
    '404 Cedar Road, Uptown', 
    '9987654321', 
    'emily.davis@example.com', 
    'Single', 
    'Female', 
    'Doctor', 
    '665544332211', 
    'WXYZM9876H', 
    'static/images/emily_davis.jpg'
),
(
    'Robert Brown', 
    '1988-07-24', 
    '505 Cherry Avenue, Cityland', 
    '606 Oakwood Street, Countryside', 
    '9128765432', 
    'robert.brown@example.com', 
    'Divorced', 
    'Male', 
    'Marketing Manager', 
    '998877665544', 
    'LMNOP1234Q', 
    'static/images/robert_brown.jpg'
),
(
    'Sophia Wilson', 
    '1994-11-08', 
    '707 Redwood Drive, Metrocity', 
    '808 Magnolia Street, Hillside', 
    '9234567890', 
    'sophia.wilson@example.com', 
    'Married', 
    'Female', 
    'Teacher', 
    '554433221100', 
    'NOPQR5678T', 
    'static/images/john_doe.jpg'
);

select * from users;