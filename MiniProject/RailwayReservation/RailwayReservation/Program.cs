using System;
using System.Data.SqlClient;

namespace RailwayReservationSystem
{
    class Program
    {
       
        static string connectionString = "Server=ICS-LT-3TXLV44\\SQLEXPRESS;Database=prakruthi;Integrated Security=True;";


        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Welcome to the Railway Reservation System");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. User");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                    AdminPanel();
                else if (choice == "2")
                    UserPanel();
                else if (choice == "3")
                    break;
                else
                    Console.WriteLine("Invalid choice, try again.");
            }
        }

        // Admin Panel
        static void AdminPanel()
        {
            while (true)
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. Add Trains");
                Console.WriteLine("2. Modify Trains");
                Console.WriteLine("3. Delete Trains");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                    AddTrain();
                else if (choice == "2")
                    ModifyTrain();
                else if (choice == "3")
                    DeleteTrain();
                else if (choice == "4")
                    break;
                else
                    Console.WriteLine("Invalid choice, try again.");
            }
        }

        static void AddTrain()
        {
            Console.Write("Enter Train No: ");
            int trainNo = int.Parse(Console.ReadLine());
            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();
            Console.Write("Enter Class (1st, 2nd, Sleeper): ");
            string trainClass = Console.ReadLine();
            Console.Write("Enter Total Berths: ");
            int totalBerths = int.Parse(Console.ReadLine());
            Console.Write("Enter Source: ");
            string source = Console.ReadLine();
            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Trains (TrainNo, TrainName, Class, TotalBerths, AvailableBerths, Source, Destination, IsActive) " +
                               "VALUES (@TrainNo, @TrainName, @Class, @TotalBerths, @TotalBerths, @Source, @Destination, 1)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                cmd.Parameters.AddWithValue("@TrainName", trainName);
                cmd.Parameters.AddWithValue("@Class", trainClass);
                cmd.Parameters.AddWithValue("@TotalBerths", totalBerths);
                cmd.Parameters.AddWithValue("@Source", source);
                cmd.Parameters.AddWithValue("@Destination", destination);

                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Train added successfully.");
        }

        static void ModifyTrain()
        {
            Console.Write("Enter Train No to modify: ");
            int trainNo = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Trains WHERE TrainNo = @TrainNo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrainNo", trainNo);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    Console.Write("Enter new Train Name (leave blank to keep the same): ");
                    string newTrainName = Console.ReadLine();
                    if (string.IsNullOrEmpty(newTrainName))
                        newTrainName = reader["TrainName"].ToString();

                    Console.Write("Enter new Class (leave blank to keep the same): ");
                    string newClass = Console.ReadLine();
                    if (string.IsNullOrEmpty(newClass))
                        newClass = reader["Class"].ToString();

                    Console.Write("Enter new Total Berths (leave blank to keep the same): ");
                    string totalBerthsInput = Console.ReadLine();
                    int newTotalBerths = string.IsNullOrEmpty(totalBerthsInput) ? (int)reader["TotalBerths"] : int.Parse(totalBerthsInput);

                    string updateQuery = "UPDATE Trains SET TrainName = @TrainName, Class = @Class, TotalBerths = @TotalBerths WHERE TrainNo = @TrainNo";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@TrainName", newTrainName);
                    updateCmd.Parameters.AddWithValue("@Class", newClass);
                    updateCmd.Parameters.AddWithValue("@TotalBerths", newTotalBerths);
                    updateCmd.Parameters.AddWithValue("@TrainNo", trainNo);

                    updateCmd.ExecuteNonQuery();
                    Console.WriteLine("Train updated successfully.");
                }
                else
                {
                    Console.WriteLine("Train not found.");
                }
            }
        }

        static void DeleteTrain()
        {
            Console.Write("Enter Train No to delete (soft delete): ");
            int trainNo = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Trains SET IsActive = 0 WHERE TrainNo = @TrainNo";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Train marked as inactive.");
        }

        static void UserPanel()
        {
            while (true)
            {
                Console.WriteLine("\nUser Menu:");
                Console.WriteLine("1. Book Tickets");
                Console.WriteLine("2. Cancel Tickets");
                Console.WriteLine("3. Show All Trains");
                Console.WriteLine("4. Show Booking");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                    BookTickets();
                else if (choice == "2")
                    CancelTickets();
                else if (choice == "3")
                    ShowAllTrains();
                else if (choice == "4")
                    ShowBookingHistory();
                else if (choice == "5")
                    break;
                else
                    Console.WriteLine("Invalid choice, try again.");
            }
        }

        static void BookTickets()
        {
            Console.Write("Enter Train No to book: ");
            int trainNo = int.Parse(Console.ReadLine());

            Console.Write("Enter your Name: ");
            string userName = Console.ReadLine();

            Console.Write("Enter number of seats to book: ");
            int seatsToBook = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Trains WHERE TrainNo = @TrainNo AND IsActive = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrainNo", trainNo);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int availableBerths = (int)reader["AvailableBerths"];
                    if (availableBerths >= seatsToBook)
                    {
                        reader.Close();
                        string updateQuery = "UPDATE Trains SET AvailableBerths = AvailableBerths - @SeatsBooked WHERE TrainNo = @TrainNo";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@SeatsBooked", seatsToBook);
                        updateCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                        updateCmd.ExecuteNonQuery();

                        string bookingQuery = "INSERT INTO Bookings (TrainNo, UserName, SeatsBooked, BookingDate) " +
                                              "VALUES (@TrainNo, @UserName, @SeatsBooked, GETDATE())";
                        SqlCommand bookingCmd = new SqlCommand(bookingQuery, conn);
                        bookingCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                        bookingCmd.Parameters.AddWithValue("@UserName", userName);
                        bookingCmd.Parameters.AddWithValue("@SeatsBooked", seatsToBook);
                        bookingCmd.ExecuteNonQuery();

                        Console.WriteLine("Booking successful.");
                    }
                    else
                    {
                        Console.WriteLine("Not enough available seats.");
                    }
                }
                else
                {
                    Console.WriteLine("Train is not active or doesn't exist.");
                }
            }
        }

        static void CancelTickets()
        {
            Console.Write("Enter Booking ID to cancel: ");
            int bookingId = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Bookings WHERE BookingID = @BookingID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int trainNo = (int)reader["TrainNo"];
                    int seatsBooked = (int)reader["SeatsBooked"];
                    reader.Close();

                    string updateTrainQuery = "UPDATE Trains SET AvailableBerths = AvailableBerths + @SeatsBooked WHERE TrainNo = @TrainNo";
                    SqlCommand updateTrainCmd = new SqlCommand(updateTrainQuery, conn);
                    updateTrainCmd.Parameters.AddWithValue("@SeatsBooked", seatsBooked);
                    updateTrainCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                    updateTrainCmd.ExecuteNonQuery();

                    string cancelQuery = "DELETE FROM Bookings WHERE BookingID = @BookingID";
                    SqlCommand cancelCmd = new SqlCommand(cancelQuery, conn);
                    cancelCmd.Parameters.AddWithValue("@BookingID", bookingId);
                    cancelCmd.ExecuteNonQuery();

                    Console.WriteLine("Booking cancelled successfully.");
                }
                else
                {
                    Console.WriteLine("Booking ID not found.");
                }
            }
        }

        static void ShowAllTrains()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Trains WHERE IsActive = 1";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\nActive Trains:");
                while (reader.Read())
                {
                    Console.WriteLine($"Train No: {reader["TrainNo"]}, Name: {reader["TrainName"]}, Class: {reader["Class"]}, Available Berths: {reader["AvailableBerths"]}, Source: {reader["Source"]}, Destination: {reader["Destination"]}");
                }
            }
        }

        static void ShowBookingHistory()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Bookings";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\nBooking History:");
                while (reader.Read())
                {
                    Console.WriteLine($"Booking ID: {reader["BookingID"]}, Train No: {reader["TrainNo"]}, User Name: {reader["UserName"]}, Seats Booked: {reader["SeatsBooked"]}, Date: {reader["BookingDate"]}");
                }
            }
        }
    }
}
