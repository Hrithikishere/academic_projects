using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            string connString = @"Data Source=HRITHIKISHERE\SQLEXPRESS;Initial Catalog=ZeroHunger;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            string query = String.Format("Insert into Employees values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", employee.EmployeeId, employee.Name, employee.Password, employee.Address, employee.Phone, employee.JoinDate);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            return View();
        }

        public ActionResult EmployeesList()
        {
            string connString = @"Data Source=HRITHIKISHERE\SQLEXPRESS;Initial Catalog=ZeroHunger;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            string query = "Select * from Employees";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                if(reader.GetString(reader.GetOrdinal("EmployeeId")) == "E001")
                {
                    Employee employee = new Employee()
                    {
                        EmployeeId = reader.GetString(reader.GetOrdinal("EmployeeId")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Address = reader.GetString(reader.GetOrdinal("Address")),
                        Phone = reader.GetString(reader.GetOrdinal("Phone")),
                        JoinDate = reader.GetDateTime(5).ToString("yyyy-MM-dd"),
                    };
                    employees.Add(employee);
                }
            }
            conn.Close();
            return View(employees);
        }
        public ActionResult RestaruantList()
        {
            string connString = @"Data Source=HRITHIKISHERE\SQLEXPRESS;Initial Catalog=ZeroHunger;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            string query = "Select * from Restaurant";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Restaurant> restaurants = new List<Restaurant>();
            while (reader.Read())
            {
                Restaurant employee = new Restaurant()
                {
                    RestaurantId = reader.GetString(reader.GetOrdinal("RestaurantId")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Address = reader.GetString(reader.GetOrdinal("Address")),
                    Phone = reader.GetString(reader.GetOrdinal("Phone")),
                    JoinDate = reader.GetDateTime(5).ToString("yyyy-MM-dd"),

                };
                restaurants.Add(employee);
            }
            conn.Close();
            return View(restaurants);
        }

        public ActionResult RequestList() {

            string connString = @"Data Source=HRITHIKISHERE\SQLEXPRESS;Initial Catalog=ZeroHunger;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            string query = "Select * from Requests";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Request> requests = new List<Request>();
            while (reader.Read())
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
            }
            conn.Close();
            return View(requests);
        }

        public ActionResult CreateRestaurant(Restaurant restaurant)
        {
            string connString = @"Data Source=HRITHIKISHERE\SQLEXPRESS;Initial Catalog=ZeroHunger;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            string query = String.Format("Insert into Restaruant values ('{0}', '{1}', '{2}', '{3}', '{4}')", restaurant.RestaurantId, restaurant.Name, restaurant.Address, restaurant.Phone, restaurant.JoinDate);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            return View();

        }

        public ActionResult Profile()
        {
            return View();
        }

    }
}