
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using RailwayReservationSystem.Models;
using System.Configuration;

namespace RailwayReservationSystem.Services
{
    public class AdminService
    {
        private string connectionString;

        public AdminService()
        {
            connectionString = @"Server=ICS-LT-3TXLV44\SQLEXPRESS; Database=RailwayReservationSystem7; Integrated Security=True;";
        }

        public Admin LoginAdmin(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Admins WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Admin
                    {
                        AdminId = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2)
                    };
                }
                return null;
            }
        }

        public bool AddOrUpdateTrain(Train train)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "IF EXISTS (SELECT 1 FROM Trains WHERE TrainNo = @TrainNo AND ClassOfTravel = @ClassOfTravel) " +
                               "UPDATE Trains SET TrainName = @TrainName, FromStation = @FromStation, Destination = @Destination, " +
                               "Price = @Price, TrainStatus = @TrainStatus, SeatsAvailable = @SeatsAvailable " +
                               "WHERE TrainNo = @TrainNo AND ClassOfTravel = @ClassOfTravel " +
                               "ELSE " +
                               "INSERT INTO Trains (TrainNo, TrainName, FromStation, Destination, Price, ClassOfTravel, TrainStatus, SeatsAvailable) " +
                               "VALUES (@TrainNo, @TrainName, @FromStation, @Destination, @Price, @ClassOfTravel, @TrainStatus, @SeatsAvailable)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TrainNo", train.TrainNo);
                cmd.Parameters.AddWithValue("@TrainName", train.TrainName);
                cmd.Parameters.AddWithValue("@FromStation", train.FromStation);
                cmd.Parameters.AddWithValue("@Destination", train.Destination);
                cmd.Parameters.AddWithValue("@Price", train.Price);
                cmd.Parameters.AddWithValue("@ClassOfTravel", train.ClassOfTravel);
                cmd.Parameters.AddWithValue("@TrainStatus", train.TrainStatus);
                cmd.Parameters.AddWithValue("@SeatsAvailable", train.SeatsAvailable);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<Train> GetAllTrains()
        {
            List<Train> trains = new List<Train>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Trains";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    trains.Add(new Train
                    {
                        TrainNo = reader.GetInt32(0),
                        TrainName = reader.GetString(1),
                        FromStation = reader.GetString(2),
                        Destination = reader.GetString(3),
                        Price = reader.GetDecimal(4),
                        ClassOfTravel = reader.GetString(5),
                        TrainStatus = reader.GetString(6),
                        SeatsAvailable = reader.GetInt32(7)
                    });
                }
            }

            return trains;
        }

        public List<Booking> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Bookings";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bookings.Add(new Booking
                    {
                        BookingId = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        TrainNo = reader.GetInt32(2),
                        ClassOfTravel = reader.GetString(3),
                        SeatsBooked = reader.GetInt32(4),
                       
                    });
                }
            }

            return bookings;
        }

        public List<Cancellation> GetAllCancellations()
        {
            List<Cancellation> cancellations = new List<Cancellation>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cancellations";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cancellations.Add(new Cancellation
                    {
                        CancellationId = reader.GetInt32(0),
                        BookingId = reader.GetInt32(1),
                        SeatsCancelled = reader.GetInt32(2),
                        
                    });
                }
            }

            return cancellations;
        }
    }
}
