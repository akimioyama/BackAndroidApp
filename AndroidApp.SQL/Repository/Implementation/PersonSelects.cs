using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;
using AndroidApp.Domain.Person;
using AndroidApp.SQL.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AndroidApp.SQL.Repository.Implementation
{
    public class PersonSelects : IPersonSelects
    {
        string stringconn = "Data Source=LAPTOP-FPR118VN\\SQLEXPRESS;" +
                "Initial Catalog=android;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "Encrypt=False;" +
                "TrustServerCertificate=False;" +
                "ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False";

        public bool CreatePerson(Person1 perosn)
        {
            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            try
            {
                string sql = $"insert into person VALUES ('{perosn.name}', '{perosn.number}')";
                var command = new SqlCommand(sql, conn);
                int eee = command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool DeletePerson(int id)
        {
            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            try
            {
                string sql = $"delete from person where person.id = {id}";
                var command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Person1> GetAllPerson()
        {
            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            try
            {
                string sql = $"select * from person";
                var command = new SqlCommand(sql, conn);
                var person = new List<Person1>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var temp = new Person1();
                        temp.id = (int)reader.GetInt32(0);
                        temp.name = reader.GetString(1).ToString();
                        temp.number = reader.GetString(2).ToString();
                        person.Add(temp);
                    }
                }
                return person;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Person1> GetPerson(int id)
        {
            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            try
            {
                string sql = $"select * from person where person.id = {id}";
                var command = new SqlCommand(sql, conn);
                var person = new List<Person1>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var temp = new Person1();
                        temp.id = (int)reader.GetInt32(0);
                        temp.name = reader.GetString(1).ToString();
                        temp.number = reader.GetString(2).ToString();
                        person.Add(temp);
                    }
                }
                return person;
            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool PutPerson(int id, Person1 person)
        {
            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            try
            {
                string sql = $"update person set name = '{person.name}', number = '{person.number}' where id = {id}";
                var command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
