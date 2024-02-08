using AirlinePAW.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace AirlinePAW.controllers
{

    internal class RouteController
    {
        private string ConnectionString = "Data Source=C:\\Users\\User\\Desktop\\PAW Project\\AirlinePAW\\AirlinePAW\\database.db";
        public RouteController() { }

        //get all routes from database
        public List<Route> GetAllRoutes()
        {
            List<Route> routes = new List<Route>();
            var query = "SELECT r.*, c.company_name FROM Route r, Company c WHERE r.company_id=c.company_id";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Route route = new Route();
                            route.RouteId = Convert.ToInt32(reader["route_id"]);
                            route.Origin = reader["origin"].ToString();
                            route.Destination = reader["destination"].ToString();
                            route.Distance = Convert.ToDouble(reader["distance"]);
                            route.Company.company_name = reader["company_name"].ToString();
                            routes.Add(route);
                        }
                    }
                }
            }
            return routes;
        }

        // add a new route to the database
        public void AddRoute(Route route)
        {
            var query = "INSERT INTO Route (origin, destination, distance, company_id) VALUES (@origin, @destination, @distance, @company_id)";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@origin", route.Origin);
                    command.Parameters.AddWithValue("@destination", route.Destination);
                    command.Parameters.AddWithValue("@distance", route.Distance);
                    command.Parameters.AddWithValue("@company_id", route.Company.company_id);
                    command.ExecuteNonQuery();
                }
            }
        }

        //delete a route from the database
        public void DeleteRoute(int routeId)
        {
            var query = "DELETE FROM Route WHERE route_id=@route_id";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@route_id", routeId);
                    command.ExecuteNonQuery();
                }
            }
        }

        //update a route in the database
        public void UpdateRoute(Route route)
        {
            var query = "UPDATE Route SET origin=@origin, destination=@destination, distance=@distance, company_id=@company_id WHERE route_id=@route_id";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@route_id", route.RouteId);
                    command.Parameters.AddWithValue("@origin", route.Origin);
                    command.Parameters.AddWithValue("@destination", route.Destination);
                    command.Parameters.AddWithValue("@distance", route.Distance);
                    command.Parameters.AddWithValue("@company_id", route.Company.company_id);
                    command.ExecuteNonQuery();
                }
            }
        }

        //method to get a route by id
        public Route GetRouteById(int routeId)
        {
            Route route = new Route();
            var query = "SELECT r.*, c.company_name FROM Route r, Company c WHERE r.company_id=c.company_id AND route_id=@route_id";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@route_id", routeId);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            route.RouteId = Convert.ToInt32(reader["route_id"]);
                            route.Origin = reader["origin"].ToString();
                            route.Destination = reader["destination"].ToString();
                            route.Distance = Convert.ToDouble(reader["distance"]);
                            route.Company.company_name = reader["company_name"].ToString();
                        }
                    }
                }
            }
            return route;
        }
    }
}
