using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Example_5
    {
        // object studentB tham chiếu chung với object studentA 
        public static void ClassExample_1()
        {
            Student studentA;
            Student studentB;
            studentA = new Student(1, "Nam", "IGUCSharp", false);
            studentB = studentA;
            studentA.RenameStudent("Hang");
            studentA.isFemale = true;

            Console.WriteLine("Thong tin sinh vien A: name = " + studentA.name + ", class = " + studentA.className + ", Gender = " + (studentA.isFemale ? "Female" : "Male"));
            Console.WriteLine("Thong tin sinh vien B: name = " + studentB.name + ", class = " + studentB.className + ", Gender = " + (studentB.isFemale ? "Female" : "Male"));
            Console.ReadKey();
        }
        //=======================================================
        // object studentB và studentA tham chiếu khác nhau
        public static void ClassExample_2()
        {
            Student studentA;
            Student studentB;
            studentA = new Student(1, "Nam", "IGUCSharp", false);
            studentB = new Student(1, "Nam", "IGUCSharp", false);
            studentA.RenameStudent("Hang");
            studentA.isFemale = true;

            Console.WriteLine("Thong tin sinh vien A: name = " + studentA.name + ", class = " + studentA.className + ", Gender = " + (studentA.isFemale ? "Female" : "Male"));
            Console.WriteLine("Thong tin sinh vien B: name = " + studentB.name + ", class = " + studentB.className + ", Gender = " + (studentB.isFemale ? "Female" : "Male"));
            Console.ReadKey();
        }
        //=======================================================
        public static void CreateStudentWithNoParam()
        {
            Student studentA = new Student();
            Console.WriteLine("Thong tin sinh vien A: Id = " + studentA.Id + ",name = " + studentA.name + ", class = " + studentA.className + ", Gender = " + (studentA.isFemale ? "Female" : "Male"));
            Console.ReadKey();
        }


        public static void CreateStudentListExample()
        {
            List<Student> studentList = new List<Student>();
            studentList.Add(new Student(1, "Truong Tien Dan", "GU0819E", false));
            studentList.Add(new Student(2, "Nguyen Huyen Trang", "MN222", true));
            Console.WriteLine(string.Format("{0}:{1:D2}:{2:D2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
        }
    }


    public class Student
    {
        public readonly int Id;
        public string name { get; private set; }
        public string className { get; private set; }
        public bool isFemale;

        ~Student()// hàm hủy, ko cần thiết
        {
            // lam j cung dc
        } 

        public Student()
        {
            //Id = 1;
            //name = "Nam";
            //className = "CSharpBasic";
            //isFemale = false;
        }

        public Student(int ID, string Name, string ClassName, bool IsFemale)
        {
            Id = ID;
            name = Name;
            className = ClassName;
            isFemale = IsFemale;
        }

        public void RenameStudent(string Name)
        {
            name = Name;
        }
    }

    // ==============================================================================================================================
    public abstract class Vehicle
    {
        public string vehicleName { get; private set; } // tên xe
        public int vehicleSeatNumber { get; private set; } // số ghế của xe
        public int vehicleWheelNumber { get; private set; } // số bánh của xe

        private float fuelPercentage; // phần trăm của xăng xe (từ 0 đến 100)

        public Vehicle(string Name, int SeatNumber, int WheelNumber, float FuelPercentage)
        {
            vehicleName = Name;
            vehicleSeatNumber = SeatNumber;
            vehicleWheelNumber = WheelNumber;
            fuelPercentage = FuelPercentage;
        }

        public void SetName(string Name)
        {
            vehicleName = Name;
        }

        public virtual void SetSeatNumber(int SeatNumber)
        {
            vehicleSeatNumber = SeatNumber;
        }

        public virtual void SetWheelNumber(int WheelNumber)
        {
            vehicleWheelNumber = WheelNumber;
        }

        protected float GetFuelPercentage()
        {
            return fuelPercentage;
        }

        private void GetFuel(float fuelIn)
        {
            if(fuelIn + fuelPercentage > 100f)
            {
                fuelPercentage = 100f;
                Console.WriteLine("Tran` binh`");
            }
            else
            {
                fuelPercentage += fuelIn;
                // tương đương fuelPercentage = fuelPercentage + fuelIn;
            }
        }

        public void StartATrip(float TripDistance)
        {
            CheckCanRun(TripDistance);
        }

        protected abstract void CheckCanRun(float Distance);
    }

    public class Bike : Vehicle
    {
        private float fuelSpendPerKm;
        public Bike(string Name, int SeatNumber, int WheelNumber, float FuelPercentage, float FuelSpent) : base(Name, SeatNumber, WheelNumber, FuelPercentage)
        {
            fuelSpendPerKm = FuelSpent;
        }
        protected override void CheckCanRun(float DistanceForBike)
        {
            if (DistanceForBike * fuelSpendPerKm > GetFuelPercentage())
            {
                Console.WriteLine("ko du xang");
            }
            else
            {
                Console.WriteLine("Quay thoi");
            }
        }
    }

    public class Car : Vehicle
    {
        private float fuelSpendPerKm;
        private string license;
        public Car(string Name, int SeatNumber, int WheelNumber, float FuelPercentage, float FuelSpent) : base(Name, SeatNumber, WheelNumber, FuelPercentage)
        {
            fuelSpendPerKm = FuelSpent;
        }

        public void SetLicense(string LicenseType)
        {
            if (LicenseType != "B2" || LicenseType != "C" || LicenseType != "D" || LicenseType != "E" || LicenseType != "F")
                license = "B1";
            else license = LicenseType;
        }

        protected override void CheckCanRun(float DistanceForBike)
        {
            if(CheckLicense() == false)
            {
                Console.WriteLine("ko du dieu kien lai xe");
                Console.ReadKey();
                return;
            }
            if (DistanceForBike * fuelSpendPerKm > GetFuelPercentage())
            {
                Console.WriteLine("ko du xang");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Quay thoi");
                Console.ReadKey();
            }
        }

        public bool CheckLicense()
        {
            switch (license)
            {
                case "B2":
                case "C":
                    if (vehicleSeatNumber > 9) return false;
                    else return true;                
                case "D":
                    if (vehicleSeatNumber > 30) return false;
                    else return true;
                case "E":
                case "F":
                    return true;
                default:
                    return false;
            }
        }
    }
}
