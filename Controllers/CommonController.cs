using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Id, string Password)
        {
            if (Id[0] == 'E')
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
                    if (reader.GetString(reader.GetOrdinal("EmployeeId")) == Id)
                    {
                        
                        Session["id"] = Id;
                        return RedirectToAction("RequestList", "Employee");
                    }
                }
                conn.Close();

            }

            if (Id[0] == 'A')
            {
                string connString = @"Data Source=HRITHIKISHERE\SQLEXPRESS;Initial Catalog=ZeroHunger;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connString);
                string query = "Select * from Admin";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(reader.GetOrdinal("AdminId")) == Id)
                    {

                        Session["id"] = Id;
                        return RedirectToAction("EmployeeList", "Admin");
                    }
                }
                conn.Close();
            }

            if (Id[0] == 'R')
            {
                string connString = @"Data Source=HRITHIKISHERE\SQLEXPRESS;Initial Catalog=ZeroHunger;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connString);
                string query = "Select * from Restaurant";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(reader.GetOrdinal("RestaurantId")) == Id)
                    {

                        Session["id"] = Id;
                        return RedirectToAction("RequestList", "Restaurant");
                    }
                }
                conn.Close();
            }

            return View();


        }
    }
}