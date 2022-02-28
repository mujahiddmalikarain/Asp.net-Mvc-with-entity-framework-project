using mytask.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mytask.Controllers
{
    public class HomeController : Controller
    {
        public dbcontext2 db = new dbcontext2();

        public ActionResult Index()
        {


            if (Session.Contents.Count != 0)
            {
                if (Session["uid"] is string)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("login", "Home" );



                }
            }
            {
                return RedirectToAction("login", "Home" );

            }
        }


        public ActionResult About()
        {



            //Fetchdatafrom////
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        ////login//
        ///
        public ActionResult login()
        {

            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpPost]
        public ActionResult login(FormCollection form)
        {
            string userName = form["uid"]; string password = form["pass"];

            DataTable dt = Master.login(userName,password);
            if (dt.Rows.Count> 0)
            {

                Session["uid"] = dt.Rows[0][0].ToString();

                Session["roleid"] = dt.Rows[0][2].ToString();

               
                return RedirectToAction("index", "Home");


               


            }
            ViewBag.error = "Wrong Credential !";

            return View();

           
        }

        [HttpGet]
        public JObject getdata()
        {
            DataTable ob = callcenter.sp_get_calllogsbyadmin();
            //string s = JsonConvert.SerializeObject(ob,Formatting.Indented);

            var s = string.Empty;
            s = JsonConvert.SerializeObject(ob);

            JObject ob13 = new JObject();
            ob13.Add("draw", 1);

            ob13.Add("recordsTotal", ob.Rows.Count);
            ob13.Add("recordsFiltered", ob.Rows.Count);

            ob13.Add("data", JArray.Parse(s));




            return ob13;



        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("login", "Home");
        }
    }
}