using mytask.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mytask.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master


        public dbcontext2 db = new dbcontext2();



        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
           

            
            return View();


        }




         public ActionResult Addproduct(int id)
        {


            if (id == 0)
            {


                ViewBag.id = id;
              ViewBag.serialno="";

              ViewBag.name="";
                ViewBag.rid = 0;
                ViewBag.ptype = 0;

                ViewBag.custname="";
               ViewBag.address="";
              ViewBag.Mnumber ="";


                

               var rlist= db.Mst_region.Select(x => new SelectListItem
                {

                    Text = x.rname,
                    Value = x.id.ToString()

                }).ToList() ;


                var ptypelist = db.Mst_producttype.Select(x => new SelectListItem
                {

                    Text = x.name,
                    Value = x.id.ToString()

                }).ToList();

                ViewBag.regionlist = rlist;
                ViewBag.ptypelist = ptypelist;
            }
            else
            {

                ViewBag.id = id;
                var pdetail = db.Mst_product.First(x => x.id == id);
                ViewBag.serialno =pdetail.s_no;

                ViewBag.name = pdetail.name;


                ViewBag.custname = pdetail.cust_name;
                ViewBag.address = pdetail.address;
                ViewBag.Mnumber = pdetail.M_number.ToString();
                ViewBag.rid = pdetail.region;
                ViewBag.ptype = pdetail.p_type;
               



                var rlist = db.Mst_region.Select(x => new SelectListItem
                {

                    Text = x.rname,
                    Value = x.id.ToString()

                }).ToList();


                var ptypelist = db.Mst_producttype.Select(x => new SelectListItem
                {

                    Text = x.name,
                    Value = x.id.ToString()

                }).ToList();

                ViewBag.regionlist = rlist;
                ViewBag.ptypelist = ptypelist;

            }


            return View();


        }
        [HttpGet]
        public ActionResult Deleteproduct(int id)
        {


            db.sp_delete_product(id);

          
            return new JsonResult { Data = new { status = true } };


        }


            
            [HttpPost]
        public ActionResult Addproduct(FormCollection form)
        {

           

            int id = Convert.ToInt32(form["id"]);
            if (id == 0)
            {
                string serialno = form["serialno"];
                string name = form["name"];
                string custname = form["custname"];
                string address = form["address"];
                int Mnumber = Convert.ToInt32(form["Mnumber"]);
                int regionlistid = Convert.ToInt32(form["regionlistid"]);
                int ptypelistid = Convert.ToInt32(form["ptypelistid"]);

                db.sp_insert_product(name, ptypelistid, custname, address, Mnumber, regionlistid, serialno);

            }
            else
            {

                string serialno = form["serialno"];
                string name = form["name"];
                string custname = form["custname"];
                string address = form["address"];
                int Mnumber = Convert.ToInt32(form["Mnumber"]);
                int regionlistid = Convert.ToInt32(form["regionlistid"]);
                int ptypelistid = Convert.ToInt32(form["ptypelistid"]);

                db.sp_update_product(id, name, ptypelistid, custname, address, Mnumber, regionlistid, serialno);



            }

            return new JsonResult { Data = new { status = true } };


        }
        [HttpGet]
        public JObject getdata()
        {
            DataTable ob = Master.getproducts();
            //string s = JsonConvert.SerializeObject(ob,Formatting.Indented);

            var  s= string.Empty;
            s = JsonConvert.SerializeObject(ob);

            JObject ob13 = new JObject();
            ob13.Add("draw", 1);

            ob13.Add("recordsTotal", ob.Rows.Count);
            ob13.Add("recordsFiltered", ob.Rows.Count);

            ob13.Add("data", JArray.Parse(s));
           

            

            return ob13;



        }

        /////Approval master Start//////////////

        public ActionResult Approval()
        {



            return View();


        }



        public ActionResult AddApproval(int id)
        {


            if (id == 0)
            {


                ViewBag.id = id;
               
                ViewBag.name = "";


              
            }
            else
            {

                ViewBag.id = id;
                var pdetail = db.Mst_approval.First(x => x.id == id);
           

                ViewBag.name = pdetail.rname;

            }


            return View();


        }
        [HttpGet]
        public ActionResult DeleteApprovalt(int id)
        {


            db.sp_delete_approval(id);


            return new JsonResult { Data = new { status = true } };


        }





        [HttpPost]
        public ActionResult AddApproval(FormCollection form)
        {


           


            int id = Convert.ToInt32(form["id"]);
            if (id == 0)
            {
               
                string name = form["name"];
              

                db.sp_insert_approval(name);



            }
            else
            {

                
                string name = form["name"];
               

                db.sp_Update_Approval(name,id);



            }

            return new JsonResult { Data = new { status = true } };


        }
        [HttpGet]
        public JObject getdataapproval()
        {
            DataTable ob = Master.sp_select_approval();


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



        ///////Start Action master///   Section

        public ActionResult Action()
        {



            return View();


        }





        public ActionResult AddAction(int id)
        {


            if (id == 0)
            {


                ViewBag.id = id;

                ViewBag.name = "";



            }
            else
            {

                ViewBag.id = id;
                var pdetail = db.Mst_action.First(x => x.id == id);


                ViewBag.name = pdetail.name;

            }


            return View();


        }
        [HttpGet]
        public ActionResult DeleteAction(int id)
        {


            db.sp_delete_action(id);


            return new JsonResult { Data = new { status = true } };


        }





        [HttpPost]
        public ActionResult AddAction(FormCollection form)
        {





            int id = Convert.ToInt32(form["id"]);
            if (id == 0)
            {

                string name = form["name"];


                db.sp_insert_Action(name);



            }
            else
            {


                string name = form["name"];


                db.sp_Update_Action(name, id);



            }

            return new JsonResult { Data = new { status = true } };


        }
        [HttpGet]
        public JObject getdataAction()
        {
            DataTable ob = Master.sp_select_action();


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





        /////////Call Reason//////
        ///


        public ActionResult callreason()
        {



            return View();


        }




        public ActionResult Addcallreason(int id)
        {


            if (id == 0)
            {


                ViewBag.id = id;

                ViewBag.name = "";



            }
            else
            {

                ViewBag.id = id;
                var pdetail = db.Mst_callreason.First(x => x.id == id);


                ViewBag.name = pdetail.name;

            }


            return View();


        }
        [HttpGet]
        public ActionResult Deletecallreason(int id)
        {


            db.sp_delete_callreason(id);


            return new JsonResult { Data = new { status = true } };


        }





        [HttpPost]
        public ActionResult Addcallreason(FormCollection form)
        {





            int id = Convert.ToInt32(form["id"]);
            if (id == 0)
            {

                string name = form["name"];


                db.sp_insert_Callreason(name);



            }
            else
            {


                string name = form["name"];


                db.sp_Update_Callreason(name, id);



            }

            return new JsonResult { Data = new { status = true } };


        }
        [HttpGet]
        public JObject getdatacallreason()
        {
            DataTable ob = Master.sp_select_callreason();


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
    }
}