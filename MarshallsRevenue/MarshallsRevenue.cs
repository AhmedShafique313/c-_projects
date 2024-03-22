using System;

namespace MarshallsRevenue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Marshall's Revenue Calculator");

            // Prompt user for month number
            int monthNumber;
            do
            {
                Console.Write("Enter the month number (1-12): ");
            } while (!int.TryParse(Console.ReadLine(), out monthNumber) || monthNumber < 1 || monthNumber > 12);

            // Modify pricing based on month
            double interiorMuralPrice = GetInteriorMuralPrice(monthNumber);
            double exteriorMuralPrice = GetExteriorMuralPrice(monthNumber);

            // Prompt user for number of murals
            int interiorMurals, exteriorMurals;
            do
            {
                Console.Write("Enter the number of interior murals (0-30): ");
            } while (!int.TryParse(Console.ReadLine(), out interiorMurals) || interiorMurals < 0 || interiorMurals > 30);

            do
            {
                Console.Write("Enter the number of exterior murals (0-30): ");
            } while (!int.TryParse(Console.ReadLine(), out exteriorMurals) || exteriorMurals < 0 || exteriorMurals > 30);

            // Calculate subtotal and total revenue
            double interiorSubtotal = interiorMurals * interiorMuralPrice;
            double exteriorSubtotal = exteriorMurals * exteriorMuralPrice;
            double totalRevenue = interiorSubtotal + exteriorSubtotal;

            // Display results
            Console.WriteLine("\nRevenue Summary:");
            Console.WriteLine($"Number of Interior Murals: {interiorMurals}");
            Console.WriteLine($"Cost per Interior Mural: ${interiorMuralPrice}");
            Console.WriteLine($"Subtotal for Interior Murals: ${interiorSubtotal}");
            Console.WriteLine($"Number of Exterior Murals: {exteriorMurals}");
            Console.WriteLine($"Cost per Exterior Mural: ${exteriorMuralPrice}");
            Console.WriteLine($"Subtotal for Exterior Murals: ${exteriorSubtotal}");
            Console.WriteLine($"Total Expected Revenue: ${totalRevenue}");

            // Check if more interior murals are scheduled than exterior ones
            if (interiorMurals > exteriorMurals)
            {
                Console.WriteLine("More interior murals are scheduled than exterior ones.");
            }
            else if (exteriorMurals > interiorMurals)
            {
                Console.WriteLine("More exterior murals are scheduled than interior ones.");
            }
            else
            {
                Console.WriteLine("Equal number of interior and exterior murals are scheduled.");
            }
        }

        // Function to calculate interior mural price based on month
        static double GetInteriorMuralPrice(int monthNumber)
        {
            if (monthNumber == 7 || monthNumber == 8) // July or August
            {
                return 450;
            }
            else
            {
                return 500;
            }
        }

        // Function to calculate exterior mural price based on month
        static double GetExteriorMuralPrice(int monthNumber)
        {
            if (monthNumber >= 4 && monthNumber <= 5 || monthNumber >= 9 && monthNumber <= 10) // April, May, September, October
            {
                return 699;
            }
            else if (monthNumber >= 12 || monthNumber <= 2) // December through February
            {
                return 0; // No exterior murals
            }
            else
            {
                return 750;
            }
        }
    }
}
