using RailwayReservationSystem.Models;
using RailwayReservationSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RailwayReservationSystem
{
    class Program
    {
        static UserService userService = new UserService();
        static AdminService adminService = new AdminService();
        static BookingService bookingService = new BookingService();

        static void Main(string[] args)
        {
            Console.WriteLine("*****Welcome to Railway Reservation System*****");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Are you a Admin or User? (enter 'A' for Admin or 'U' for User)");
            string role = Console.ReadLine();

            if (role.ToLower() == "1")
            {
                AdminLogin();
            }
            else if (role.ToLower() == "2")
            {
                UserOptions();
            }
            else
            {
                Console.WriteLine("Invalid option. Exiting...");
            }
        }

        static void AdminLogin()
        {
            Console.WriteLine("Enter admin username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter admin password:");
            string password = Console.ReadLine();

            Admin admin = adminService.LoginAdmin(username, password);
            if (admin != null)
            {
                Console.WriteLine("Admin logged in successfully.");
                AdminOptions();
            }
            else
            {
                Console.WriteLine("Invalid admin credentials...");
                Console.ReadLine();
            }
        }

        static void AdminOptions()
        {
            while (true)
            {
                Console.WriteLine("1. Add or Update Train");
                Console.WriteLine("2. View All Trains");
                Console.WriteLine("3. View All Bookings");
                Console.WriteLine("4. View All Cancellations");
                Console.WriteLine("5. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddOrUpdateTrain();
                        break;
                    case "2":
                        ViewAllTrains();
                        break;
                    case "3":
                        ViewAllBookings();
                        break;
                    case "4":
                        ViewAllCancellations();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void AddOrUpdateTrain()
        {
            Console.WriteLine("Enter Train Number:");
            int trainNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Train Name:");
            string trainName = Console.ReadLine();
            Console.WriteLine("Enter From Station:");
            string fromStation = Console.ReadLine();
            Console.WriteLine("Enter Destination:");
            string destination = Console.ReadLine();
            Console.WriteLine("Enter Price:");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Class of Travel:");
            string classOfTravel = Console.ReadLine();
            Console.WriteLine("Enter Train Status (active/inactive):");
            string trainStatus = Console.ReadLine();
            Console.WriteLine("Enter Seats Available:");
            int seatsAvailable = int.Parse(Console.ReadLine());

            Train train = new Train
            {
                TrainNo = trainNo,
                TrainName = trainName,
                FromStation = fromStation,
                Destination = destination,
                Price = price,
                ClassOfTravel = classOfTravel,
                TrainStatus = trainStatus,
                SeatsAvailable = seatsAvailable
            };

            bool isTrainAdded = adminService.AddOrUpdateTrain(train);
            if (isTrainAdded)
            {
                Console.WriteLine("Train added or updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add or update train.");
            }
        }

        static void ViewAllTrains()
        {
            List<Train> trains = adminService.GetAllTrains();
            foreach (var train in trains)
            {
                Console.WriteLine($"TrainNo: {train.TrainNo}, TrainName: {train.TrainName}, From: {train.FromStation}, To: {train.Destination}, Price: {train.Price}, Class: {train.ClassOfTravel}, Status: {train.TrainStatus}, Seats: {train.SeatsAvailable}");
            }
        }

        static void ViewAllBookings()
        {
            List<Booking> bookings = adminService.GetAllBookings();
            foreach (var booking in bookings)
            {
                Console.WriteLine($"BookingId: {booking.BookingId}, UserId: {booking.UserId}, TrainNo: {booking.TrainNo}, ClassOfTravel: {booking.ClassOfTravel}, SeatsBooked: {booking.SeatsBooked}, BookingDate: {booking.BookingDate}");
            }
        }

        static void ViewAllCancellations()
        {
            List<Cancellation> cancellations = adminService.GetAllCancellations();
            foreach (var cancellation in cancellations)
            {
                Console.WriteLine($"CancellationId: {cancellation.CancellationId}, BookingId: {cancellation.BookingId}, SeatsCancelled: {cancellation.SeatsCancelled}, CancellationDate: {cancellation.CancellationDate}");
            }
        }

        static void UserOptions()
        {
            Console.WriteLine("Do you want to login or register? (enter '1' to Login or '2' to Register)");
            string option = Console.ReadLine();

            if (option.ToLower() == "1")
            {
                UserLogin();
            }
            else if (option.ToLower() == "2")
            {
                UserRegister();
            }
            else
            {
                Console.WriteLine("Invalid option. Exiting...");
                Console.ReadLine();
            }
        }

        static void UserRegister()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            User newUser = new User
            {
                Name = name,
                Username = username,
                Password = password
            };

            bool isUserRegistered = userService.RegisterUser(newUser);
            if (isUserRegistered)
            {
                Console.WriteLine("User registered successfully.");
            }
            else
            {
                Console.WriteLine("Failed to register user.");
            }
        }

        static void UserLogin()
        {
            Console.WriteLine("Enter your username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            User user = userService.LoginUser(username, password);
            if (user != null)
            {
                Console.WriteLine("User logged in successfully.");
                UserBookingOptions(user);
            }
            else
            {
                Console.WriteLine("Invalid user credentials.");
                Console.ReadLine();
            }
        }

        static void UserBookingOptions(User user)
        {
            while (true)
            {
                Console.WriteLine("1. View Trains");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. Cancel Tickets");
                Console.WriteLine("4. Exit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllTrains();
                        break;
                    case "2":
                        BookTickets(user);
                        break;
                    case "3":
                        CancelTickets();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void BookTickets(User user)
        {
            Console.WriteLine("Enter Train Number:");
            int trainNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Class of Travel:");
            string classOfTravel = Console.ReadLine();
            Console.WriteLine("Enter Number of Seats:");
            int seatsBooked = int.Parse(Console.ReadLine());

            bool isTicketBooked = bookingService.BookTickets(user.UserId, trainNo, classOfTravel, seatsBooked);
            if (isTicketBooked)
            {
                Console.WriteLine("Tickets booked successfully.");
            }
            else
            {
                Console.WriteLine("Train Inactive, Failed to book tickets.");
            }
        }



        static void CancelTickets()
        {
            Console.WriteLine("Enter Booking ID:");
            int bookingId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Number of Seats to Cancel:");
            int seatsCancelled = int.Parse(Console.ReadLine());

            bool isTicketCancelled = bookingService.CancelTickets(bookingId, seatsCancelled);
            if (isTicketCancelled)
            {
                Console.WriteLine("Tickets cancelled successfully.");
            }
            else
            {
                Console.WriteLine("Failed to cancel tickets.");
            }
        }
    }
}