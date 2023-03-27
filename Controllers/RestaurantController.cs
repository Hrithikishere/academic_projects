using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        public ActionResult CreateRequest(Request request)
        {
            string connString = @"Data Source=HRITHIKISHERE\SQLEXPRESS;Initial Catalog=ZeroHunger;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            string query = String.Format("Insert into Request values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", request.RequestId, request.FoodName, request.FoodType, request.Quantity, request.Status, request.Address, request.RestaurantId);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            return View();
            
        }
        public ActionResult RequestList() {
            return View();
        }

        public ActionResult Profile() { return View(); }
    }
}