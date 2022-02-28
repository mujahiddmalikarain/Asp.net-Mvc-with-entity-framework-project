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
    public class callcenterController : Controller
    {
        // GET: callcenter
        public dbcontext2 db = new dbcontext2();
        public ActionResult Index()

        {

            return View();
        }


        [HttpGet]
        public JObject getdata()
        {
            DataTable ob = callcenter.sp_get_calllogsbyuserid(Session["uid"].ToString());
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


        public ActionResult addnewcalllog()

        {


            return View();

        }


    }
    


}