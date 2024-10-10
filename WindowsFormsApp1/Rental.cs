using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace CarRentSys
{
    internal class Rental
    {
        //add cartype to this 
        //find a way to use sql join statement to add the price of the car
        private int rentalNumber;
        private decimal Cost;
        private int AccountID;
        private String regNum;
        private String rentStart;
        private String returnDate;




        public Rental()
        {
            this.rentalNumber = 0;
            this.amount = 0;
            this.custID = 0;
            this.equipID = 0;
            this.rentStart = "";
            this.status = "";
            this.returnDate = "";
            this.regNum = "";
            this.returnTime = "";
            this.rentStartTime = "";
            this.typeCode = "";

        }

        public Rental(int rentalNumber, string regNum, string typeCode, string rentStart, string returnDate, string renStartTime, string returnTime, decimal amount, int custID, int equipID, string status)
        {
            this.rentalNumber = rentalNumber;
            this.amount = amount;
            this.custID = custID;
            this.equipID = equipID;
            this.regNum = regNum;
            this.rentStart = rentStart;
            this.returnDate = returnDate;
            this.status = status;
            this.returnTime = returnTime;
            this.rentStartTime = renStartTime;
            this.typeCode = typeCode;

        }

        //getters
        public int getrentalNumber() { return this.rentalNumber; }
        public decimal getamount() { return this.amount; }
        public int getCustID() { return this.custID; }
        public int getequipID() { return this.equipID; }
        public String getRegNum() { return this.regNum; }
        public String getRentStart() { return this.rentStart; }
        public String getStatus() { return this.status; }
        public String getReturnDate() { return this.returnDate; }
        public String getRentStartTime() { return this.rentStartTime; }
        public String getReturnTime() { return this.returnTime; }
        public string getTypeCode() { return this.typeCode; }





        //setters
        public void setRentalNumber(int RentalNumber) { rentalNumber = RentalNumber; }
        public void setAmount(decimal Amount) { cost }

        public void setAccountID(int CustID) { AccountID = CustID; }
        
        public void setRegNum(String RegNum) { regNum = RegNum; }
        public void setRentStart(String RentStart) { rentStart = RentStart; }
        public void setStatus(String Status) { status = Status; }
        public void SetReturnDate(String ReturnDate) { returnDate = ReturnDate; }
        public void SetReturnTime(String ReturnTime) { returnTime = ReturnTime; }
        public void SetRentStartTime(String RentStartTime) { rentStartTime = RentStartTime; }
        public void SetTypeCode(String TypeCode) { typeCode = TypeCode; }




        public static DataSet getAllRentals()
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oraDB);

            String sqlQuery = "SELECT Rental_Number, Amount, Cust_ID, EquipID, RegNum, RentStart, ReturnDate, Customer_Status, RentStartTime, ReturnTime, TypeCode " +
                              "FROM Rental ORDER BY Rental_Number";


            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);

            OracleDataAdapter da = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "Rental");

            //Close db connection
            conn.Close();

            return ds;
        }

        public void getRental(int RentalNumber)
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oraDB);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT * FROM Rental WHERE Rental_Number = " + RentalNumber + "";

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();

            //set the instance variables with values from data reader
            setRentalNumber(dr.GetInt32(0));
            setAmount(dr.GetDecimal(1));
            setCustID(dr.GetInt32(3));
            setEquipID(dr.GetInt32(4));
            setRegNum(dr.GetString(5));
            setRentStart(dr.GetString(6));
            SetReturnDate(dr.GetString(7));
            setStatus(dr.GetString(8));
            SetRentStartTime(dr.GetString(9));
            SetReturnTime(dr.GetString(10));
            SetTypeCode(dr.GetString(11));


            //close DB
            conn.Close();
        }
        public void makeRental()
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oraDB);

            //Define the SQL query to be executed
            String sqlQuery = "INSERT INTO Rentals (Rental_Number, RegNum, TypeCode, RentStart, ReturnDate, RentStartTime, RentEndTime, Amount, CustID, EquipID, Customer_Status) " +
                              "VALUES (" +
                              this.rentalNumber + ", '" +
                              this.regNum + "', '" +
                              this.typeCode + "', TO_DATE('" +
                              this.rentStart + "', 'YYYY-MM-DD'), TO_DATE('" +
                              this.returnDate + "', 'YYYY-MM-DD'), '" +
                              this.rentStartTime + "', '" +
                              this.returnTime + "', " +
                              this.amount + ", " +
                              this.custID + ", " +
                              this.equipID + ", '" +
                              this.status + "')";



            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            cmd.ExecuteNonQuery();

            //Close db connection
            conn.Close();
        }
        public static DataSet findRental(int RentalNumber, int Cust_ID)
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oraDB);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT Rental_Number, Amount, CustID, RegNum, RentStart, ReturnDate, Customer_Status, RentStartTime, RentEndTime, TypeCode " +
                   "FROM Rentals " +
                   "WHERE Rental_Number = " + RentalNumber + " AND CustID = " + Cust_ID;


            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);

            OracleDataAdapter da = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "Rental");

            //Close db connection
            conn.Close();

            return ds;
        }


        public static DataSet GetAvailableCarsForDates(string typeCode, string startDate, string endDate)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oraDB);
            DataSet ds = new DataSet();



            conn.Open();
            string sqlQuery = "SELECT Cars.RegNum, Cars.Car_Make, Cars.Car_Model, Cars.TypeCode, CarTypes.Rate " +
                          "FROM Cars " +
                          "INNER JOIN CarTypes ON Cars.TypeCode = CarTypes.TypeCode " +
                          "WHERE Cars.TypeCode = '" + typeCode + "' " +
                          "AND Cars.RegNum NOT IN (" +
                          "SELECT DISTINCT RegNum " +
                          "FROM RENTALS " +
                          "WHERE (TO_DATE('" + startDate + "', 'YYYY-MM-DD') BETWEEN RentStart AND ReturnDate) " +
                          "OR (TO_DATE('" + endDate + "', 'YYYY-MM-DD') BETWEEN RentStart AND ReturnDate) " +
                          "OR (RentStart BETWEEN TO_DATE('" + startDate + "', 'YYYY-MM-DD') AND TO_DATE('" + endDate + "', 'YYYY-MM-DD')) " +
                          "OR (ReturnDate BETWEEN TO_DATE('" + startDate + "', 'YYYY-MM-DD') AND TO_DATE('" + endDate + "', 'YYYY-MM-DD')))";


            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(ds, "AvailableCars");






            conn.Close();


            return ds;
        }

        public static DataSet AvialableCar(String typeCode)
        {
            OracleConnection conn = new OracleConnection(DBConnect.oraDB);


            String sqlQuery = "SELECT Cars.RegNum, Cars.Make, Cars.Model, Cars.TypeCode, CarTypes.Rate FROM Cars" +
                            "INNER JOIN CarTypes ON Cars.TypeCode = CarTypes.TypeCode WHERE Cars.TypeCode =  '" + typeCode + "'";

            OracleCommand cmd = new OracleCommand(sqlQuery, conn);

            OracleDataAdapter da = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "Rentals");

            //close db connection
            conn.Close();
            return ds;


        }


        public static DataSet getAvailableEquipment()
        {
            //open db connection
            OracleConnection conn = new OracleConnection(DBConnect.oraDB);

            //define the sql query to be executed
            String sqlQuery = "SELECT Equipment.EquipID, Equipment.Equip_Description, Equipment.Equip_Name, Equipment.Price, Equipment.Equip_Status" +
                " FROM Equipment WHERE Equipment.Equip_Status = 'A' ";

            //execute the sql query(OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);

            OracleDataAdapter da = new OracleDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds, "AvailableEquip");

            //close db connection
            conn.Close();
            return ds;
        }

        public static int getNextRentalNumber()
        {
            //Open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oraDB);

            //Define the SQL query to be executed
            String sqlQuery = "SELECT MAX(Rental_Number) FROM Rentals";

            //Execute the SQL query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            OracleDataReader dr = cmd.ExecuteReader();

            //Does dr contain a value or NULL?
            int nextId;
            dr.Read();

            if (dr.IsDBNull(0))
                nextId = 1;
            else
            {
                nextId = dr.GetInt32(0) + 1;
            }

            //Close db connection
            conn.Close();

            return nextId;
        }
        public void RemoveRental(int RentalNumber)
        {
            //open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oraDB);

            //define sql query to be executed
            String sqlQuery = "DELETE FROM Rentals WHERE Rental_Number = " + RentalNumber;

            //execute sql query (OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            cmd.ExecuteNonQuery();

            //close connection
            conn.Close();
        }
        public void updateRental()
        {
            //open a db connection
            OracleConnection conn = new OracleConnection(DBConnect.oraDB);

            //define the sql query to be executed
            String sqlQuery = "UPDATE Rentals SET Customer_Status = '" + this.status + "'";


            //excute sql query(OracleCommand)
            OracleCommand cmd = new OracleCommand(sqlQuery, conn);
            conn.Open();

            cmd.ExecuteNonQuery();

            //close connection
            conn.Close();
        }

    }
}