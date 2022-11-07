using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using AndroidApp.Domain.Person;

namespace AndroidApp.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class qwe : ControllerBase
    {
        [HttpGet]
        public IActionResult allPerson()
        {
            string sql = $"select * from person";

            string stringconn = "Data Source=LAPTOP-FPR118VN\\SQLEXPRESS;" +
                "Initial Catalog=android;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "Encrypt=False;" +
                "TrustServerCertificate=False;" +
                "ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False";
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
    }
}
