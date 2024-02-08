using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using AirlinePAW.classes;

namespace AirlinePAW.controllers
{
    public class CompanyController
    {
        private string ConnectionString = "Data Source=C:\\Users\\User\\Desktop\\PAW Project\\AirlinePAW\\AirlinePAW\\database.db";
      
        public CompanyController() { }

        //get all companies
        public List<Company> GetAllCompanies()
        {
            List<Company> companies = new List<Company>();
            var query = "SELECT * FROM Company";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Company company = new Company();
                            company.company_id = Convert.ToInt32(reader["company_id"]);
                            company.company_name = reader["company_name"].ToString();
                            companies.Add(company);
                        }
                    }
                }
            }
            return companies;
        }

        //get company by name
        public Company GetCompanyByName(string name)
        {
            Company company = new Company();
            var query = "SELECT * FROM Company WHERE company_name=@name";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            company.company_id = Convert.ToInt32(reader["company_id"]);
                            company.company_name = reader["company_name"].ToString();
                        }
                    }
                }
            }
            return company;
        }

        //add a new company by name
        public void AddCompany(string name)
        {
            var query = "INSERT INTO Company (company_name) VALUES (@name)";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.ExecuteNonQuery();
                }
            }
        }

        //delete a company by name
        public void DeleteCompany(string name)
        {
            var query = "DELETE FROM Company WHERE company_name=@name";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.ExecuteNonQuery();
                }
            }
        }

        //edit a company by name
        public void EditCompany(string name, string newName)
        {
            var query = "UPDATE Company SET company_name=@newName WHERE company_name=@name";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@newName", newName);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
