using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myimage.Controllers
{
    public class homeController : Controller
    {
        SqlConnection cnn = new SqlConnection("Data Source=samiyabatool;Initial Catalog=Online_photo;User ID=samiya;Password=tirmazi1234;MultipleActiveResultSets=True;Application Name=EntityFramework");
        SqlCommand cmd = new SqlCommand();
        // GET: home
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult index()
        {
            return View();
        }

        public ActionResult aboutus()
        {
            return View();
        }
          [HttpPost]
        public ActionResult ContactUs(string name, string email, string message, string btn)
        {
           cmd.CommandText = "insert into ContactUs values('" + name + "','" + email + "','" + message + "')";
            cmd.Connection = cnn;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            return View();
        }

    }
}