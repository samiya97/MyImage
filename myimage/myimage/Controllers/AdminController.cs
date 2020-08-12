using myimage.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myimage.Controllers
{
    public class AdminController : Controller
    {

        SqlConnection cnn = new SqlConnection("Data Source=samiyabatool;Initial Catalog=Online_photo;User ID=samiya;Password=tirmazi1234;MultipleActiveResultSets=True;Application Name=EntityFramework");
        SqlCommand cmd = new SqlCommand();
        // GET: Admin
        Online_photoEntities en = new Online_photoEntities();

        public ActionResult AHome()
        {
            if (Session["log"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
              
                ViewBag.contact = en.ContactUs.ToList();
                ViewBag.order = en.Orders.ToList();
           
            }
            
            return View();
        }


        public ActionResult AUser()
        {
            if (Session["log"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.customer = en.Customers.ToList();

            }
            return View();
        }


        public ActionResult AOrders()
        {
            if (Session["log"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.order = en.Orders.ToList();

            }
            return View();
        }

        public ActionResult AProducts()
        {
            if (Session["log"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.product = en.Products.ToList();

            }
            return View();
        }
        public ActionResult AContact() {
            if (Session["log"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.contact = en.ContactUs.ToList();

            }


            return View();
        }
        [HttpPost]
        public ActionResult AUser(string id ,string fname, string lname, string dob, string gender, string phoneno, string address, string email, string password, string btn)
        {

           
            if (btn == "add")
            {

                cmd.CommandText = "insert into Customers values('" + fname + "','" + lname + "','" + dob + "','" + gender + "','" + phoneno + "','" + address + "','" + email + "','" + password + "')";
                cmd.Connection = cnn;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                Response.Write("<script>alert('inserted')</script>");
                return RedirectToAction("AUser", "Admin");
                   
            }

            else if (btn == "update") {

                cmd.CommandText =" UPDATE Customers SET Fname='"+fname+"',Lname='"+lname+"',DOB='"+dob+"',Gender='"+gender+"',Phone='"+phoneno+"',Address='"+email+"',Password='"+password+"' where custid ='"+id+"'  " ;
                cmd.Connection = cnn;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                Response.Write("<script>alert('updated')</script>");
                return RedirectToAction("AUser", "Admin");
            }

            else if (btn == "delete") {
                cmd.CommandText = " Delete  from Customers where custid ='" + id + "'  ";
                cmd.Connection = cnn;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                Response.Write("<script>alert('deleted')</script>");
                return RedirectToAction("AUser", "Admin");
            
            
            }

            return View();
        }

        [HttpPost]
        public ActionResult AProducts(string id, string size , string price , string btn)
        {
            if (btn == "add")
            {

                cmd.CommandText = "insert into Products values('" + size + "','" + price + "')";
                cmd.Connection = cnn;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                Response.Write("<script>alert('inserted')</script>");
                return RedirectToAction("AProducts", "Admin");

            }

            else if (btn == "update")
            {

                cmd.CommandText = " UPDATE Products SET Size='" + size + "',Prize='" + price + "' where Id ='" + id + "'  ";
                cmd.Connection = cnn;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                Response.Write("<script>alert('updated')</script>");
                return RedirectToAction("AProducts", "Admin");
            }

            else if (btn == "delete")
            {
                cmd.CommandText = " Delete  from Products where Id ='" + id + "'  ";
                cmd.Connection = cnn;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                Response.Write("<script>alert('deleted')</script>");
                return RedirectToAction("AProducts", "Admin");


            }

            return View();
        }
        public ActionResult Delete(int id) {


            
                cmd.CommandText = " Delete  from Orders where order_id ='" + id + "'  ";
                cmd.Connection = cnn;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                Response.Write("<script>alert('deleted')</script>");
                return RedirectToAction("AOrders", "Admin");
            
            
          

           
        }
        public ActionResult Delete1(int id) {

                cmd.CommandText = " Delete  from Orders where order_id ='" + id + "'  ";
                cmd.Connection = cnn;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                Response.Write("<script>alert('deleted')</script>");
                return RedirectToAction("Acontact", "Admin");
        }
        public ActionResult Logout() {

            Session.Abandon();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction("Login", "Account");
        }

    }
}