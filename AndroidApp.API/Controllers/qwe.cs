using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using AndroidApp.Domain.Person;
using System.Web;

namespace AndroidApp.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class qwe : ControllerBase
    {
        string stringconn = "Data Source=LAPTOP-FPR118VN\\SQLEXPRESS;" +
                "Initial Catalog=android;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "Encrypt=False;" +
                "TrustServerCertificate=False;" +
                "ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False";
        [HttpGet]
        public IActionResult allPerson()
        {
            string sql = $"select * from person";

            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            var command = new SqlCommand(sql, conn);
            var person = new List<Person>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var temp = new Person(
                        (int)reader.GetInt32(0),
                        reader.GetString(1).ToString(),
                        reader.GetString(2).ToString()
                        );
                    person.Add(temp);
                }
            }
            var json = JsonConvert.SerializeObject(person);

            conn.Close();
            return Ok(json);
        }
        [HttpGet("{id}")]
        public IActionResult GetPerson(string id)
        {
            string sql = $"select * from person where person.id = {id}";
            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            var command = new SqlCommand(sql, conn);
            var person = new List<Person>();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var temp = new Person(
                        (int)reader.GetInt32(0),
                        reader.GetString(1).ToString(),
                        reader.GetString(2).ToString()
                        );
                    person.Add(temp);
                }
            }
            var json = JsonConvert.SerializeObject(person);

            conn.Close();
            return Ok(json);
        }
        [HttpDelete("{id}")]
        public IActionResult DelPerson(int id)
        {
            string sql = $"delete from person where person.id = {id}";
            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            var command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            return Ok();
        }
        [HttpPost("{name}/{number}")]
        public IActionResult CreatePerson(string name, string number)
        {
            string sql = $"insert into person VALUES ('{name}', '{number}')";
            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            var command = new SqlCommand(sql, conn);
            int eee = command.ExecuteNonQuery();
            string result = $"Добавили: {eee} строк";
            conn.Close();
            return Ok(result);
        }
        [HttpPut("{id}/{name}/{number}")]
        public IActionResult PutPerson(int id, string name, string number)
        {
            string sql = $"update person set name = '{name}', number = '{number}' where id = {id}";
            SqlConnection conn = new SqlConnection(stringconn);
            conn.Open();
            var command = new SqlCommand(sql, conn);
            int eee = command.ExecuteNonQuery();
            string result = $"Изминили: {eee} строк";
            conn.Close();
            return Ok(result);
        }
    }
}
