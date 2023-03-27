using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult RequestList()
        {
            string connString = @"Data Source=HRITHIKISHERE\SQLEXPRESS;Initial Catalog=ZeroHunger;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            string query = "Select * from Requests";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Request> requests = new List<Request>();
            while (reader.Read())
            {
                string AEmployee = reader.GetString(reader.GetOrdinal("AssignedEmployee"));
                string id = Session["id"].ToString();
                if (AEmployee == id)
                {
                    Request request = new Request()
                    {
                        RequestId = reader.GetString(reader.GetOrdinal("RequestId")),
                        FoodName = reader.GetString(reader.GetOrdinal("FoodName")),
                        FoodType = reader.GetString(reader.GetOrdinal("FoodType")),
                        Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                        Status = reader.GetString(reader.GetOrdinal("Status")),
                        Address = reader.GetString(reader.GetOrdinal("Address")),
                        AssignedEmployee = reader.GetString(reader.GetOrdinal("AssignedEmployee")),
                        RestaurantId = reader.GetString(reader.GetOrdinal("RestaurantId")),
                    };
                    requests.Add(request);
                }
                
            }
            conn.Close();
            return View(requests);
        }
    }
}