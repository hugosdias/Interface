using System.Globalization;
using dotnet.Entities;
using dotnet.Services;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter Rental Data");
        Console.Write("Car Model: ");
        string model = Console.ReadLine();
        Console.Write("Pickup (dd/MM/yyyy hh:ss): ");
        DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        Console.Write("Return (dd/MM/yyyy hh:ss): ");
        DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

        Console.Write("Enter pricer per hour: ");
        double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter price per day: ");
        double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        CarRental carRental = new CarRental(start, finish, new Vehicle(model));

        RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());

        rentalService.ProcessInvoice(carRental);

        System.Console.WriteLine("INOIVCE: ");
        System.Console.WriteLine(carRental.Invoice);
    }
}

//teste