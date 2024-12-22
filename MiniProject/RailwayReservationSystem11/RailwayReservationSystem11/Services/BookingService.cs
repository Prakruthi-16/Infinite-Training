using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace RailwayReservationSystem.Services
{
    public class BookingService
    {
        private string connectionString;

        public BookingService()
        {
            connectionString = @"Server=ICS-LT-3TXLV44\SQLEXPRESS; Database=RailwayReservationSystem6; Integrated Security=True;";
        }

        public bool BookTickets(int userId, int trainNo, string classOfTravel, int seatsBooked)
        {
            if (seatsBooked > 3)
            {
                Console.WriteLine("You can only book a maximum of 3 tickets at a time.");
                return false;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // First, check if the train is active and has enough seats available
                string checkTrainStatusQuery = "SELECT TrainStatus, SeatsAvailable " +
                                               "FROM Trains " +
                                               "WHERE TrainNo = @TrainNo AND ClassOfTravel = @ClassOfTravel";
                SqlCommand checkCmd = new SqlCommand(checkTrainStatusQuery, conn);
                checkCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                checkCmd.Parameters.AddWithValue("@ClassOfTravel", classOfTravel);

                SqlDataReader reader = checkCmd.ExecuteReader();
                if (reader.Read())
                {
                    string trainStatus = reader.GetString(0);
                    int seatsAvailable = reader.GetInt32(1);

                    // Check if the train is active and has enough seats
                    if (trainStatus != "active" || seatsAvailable < seatsBooked)
                    {
                        return false; // Train is not active or not enough seats available
                    }
                }
                else
                {
                    return false; // Train not found
                }
                reader.Close();

                // If the train is active and has enough seats, proceed with booking
                string bookTicketsQuery = "INSERT INTO Bookings (UserId, TrainNo, ClassOfTravel, SeatsBooked, BookingDate) " +
                                          "VALUES (@UserId, @TrainNo, @ClassOfTravel, @SeatsBooked, @BookingDate);" +
                                          "UPDATE Trains SET SeatsAvailable = SeatsAvailable - @SeatsBooked " +
                                          "WHERE TrainNo = @TrainNo AND ClassOfTravel = @ClassOfTravel";
                SqlCommand bookCmd = new SqlCommand(bookTicketsQuery, conn);
                bookCmd.Parameters.AddWithValue("@UserId", userId);
                bookCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                bookCmd.Parameters.AddWithValue("@ClassOfTravel", classOfTravel);
                bookCmd.Parameters.AddWithValue("@SeatsBooked", seatsBooked);
                bookCmd.Parameters.AddWithValue("@BookingDate", DateTime.Now);

                int rowsAffected = bookCmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool CancelTickets(int bookingId, int seatsCancelled)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Cancel tickets and update train seats
                string cancelTicketsQuery = "INSERT INTO Cancellations (BookingId, SeatsCancelled, CancellationDate) " +
                                            "VALUES (@BookingId, @SeatsCancelled, @CancellationDate);" +
                                            "UPDATE Bookings SET SeatsBooked = SeatsBooked - @SeatsCancelled WHERE BookingId = @BookingId;" +
                                            "UPDATE Trains SET SeatsAvailable = SeatsAvailable + @SeatsCancelled " +
                                            "WHERE TrainNo = (SELECT TrainNo FROM Bookings WHERE BookingId = @BookingId) " +
                                            "AND ClassOfTravel = (SELECT ClassOfTravel FROM Bookings WHERE BookingId = @BookingId)";
                SqlCommand cancelCmd = new SqlCommand(cancelTicketsQuery, conn);
                cancelCmd.Parameters.AddWithValue("@BookingId", bookingId);
                cancelCmd.Parameters.AddWithValue("@SeatsCancelled", seatsCancelled);
                cancelCmd.Parameters.AddWithValue("@CancellationDate", DateTime.Now);

                int rowsAffected = cancelCmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}