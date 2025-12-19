using System;

namespace ExceptionHandlingPractice
{
    internal class ExceptionHandlingTask
    {
        public static void Main()
        {
            TicketBookingSystem t = new TicketBookingSystem();
            Console.WriteLine("Movies Available: " + t.MovieName);

            try
            {
                Console.Write("Enter number of tickets to book: ");
                int ticketsToBook = int.Parse(Console.ReadLine());

                t.BookTickets(ticketsToBook);
            }
            catch (TicketsHandlingException ex)
            {
                Console.WriteLine("Booking failed: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a numeric value.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
    }

    class TicketBookingSystem
    {
        public int Tickets { get; set; }
        public string MovieName { get; set; }

        public TicketBookingSystem()
        {
            MovieName = "Dhurandar";
            Tickets = 50;
        }

        public void BookTickets(int number)
        {
            if (number <= Tickets)
            {
                Tickets -= number;
                Console.WriteLine(number + " tickets booked successfully!");
                Console.WriteLine("Remaining tickets: " + Tickets);
            }
            else
            {
                throw new TicketsHandlingException("Only " + Tickets + " tickets available. Cannot book " + number + " tickets.");
            }
        }
    }

    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    class TicketsHandlingException : Exception
    {
        public TicketsHandlingException(string message) : base(message) { }
    }
}
