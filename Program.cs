using System;

namespace Parking
{
    class ParkingSystem
    {
        static void Main(string[] args)
        {
            string plateNo, brand;
            string typeStr;
            int type;

            do
            {
                Console.Write("Enter Plate Number: ");
                plateNo = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(plateNo));

            do
            {
                Console.Write("Enter Vehicle type:\n[1] Motorcycle\n[2] Suv/Van\n[3] Sedan\n\nOption: ");
                typeStr = Console.ReadLine();
            } while (!int.TryParse(typeStr, out type) || type < 1 || type > 3);

            do
            {
                Console.Write("Enter vehicle brand: ");
                brand = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(brand));

          

            switch (type)
            {
                case 1:
                    Motorcycle motor = new Motorcycle(plateNo, brand);
                    HandleVehicle(motor);
                    break;

                case 2:
                    SuvVan suv = new SuvVan(plateNo, brand);
                    HandleVehicle(suv);
                    break;

                case 3:
                    Sedan sedan = new Sedan(plateNo, brand);
                    HandleVehicle(sedan);
                    break;
            }

           
        }

        static void HandleVehicle(Vehicle vehicle)
        {
            Console.WriteLine("Plate No: " + vehicle.PlateNo);
            Console.WriteLine("Type: " + vehicle.Type);
            Console.WriteLine("Brand: " + vehicle.Brand);
            Console.WriteLine("Park In: " + vehicle.getParkIn());

            Console.WriteLine("-----------PARKOUT --------");

            DateTime parkOut;
            do
            {
                Console.Write("Parkout (MM/dd/yyyy HH:mm:ss tt): ");
            } while (!DateTime.TryParse(Console.ReadLine(), out parkOut));

            vehicle.setParkOut(parkOut);

            TimeSpan duration = vehicle.getTotalDuration();
            int totalHours = (int)Math.Ceiling(duration.TotalHours); 
            Console.WriteLine("Parking time: " + totalHours + " Hours");
            Console.WriteLine("Amount: $" + vehicle.calculatePrice(totalHours));
        }
    }

    // Base Vehicle class
    public class Vehicle
    {
        public string PlateNo { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public DateTime Parkout { get; set; }
        public int Additional { get; set; }
        public int FlagDown { get; set; }

        public Vehicle(string plateNo, string type, string brand, int additional, int flagDown)
        {
            PlateNo = plateNo;
            Type = type;
            Brand = brand;
            Additional = additional;
            FlagDown = flagDown;
        }

        public DateTime getParkIn()
        {
            return DateTime.Now;
        }

        public TimeSpan getTotalDuration() => Parkout - getParkIn();

        public void setParkOut(DateTime parkout) => Parkout = parkout;

        public int calculatePrice(int hours) => (hours * Additional) + FlagDown;
    }

    // Derived Motorcycle class
    class Motorcycle : Vehicle
    {
        public Motorcycle(string plateNo, string brand) : base(plateNo, "Motorcycle", brand, 5, 20)
        {
        }
    }

    // Derived SuvVan class
    class SuvVan : Vehicle
    {
        public SuvVan(string plateNo, string brand) : base(plateNo, "Suv/Van", brand, 20, 40)
        {
        }
    }

    // Derived Sedan class
    class Sedan : Vehicle
    {
        public Sedan(string plateNo, string brand) : base(plateNo, "Sedan", brand, 15, 30)
        {
        }
    }
}
