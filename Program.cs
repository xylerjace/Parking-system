using System;

namespace Parking
{
    class ParkingSystem
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Plate Number: ");
            string plateNo = Console.ReadLine();
            Console.Write("Enter Vehicle type:\n[1]Motorcyle\n[2]Suv/Van\n[3]Sedan\n\nOption: ");
            int type = Convert.ToInt16(Console.ReadLine());
            Console.Write("Enter vehicle brand: ");
            string brand = Console.ReadLine();

            switch (type)
            {
                case 1:
                    Motorcycle motorcycle = new Motorcycle(plateNo, brand);
                    HandleVehicle(motorcycle);
                    break;

                case 2:
                    SuvVan suvVan = new SuvVan(plateNo, brand);
                    HandleVehicle(suvVan);
                    break;

                case 3:
                    Sedan sedan = new Sedan(plateNo, brand);
                    HandleVehicle(sedan);
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void HandleVehicle(Vehicle vehicle)
        {
            Console.WriteLine("Plate No: " + vehicle.plateNo);
            Console.WriteLine("Type: " + vehicle.type);
            Console.WriteLine("Brand: " + vehicle.brand);
            Console.WriteLine("Park In: " + vehicle.getParkIn());

            Console.WriteLine("-----------PARKOUT --------");
            Console.Write("Date Timein/parkIn:  " + vehicle.getParkIn());
            Console.Write("\n\tParkout(MM/dd/yyyy HH:mm:ss): ");
            DateTime parkOut = Convert.ToDateTime(Console.ReadLine());
            vehicle.setParkOut(parkOut);

            TimeSpan duration = vehicle.getTotalDuration();
            int totalHours = duration.Hours;
            Console.WriteLine("Parking time: " + totalHours + " Hours");
            Console.WriteLine("Total hours: " + vehicle.calculatePrice(totalHours));
        }
    }

    abstract class Vehicle
    {
        public string plateNo;
        public string type;
        public string brand;

        // Constructor
        public Vehicle(string plateNo, string type, string brand)
        {
            this.plateNo = plateNo;
            this.type = type;
            this.brand = brand;
        }

        public DateTime getParkIn()
        {
            return DateTime.Now;
        }

        public abstract TimeSpan getTotalDuration();
        public abstract int calculatePrice(int hours);
        public abstract void setParkOut(DateTime parkout);
    }

    class Motorcycle : Vehicle
    {
        int flagDown = 20;
        int additional = 5;
        DateTime parkOut;

        public Motorcycle(string plateNo, string brand) : base(plateNo, "Motorcycle", brand)
        {
        }

        public override TimeSpan getTotalDuration()
        {
            return parkOut - getParkIn();
        }

        public override void setParkOut(DateTime parkout)
        {
            this.parkOut = parkout;
        }

        public override int calculatePrice(int hours)
        {
            return (hours * additional) + flagDown;
        }
    }

    class SuvVan : Vehicle
    {
        int flagDown = 40;
        int additional = 20;
        DateTime parkOut;

        public SuvVan(string plateNo, string brand) : base(plateNo, "Suv/Van", brand)
        {
        }

        public override TimeSpan getTotalDuration()
        {
            return parkOut - getParkIn();
        }

        public override void setParkOut(DateTime parkout)
        {
            this.parkOut = parkout;
        }

        public override int calculatePrice(int hours)
        {
            return (hours * additional) + flagDown;
        }
    }

    class Sedan : Vehicle
    {
        int flagDown = 30;
        int additional = 15;
        DateTime parkOut;

        public Sedan(string plateNo, string brand) : base(plateNo, "Sedan", brand)
        {
        }

        public override TimeSpan getTotalDuration()
        {
            return parkOut - getParkIn();
        }

        public override void setParkOut(DateTime parkout)
        {
            this.parkOut = parkout;
        }

        public override int calculatePrice(int hours)
        {
            return (hours * additional) + flagDown;
        }
    }
}
