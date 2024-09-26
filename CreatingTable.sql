-- Drop tables with foreign key constraints last
DROP TABLE RENTALS; 
DROP TABLE CUSTOMERS;
DROP TABLE EQUIPMENT;
DROP TABLE CARS;
DROP TABLE CARTYPES;
DROP TABLE MakeModels;
DROP TABLE RentTimes;
DROP TABLE FuelTypes;


Create Table FuelTypes(
FuelType VARCHAR(1),
CONSTRAINT pk_FuelTypes PRIMARY KEY (FuelType));

INSERT INTO FuelTypes Values('H');
INSERT INTO FuelTypes Values('G');
INSERT INTO FuelTypes Values('E');
INSERT INTO FuelTypes Values('H');
INSERT INTO FuelTypes Values('D');







CREATE TABLE RentTimes(
RTime char(5),
CONSTRAINT pk_RentTimes PRIMARY KEY (RTime));

INSERT INTO RentTimes VALUES('07:00');
INSERT INTO RentTimes VALUES('07:30');
INSERT INTO RentTimes VALUES('08:00');
INSERT INTO RentTimes VALUES('08:30');
INSERT INTO RentTimes VALUES('09:00');
INSERT INTO RentTimes VALUES('09:30');
INSERT INTO RentTimes VALUES('10:00');
INSERT INTO RentTimes VALUES('10:30');
INSERT INTO RentTimes VALUES('11:00');
INSERT INTO RentTimes VALUES('11:30');
INSERT INTO RentTimes VALUES('12:00');
INSERT INTO RentTimes VALUES('12:30');
INSERT INTO RentTimes VALUES('13:00');
INSERT INTO RentTimes VALUES('13:30');
INSERT INTO RentTimes VALUES('14:00');
INSERT INTO RentTimes VALUES('14:30');
INSERT INTO RentTimes VALUES('15:00');
INSERT INTO RentTimes VALUES('15:30');
INSERT INTO RentTimes VALUES('16:00');
INSERT INTO RentTimes VALUES('16:30');
INSERT INTO RentTimes VALUES('17:00');
INSERT INTO RentTimes VALUES('17:30');
INSERT INTO RentTimes VALUES('18:00');
INSERT INTO RentTimes VALUES('18:30');
INSERT INTO RentTimes VALUES('19:00');
INSERT INTO RentTimes VALUES('19:30');
INSERT INTO RentTimes VALUES('20:00');
INSERT INTO RentTimes VALUES('20:30');
INSERT INTO RentTimes VALUES('21:00');



CREATE TABLE MakeModels(
Make varchar2(15) NOT NULL,
Model varchar2(15) NOT NULL,
CONSTRAINT pk_MakeModel PRIMARY KEY (Make, Model));

INSERT INTO MakeModels VALUES('TOYOTA', 'YARIS');
INSERT INTO MakeModels VALUES('TOYOTA', 'COROLLA');
INSERT INTO MakeModels VALUES('OPEL', 'ASTRA');
INSERT INTO MakeModels VALUES('OPEL', 'CORSA');
INSERT INTO MakeModels VALUES('HYUNDAI', 'TUCSON');
INSERT INTO MakeModels VALUES('TOYOTA', 'CAMRY');
INSERT INTO MakeModels VALUES('TOYOTA', 'RAV4');
INSERT INTO MakeModels VALUES('HONDA', 'CIVIC');
INSERT INTO MakeModels VALUES('HONDA', 'ACCORD');
INSERT INTO MakeModels VALUES('FORD', 'MUSTANG');
INSERT INTO MakeModels VALUES('FORD', 'EXPLORER');
INSERT INTO MakeModels VALUES('CHEVROLET', 'CRUZE');
INSERT INTO MakeModels VALUES('CHEVROLET', 'TAHOE');


-- Create tables with unique constraint names and appropriate data types
CREATE TABLE CarTypes(
    TypeCode VARCHAR2(2) NOT NULL,
    Type_Description VARCHAR2(10) NOT NULL,
    Rate DECIMAL(5,2) NOT NULL,
    CONSTRAINT pk_CarType PRIMARY KEY (TypeCode)
);

INSERT INTO CarTypes VALUES('EC','ECO',30.00);
INSERT INTO CarTypes VALUES('PM','PREMIUM',100.00);
INSERT INTO CarTypes VALUES('FM','FAMILY',80.00);
INSERT INTO CarTypes VALUES('CM', 'Compact', 35.00);
INSERT INTO CarTypes VALUES('MD', 'Midsize', 40.00);
INSERT INTO CarTypes VALUES('FU', 'Full-size', 45.00);
INSERT INTO CarTypes VALUES('LU', 'Luxury', 60.00);
INSERT INTO CarTypes VALUES('SV', 'SUV', 50.00);
INSERT INTO CarTypes VALUES('VT', 'Van/Truck', 55.00);
INSERT INTO CarTypes VALUES('SP', 'Sports', 70.00);


CREATE TABLE Cars(
   RegNum VARCHAR(10) NOT NULL,
   TypeCode VARCHAR2(2) NOT NULL, 
   Car_Description VARCHAR2(10) NOT NULL,
   Num_Seats NUMERIC(1) NOT NULL,
   Car_Model VARCHAR2(10) NOT NULL,
   Car_Make VARCHAR2(10) NOT NULL,
   Fuel_Type VARCHAR2(1) NOT NULL,
   Car_Status VARCHAR2(1) NOT NULL, 
   CONSTRAINT pk_Cars PRIMARY KEY (RegNum),
   CONSTRAINT fk_Cars FOREIGN KEY (TypeCode) REFERENCES CarTypes(TypeCode),
   CONSTRAINT fk_Cars_MakeModel FOREIGN KEY (Car_Make, Car_Model) REFERENCES MakeModels(Make, Model),
   CONSTRAINT fk_Cars_Fuel_Type FOREIGN KEY (Fuel_Type) REFERENCES FuelTypes(FuelType)
);
INSERT INTO Cars VALUES('ABC123BAC', 'CM', 'Compact', 5, 'YARIS', 'TOYOTA', 'G', 'A');
INSERT INTO Cars VALUES('DEF456WEW', 'SV', 'SUV', 7, 'RAV4', 'TOYOTA', 'D', 'A');
INSERT INTO Cars VALUES('GHI789RTT', 'MD', 'Midsize', 5, 'CAMRY', 'TOYOTA', 'H', 'A');
INSERT INTO Cars VALUES('JKL012YTT', 'LU', 'Luxury', 5, 'CAMRY', 'TOYOTA', 'D', 'A');
INSERT INTO Cars VALUES('MNO345UIO', 'CM', 'Compact', 5, 'CIVIC', 'HONDA', 'G', 'A');
INSERT INTO Cars VALUES('PQR678QDR', 'SV', 'SUV', 7, 'CIVIC', 'HONDA', 'E', 'A');
INSERT INTO Cars VALUES('STU901ASA', 'EC', 'Compact', 5, 'TUCSON', 'HYUNDAI', 'D', 'A');
INSERT INTO Cars VALUES('VWX234FGB', 'SP', 'Sports', 2, 'COROLLA', 'TOYOTA', 'G', 'A');



CREATE TABLE Equipment(
    EquipID NUMERIC(10) NOT NULL,
    Equip_Description VARCHAR2(15) NOT NULL,--brand name
    Equip_Name VARCHAR2(15) NOT NULL,--nME OF EQUIPMENT
    Price DECIMAL(5,2) NOT NULL, 
    Equip_Status VARCHAR2(1) NOT NULL, -- Renamed Status_E column to avoid conflict
    CONSTRAINT pk_Equipment PRIMARY KEY (EquipID)
);
INSERT INTO Equipment (EquipID, Equip_Description, Equip_Name, Price, Equip_Status)
VALUES (1, 'N/A', 'N/A', 0.00, 'A');
INSERT INTO Equipment VALUES (10, 'GPS', 'Navigation', 5.00, 'A');


CREATE TABLE CUSTOMERS(
    CustID NUMERIC (9) NOT NULL,
    Forename VARCHAR (30) NOT NULL,
    Surname VARCHAR (30) NOT NULL,
    Email VARCHAR (30) NOT NULL,
    Phone_Num NUMERIC (12) NOT NULL, 
    Licence_Num VARCHAR (9) NOT NULL, 
    CONSTRAINT pk_Customer PRIMARY KEY (CustID)
);
INSERT INTO CUSTOMERS VALUES (1, 'John', 'Doe', 'john.doe@gmail.com', 1234567890, 'AB1234567');



CREATE TABLE RENTALS(
    Rental_Number NUMERIC (9) NOT NULL,
    RegNum VARCHAR (10) NOT NULL, -- Car wanted
    TypeCode VARCHAR(2) NOT NULL,
    RentStart DATE NOT NULL, -- Date customer has to pick up/collect rental car
    ReturnDate DATE NOT NULL,
    RentStartTime VARCHAR(5) NOT NULL,
    RentEndTime VARCHAR (5) NOT NULL,
    Amount Decimal (5,2) NOT NULL,
    CustID NUMERIC (9) NOT NULL,
    EquipID NUMERIC (10) NOT NULL, -- Allow NULL values for EquipID
    Customer_Status VARCHAR(1) NOT NULL, -- The customer's status: P, C
    CONSTRAINT pk_Rental PRIMARY KEY (Rental_Number),
    CONSTRAINT fk_Rental_CUST FOREIGN KEY (CustID) REFERENCES CUSTOMERS (CustID),
    CONSTRAINT fk_Rental_CAR FOREIGN KEY (RegNum) REFERENCES Cars(RegNum),
    CONSTRAINT fk_Rental_Equipment FOREIGN KEY (EquipID) REFERENCES Equipment(EquipID),
    CONSTRAINT fk_Rental_TypeCode FOREIGN KEY (TypeCode) REFERENCES CarTypes(TypeCode)
);
INSERT INTO RENTALS (Rental_Number, RegNum, TypeCode, RentStart, ReturnDate, RentStartTime, RentEndTime, Amount, CustID, EquipID, Customer_Status)
VALUES (1001, 'ABC123BAC', 'CM', TO_DATE('2024-06-01', 'YYYY-MM-DD'), TO_DATE('2024-06-05', 'YYYY-MM-DD'), '07:30', '09:30', 200.00, 1, 10, 'P');




COMMIT;
