using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Car
    {
        private string RegNo;
        private string CarType;
        private int Capacity;
        private int Seats;
        private string CarModel;
        private string CarMake;
        private string FuelType;
        private string CarDescription;
        private string Status;
        private string TransmissionType;

        public Car() { 
            this.RegNo = "";
            this.CarType = "";
            this.Capacity = 0;
            this.Seats = 0;
            this.CarModel = "";
            this.CarMake = "";
            this.FuelType = "";
            this.CarDescription = "";
            this.Status = "";
            this.TransmissionType = "";
        }

        public Car(string regNo, string carType, int capacity, int seats, string carModel, string carMake, string fuelType, string carDescription, string status, string transmissionType) {
      
            this.RegNo = regNo;
            this.CarType = carType;
            this.Capacity = capacity;
            this.Seats = seats;
            this.CarModel = carModel;
            this.CarMake = carMake;
            this.FuelType = fuelType;
            this.CarDescription = carDescription;
            this.Status = status;
            this.TransmissionType = transmissionType;

        }

        public void setRegNo(string regNo) {
            this.RegNo = regNo;
        }
        public void setCarType(string carType) { 
            this.CarType=carType;
        }
        public void setCapacity(int capacity)
        {
            this.Capacity = capacity;
        }
        public void setSeats(int seats)
        {
            this.Seats=seats;
        }
        public void setCarModel(string carModel) { 
            this.CarModel=carModel;
        }
        public void setCarMake(string carMake) { 
            this.CarMake=carMake;
        }
        public void setFuealType(string fuelType) { 
            this.FuelType=fuelType;
        }
        public void setCarDescription(string carDescription) { 
            this.CarDescription=carDescription;
        }
        public void setStatus(string status)
        {
            this.Status=status;
        }
        public void setTransmissionType(string transmissionType) { 
            this.TransmissionType=transmissionType;
        }


        public string getRegNo()
        {
            return this.RegNo;
        }
        public string getCarType()
        {
            return this.CarType;
        }
        public int getCapacity()
        {
            return this.Capacity;
        }
        public int getSeats()
        {
            return this.Seats;
        }
        public string getCarModel()
        {
            return this.CarModel;
        }
        public string getCarMake()
        {
            return this.CarMake;
        }
        public string getFuealType()
        {
            return this.FuelType;
        }
        public string getCarDescription()
        {
            return this.CarDescription;
        }
        public string getStatus()
        {
            return this.Status;
        }
        public string getTransmissionType()
        {
            return this.TransmissionType;
        }

    }
}
