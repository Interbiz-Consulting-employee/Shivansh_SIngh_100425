using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagementSystem.Models
{
    public class Address
    {
        private int blockNo;
        private int streetNo;
        private string area;
        private string city;
        private string state;
        private int pincode;

        public Address() { }

        public Address(int blockNo, int streetNo, string area, string city, string state, int pincode)
        {
            this.blockNo = blockNo;
            this.streetNo = streetNo;
            this.area = area;
            this.city = city;
            this.state = state;
            this.pincode = pincode;
        }

        public void SetAddressDetails()
        {
            try
            {
                Console.WriteLine("Enter Address");

                while (true)
                {
                    Console.Write("Enter Block No: ");
                    if (int.TryParse(Console.ReadLine(), out blockNo) && blockNo > 0)
                        break;
                    Console.WriteLine("Invalid Block No.");
                }

                while (true)
                {
                    Console.Write("Enter Street No: ");
                    if (int.TryParse(Console.ReadLine(), out streetNo) && streetNo > 0)
                        break;
                    Console.WriteLine("Invalid Street No.");
                }

                while (true)
                {
                    Console.Write("Enter Area: ");
                    area = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(area))
                        break;
                    Console.WriteLine("Area required.");
                }

                while (true)
                {
                    Console.Write("Enter City: ");
                    city = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(city))
                        break;
                    Console.WriteLine("City required.");
                }

                while (true)
                {
                    Console.Write("Enter State: ");
                    state = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(state))
                        break;
                    Console.WriteLine("State required.");
                }

                while (true)
                {
                    Console.Write("Enter Pincode: ");
                    if (int.TryParse(Console.ReadLine(), out pincode) &&
                        pincode >= 100000 && pincode <= 999999)
                        break;
                    Console.WriteLine("Invalid Pincode.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred while entering address details.");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public int GetPincode() => pincode;
        public String GetCity() => city;
        public String GetState() => state;
        public String GetArea() => area;
        public void ShowAddress()
        {
            Console.WriteLine("\nAddress:");
            Console.WriteLine($"Block No  : {blockNo}");
            Console.WriteLine($"Street No : {streetNo}");
            Console.WriteLine($"Area      : {area}");
            Console.WriteLine($"City      : {city}");
            Console.WriteLine($"State     : {state}");
            Console.WriteLine($"Pincode   : {pincode}");
        }
    }
}
