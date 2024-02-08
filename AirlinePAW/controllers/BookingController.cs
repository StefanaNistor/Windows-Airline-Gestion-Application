using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using AirlinePAW.classes;
using System.Xml.Serialization;
using System.IO;

namespace AirlinePAW.controllers
{
    [Serializable]
    public class BookingController
    {
        private string ConnectionString = "Data Source=C:\\Users\\User\\Desktop\\PAW Project\\AirlinePAW\\AirlinePAW\\database.db";
        public BookingController() { }

        //get all bookings of a user
        public List<Booking> GetAllBookingsOfUser(string username)
        {
            //get the booking with booking_id, noof people and route origin from booking table and route table where the username matches
            List<Booking> bookings = new List<Booking>();

            var query = "SELECT b.booking_id, b.no_people, r.origin, r.destination " +
                        "FROM Booking b " +
                        "JOIN Route r ON b.route_id = r.route_id " +
                        "JOIN User u ON b.user_id = u.user_id " +
                        "WHERE u.username = @username";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking();
                            booking.BookingId = Convert.ToInt32(reader["booking_id"]);
                            booking.NoPeople = Convert.ToInt32(reader["no_people"]);
                            booking.Route.Origin = reader["origin"].ToString();
                            booking.Route.Destination = reader["destination"].ToString();
                            bookings.Add(booking);
                        }
                    }
                }
            }
            
            return bookings;
        }

        //get all bookings
        public List<Booking> GetAllBoookings()
        {
            List<Booking> bookings = new List<Booking>();
            var query = "SELECT u.username, b.booking_id, b.no_people, r.origin, r.destination " +
            "FROM Booking b JOIN User u ON b.user_id = u.user_id " +
            "JOIN Route r ON b.route_id = r.route_id ";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking();
                            booking.BookingId = Convert.ToInt32(reader["booking_id"]);
                            booking.NoPeople = Convert.ToInt32(reader["no_people"]);
                            booking.Route.Origin = reader["origin"].ToString();
                            booking.Route.Destination = reader["destination"].ToString();
                            booking.User.Username = reader["username"].ToString();
                            bookings.Add(booking);
                        }
                    }
                }
            }
            return bookings;
        }

        //add booking
        public void AddBooking(Booking booking)
        {
         
                var query = "INSERT INTO Booking (no_people, route_id, user_id) VALUES (@no_people, @route_id, @user_id)";
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                        command.Parameters.AddWithValue("@no_people", booking.NoPeople);
                        command.Parameters.AddWithValue("@route_id", booking.Route.RouteId);
                        command.Parameters.AddWithValue("@user_id", booking.User.UserId);
                        command.ExecuteNonQuery();
                    }
                }
        }

        //create booking
        public Booking CreateBooking(User user, int routeId, int noPeople)
        {
            Booking booking = new Booking();
            booking.User = user;
            booking.Route.RouteId = routeId;
            booking.NoPeople = noPeople;
            return booking;
        }

        //delete booking
        public void DeleteBooking(int bookingId)
        {
            var query = "DELETE FROM Booking WHERE booking_id = @booking_id";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@booking_id", bookingId);
                    command.ExecuteNonQuery();
                }
            }
        }

        //get booking by id
        public Booking GetBookingById(int bookingId)
        {
            Booking booking = new Booking();
            var query = "SELECT b.booking_id, b.no_people, r.origin, r.destination " +
                        "FROM Booking b " +
                        "JOIN Route r ON b.route_id = r.route_id " +
                        "WHERE b.booking_id = @booking_id";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@booking_id", bookingId);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            booking.BookingId = Convert.ToInt32(reader["booking_id"]);
                            booking.NoPeople = Convert.ToInt32(reader["no_people"]);
                            booking.Route.Origin = reader["origin"].ToString();
                            booking.Route.Destination = reader["destination"].ToString();
                        }
                    }
                }
            }
            return booking;
        }

        //update booking
        public void UpdateBooking(Booking booking)
        {
            var query = "UPDATE Booking SET no_people = @no_people, route_id = @route_id, user_id = @user_id WHERE booking_id = @booking_id";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@no_people", booking.NoPeople);
                    command.Parameters.AddWithValue("@route_id", booking.Route.RouteId);
                    command.Parameters.AddWithValue("@user_id", booking.User.UserId);
                    command.Parameters.AddWithValue("@booking_id", booking.BookingId);
                    command.ExecuteNonQuery();
                }
            }
        }

        //serialize and deserialize bookings
        public void SerializeBookings(List<Booking> bookings)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Booking>));
            using (FileStream stream = File.OpenWrite("bookings.xml"))
            {
                serializer.Serialize(stream, bookings);
            }
        }

        public List<Booking> DeserializeBookings()
        {
            List<Booking> bookings = new List<Booking>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Booking>));
            using (FileStream stream = File.OpenRead("bookings.xml"))
            {
                bookings = (List<Booking>)serializer.Deserialize(stream);
            }
            return bookings;
        }

        //get all bookings
        public List<Booking> GetAllBookings()
        {
            List<Booking> bookings = new List<Booking>();
            var query = "SELECT b.booking_id, b.no_people, r.origin, r.destination " +
                        "FROM Booking b " +
                        "JOIN Route r ON b.route_id = r.route_id ";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Booking booking = new Booking();
                            booking.BookingId = Convert.ToInt32(reader["booking_id"]);
                            booking.NoPeople = Convert.ToInt32(reader["no_people"]);
                            booking.Route.Origin = reader["origin"].ToString();
                            booking.Route.Destination = reader["destination"].ToString();
                            bookings.Add(booking);
                        }
                    }
                }
            }
            return bookings;
        }

    }
}
