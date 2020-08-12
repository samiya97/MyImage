
using myimage.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myimage.Controllers
{
    public class accountController : Controller
    {
        //
        Online_photoEntities en = new Online_photoEntities();
       static List<Image> Lsted = new List<Image>();
       static Image obj = new Image();
       static Order or = new Order();
       Int32 sprice = 0;
       Int32 totalprice = 0;
       Int32 payment = 0;
       Int32 t_qty = 0;
       SqlConnection cnn = new SqlConnection("Data Source=samiyabatool;Initial Catalog=Online_photo;User ID=samiya;Password=tirmazi1234;MultipleActiveResultSets=True;Application Name=EntityFramework");
        SqlCommand cmd = new SqlCommand();
        // GET: /account/
        public ActionResult login()
        {
            Session["log"] = null;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return View();
        }

        // Post: Account
        [HttpPost]
        public ActionResult Login(string fname, string lname, string dobtxt, string gendertxt, string phonetxt, string addresstxt, string emailtxt, string passtxt, string btn, string loginemail, string loginpass)
        {


            if (btn == "Login")
            {
                if (loginemail == "Admin" && loginpass == "admin")
                {
                    Session["log"] = loginemail;
                    return RedirectToAction("AHome", "Admin");

                }
                else
                {
                    cmd.CommandText = "select * from Customers where Email='" + loginemail + "' and Password= '" + loginpass + "'";
                    cmd.Connection = cnn;
                    cnn.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    rd.Read();
                    if (rd.HasRows)
                    {
                        Session["log"] = loginemail;
                        cnn.Close();
                        return RedirectToAction("useraccount", "account");
                    }
                    else
                    {
                        cnn.Close();
                        Response.Write("<script>alert('Invalid Email Id or Password')</script>");
                    }
                }
            }

            else
            {

                cmd.CommandText = "insert into Customers values('" + fname + "','" + lname + "','" + dobtxt + "','" + gendertxt + "','" + phonetxt + "','" + addresstxt + "','" + emailtxt + "','" + passtxt + "')";
                cmd.Connection = cnn;
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                Response.Write("<script>alert('Registered Successfull')</script>");
            }
          return View();
        }
      public   ActionResult useraccount()
        {
            if (Session["log"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
           
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();

                string email = Session["log"].ToString();

                
                ViewBag.order = en.Orders.Where(a => a.Email_id == email).ToList();
                ViewBag.product = en.Products.ToList();
                ViewBag.image = en.Images.Where(a => a.Email == email).ToList();
            
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetNoStore();
           ViewBag.print = "";
            return View();
        }
        [HttpPost]
      public ActionResult useraccount( string picsize, HttpPostedFileBase UploadPicture, string btn, string qty ,Int64 ? c_no)
      {
          string email = Session["log"].ToString();
          

          ViewBag.order = en.Orders.Where(a => a.Email_id == email).ToList();
          ViewBag.product = en.Products.ToList();
          ViewBag.image = en.Images.Where(a => a.Email == email).ToList();
               if (btn == "Upload Images")
               {
                   UploadPicture.SaveAs(Server.MapPath("/Images/" + UploadPicture.FileName));
                   obj.Image1 = "/Images/" + UploadPicture.FileName;
                   obj.Pr_size = picsize;
                   cmd.CommandText = " select Prize from Products where Size='" + picsize + "'  ";
                   cmd.Connection = cnn;
                   cnn.Open();
                   SqlDataReader rd = cmd.ExecuteReader();
                   rd.Read();
                   if (rd.HasRows)
                   {
                       sprice = Convert.ToInt32(rd[0]);
                       cnn.Close();
                   }
                   else
                   {
                       cnn.Close();

                   }

                   obj.Pr_price = sprice;
                   obj.Quantity = Convert.ToInt32(qty); ;
                   totalprice = Convert.ToInt32(qty) * sprice;  
                   obj.T_price = totalprice;
                   obj.Email = Session["log"].ToString(); ;
                   en.Images.Add(obj);
                   en.SaveChanges();
                   return RedirectToAction("useraccount", "account");
               }

               else if (btn == "Get Bill") {
                  // string email = Session["log"].ToString();
                   
                   SqlCommand query = new SqlCommand("SELECT SUM(T_price) FROM Images where Email='" + email + "'");
                   query.Connection = cnn;
                   cnn.Open();
                   SqlDataReader rd1 = query.ExecuteReader();
                   rd1.Read();
                   if (rd1.HasRows)
                   {
                       payment = Convert.ToInt32(rd1[0]);
                       ViewBag.print = payment;
                       or.Total_Payment = payment;
                       cnn.Close();
                   }
                   SqlCommand query2 = new SqlCommand("SELECT SUM(Quantity) FROM Images where Email='" + email + "'");
                   query2.Connection = cnn;
                   cnn.Open();
                   SqlDataReader rd2 = query2.ExecuteReader();
                   rd2.Read();
                   if (rd2.HasRows)
                   {
                       t_qty = Convert.ToInt32(rd2[0]);
                       or.No_print = t_qty;
                       
                       cnn.Close();
                   }
               
               
               }
              
               else if (btn == "Confirm Order")
               {
                  
                  or.Email_id = Session["log"].ToString();
                  
                  
                  or.credit_cardNo =c_no;
                   or.Delievery_status = "yes";

                   en.Orders.Add(or);
                   en.SaveChanges();
                   
                   Response.Write("<script>alert('Your order will be dilvered soon.... thanks you')</script>");
                   cmd.CommandText = " Delete  from Images where Email ='" + email + "'  ";
                   cmd.Connection = cnn;
                   cnn.Open();
                   cmd.ExecuteNonQuery();
                   cnn.Close();
                   return RedirectToAction("useraccount", "Account");
               }
           
          
          return View();
      }
       

        public ActionResult Delete(int id)
        {
            cmd.CommandText = " Delete  from Images where Id ='" + id + "'  ";
            cmd.Connection = cnn;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
            Response.Write("<script>alert('deleted')</script>");
            return RedirectToAction("useraccount", "account");
        }
        public ActionResult Logout()
        {

            Session.Abandon();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction("Login", "Account");
        }

    }
}