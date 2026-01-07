using StudentManagementSystem.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace StudentManagementSystem.Models
{
    public class Address
    {
        private int _blockNo;
        private int _streetNo;
        private string _area;
        private string _city;
        private string _state;
        private int _pincode;

        public Address() { }

        public Address(int blockNo, int streetNo, string area, string city, string state, int pincode)
        {
            _blockNo = blockNo;
            _streetNo = streetNo;
            _area = area;
            _city = city;
            _state = state;
            _pincode = pincode;

            ValidateAddress();
        }

        public void SetAddressDetails()
        {
            try { 
            Console.WriteLine("\nEnter Address");

            _blockNo = ReadPositiveInt("Enter Block No: ");
            _streetNo = ReadPositiveInt("Enter Street No: ");
            _area = ReadText1("Enter Area: ");
            _city = ReadText1("Enter City: ");
            _state = ReadText2("Enter State: ");
            _pincode = ReadPincode("Enter Pincode: ");

            ValidateAddress();
            }
            catch (StudentValidationException ex)
            {
                Console.WriteLine("Address validation failed:");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error while entering address.");
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        

        private void ValidateAddress()
        {
            if (_pincode < 100000 || _pincode > 999999)
                throw new StudentValidationException("Pincode must be exactly 6 digits.");

            if (string.IsNullOrWhiteSpace(_city))
                throw new StudentValidationException("City cannot be empty.");

            if (string.IsNullOrWhiteSpace(_state))
                throw new StudentValidationException("State cannot be empty.");
        }

        private bool IsValidText(string input)
        {
            return !string.IsNullOrWhiteSpace(input) &&
                   Regex.IsMatch(input, @"^[A-Za-z0-9]+([\s-]+[A-Za-z0-9]+)*$")
;
        }
        private bool IsValidText2(string input)
        {
            return !string.IsNullOrWhiteSpace(input) &&
                   Regex.IsMatch(input, @"^[A-Za-z ]+$")
;
        }

        private int ReadPositiveInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
                    return value;

                Console.WriteLine("Enter a positive number.");
            }
        }
        private string ReadText1(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (IsValidText(input))
                    return input.Trim();

                Console.WriteLine("put valid name");
            }
        }
        private string ReadText2(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (IsValidText2(input))
                    return input.Trim();

                Console.WriteLine("put valid name");
            }
        }

        private int ReadPincode(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int pin) &&
                    pin >= 100000 && pin <= 999999)
                    return pin;

                Console.WriteLine("Pincode must be 6 digits.");
            }
        }

        //Get

        public int GetPincode => _pincode;
        public string GetCity => _city;
        public string GetState => _state;
        public string GetArea => _area;

        public void ShowAddress()
        {
            Console.WriteLine("\nAddress:");
            Console.WriteLine($"Block No  : {_blockNo}");
            Console.WriteLine($"Street No : {_streetNo}");
            Console.WriteLine($"Area      : {_area}");
            Console.WriteLine($"City      : {_city}");
            Console.WriteLine($"State     : {_state}");
            Console.WriteLine($"Pincode   : {_pincode}");
        }
    }
}
