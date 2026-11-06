
using System;

abstract class ToolVehicle
{
    public int VehicleID { get; set; }
    public string RegNo { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal BasePrice { get; set; }
    public string VehicleType { get; set; } = string.Empty;

    public static int TotalVehicles { get; private set; }
    public static int TotalTaxPayingVehicles { get; private set; }
    public static int TotalNonTaxPayingVehicles { get; private set; }
    public static decimal TotalTaxCollected { get; private set; }

    public ToolVehicle(int id, string regNo, string model,
        string brand, decimal price, string type)
    {
        VehicleID = id;
        RegNo = regNo;
        Model = model;
        Brand = brand;
        BasePrice = price;
        VehicleType = type;

        TotalVehicles++;
    }

    public abstract void PayTax();

    protected void CollectTax(decimal tax)
    {
        TotalTaxCollected += tax;
        TotalTaxPayingVehicles++;

        Console.WriteLine(RegNo + " paid tax: $" + tax);
    }

    public void PassWithoutPaying()
    {
        TotalNonTaxPayingVehicles++;

        Console.WriteLine(RegNo + " passed without paying tax.");
    }

    public void DisplayInfo()
    {
        Console.WriteLine("\nVehicle ID: " + VehicleID);
        Console.WriteLine("Registration: " + RegNo);
        Console.WriteLine("Model: " + Model);
        Console.WriteLine("Brand: " + Brand);
        Console.WriteLine("Base Price: $" + BasePrice);
        Console.WriteLine("Vehicle Type: " + VehicleType);
    }
}

class Car : ToolVehicle
{
    public Car(int id, string reg, string model,
        string brand, decimal price)
        : base(id, reg, model, brand, price, "Car")
    {
    }

    public override void PayTax()
    {
        CollectTax(2m);
    }
}

class Bike : ToolVehicle
{
    public Bike(int id, string reg, string model,
        string brand, decimal price)
        : base(id, reg, model, brand, price, "Bike")
    {
    }

    public override void PayTax()
    {
        CollectTax(1m);
    }
}

class HeavyVehicle : ToolVehicle
{
    public HeavyVehicle(int id, string reg, string model,
        string brand, decimal price)
        : base(id, reg, model, brand, price, "Heavy Vehicle")
    {
    }

    public override void PayTax()
    {
        CollectTax(4m);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("================================");
        Console.WriteLine(" TOOL VEHICLE TAX MANAGEMENT");
        Console.WriteLine("================================");

        Car car1 = new Car(1, "ABC-123", "Corolla",
            "Toyota", 25000m);

        Bike bike1 = new Bike(2, "XYZ-456", "CD70",
            "Honda", 1500m);

        HeavyVehicle truck1 = new HeavyVehicle(3,
            "TRK-789", "Truck", "Volvo", 80000m);

        Car car2 = new Car(4, "ABC-444", "Civic",
            "Honda", 30000m);

        Console.WriteLine("\n===== VEHICLE DETAILS =====");

        car1.DisplayInfo();
        bike1.DisplayInfo();
        truck1.DisplayInfo();
        car2.DisplayInfo();

        Console.WriteLine("\n===== TAX PAYMENTS =====");

        car1.PayTax();
        bike1.PayTax();
        truck1.PayTax();

        Console.WriteLine("\n===== WITHOUT TAX =====");

        car2.PassWithoutPaying();

        Console.WriteLine("\n===== FINAL TAX REPORT =====");

        Console.WriteLine("Total Vehicles: " +
            ToolVehicle.TotalVehicles);

        Console.WriteLine("Tax Paying Vehicles: " +
            ToolVehicle.TotalTaxPayingVehicles);

        Console.WriteLine("Non-Tax Paying Vehicles: " +
            ToolVehicle.TotalNonTaxPayingVehicles);

        Console.WriteLine("Total Tax Collected: $" +
            ToolVehicle.TotalTaxCollected);

        Console.WriteLine("\n================================");
        Console.WriteLine(" PROGRAM ENDED");
        Console.WriteLine("================================");

        Console.ReadKey();
    }
}

