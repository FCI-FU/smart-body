using Newtonsoft.Json;
using Smart__Body.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smart__Body.Classes;
using MySql.Data.MySqlClient;

namespace Smart__Body.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account log)
        {
            DB dataObject = new DB();
            try
            {
                dataObject.open();
                string Query = "SELECT Password , Type , id FROM accounts WHERE UserName = '" + log.userName + "'";
                dataObject.select(Query);
                if (dataObject.getCount() == 0)
                {
                    ViewBag.errorMessage = "UserName is not Valid";
                    return View();
                }

                else if (dataObject.getData(0, 0) != log.password)
                {
                    ViewBag.errorMessage = "Password is wrong";
                    return View();
                }

                Session["Type"] = dataObject.getData(0, 1);
                Session["id"] = dataObject.getData(0, 2);
                Session["userName"] = log.userName;

                dataObject.close();
            }
            catch (MySqlException ex)
            {
                throw;
            }
            return Redirect("~");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Account reg)
        {
            try
            {
                string type = "", id = "", tableName;
                if (reg.hasGym)
                {
                    type = "owner";
                    tableName = "gymowner";
                }
                else
                {
                    type = "user";
                    tableName = "user";
                }
                DB db = new DB();
                db.open();

                string Query = "INSERT INTO accounts (UserName , Password , Type) VALUES('" + reg.userName + "','" + reg.password + "','" + type + "')";
                db.Modify(Query);
                Query = "SELECT  max(Id) FROM accounts ";
                db.select(Query);
                id = db.getData(0, 0);
                Query = "INSERT INTO " + tableName + "  VALUES ('" + id + "','" + reg.Name + "','" + reg.email + "','" + reg.contactNo + "')";
                db.Modify(Query);
                if (type == "owner")
                {
                    Query = "INSERT INTO gym (Name,Phone,Location,gymowner_Id) VALUES ('" + reg.gymName + "','" + reg.gymPhone + "','" + reg.gymLocation + "','" + id + "')";
                    db.Modify(Query);
                }

                db.close();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                    ViewBag.errorMessag = "This User Name is already taken";
                return View();
            }
            return Redirect("~");
        }

        public ActionResult GymStatistic()
        {
            ViewBag.Page = 0;
            ViewBag.type = "owner";
            ViewBag.Name = "Abdalrahman";
            List<string> names = new List<string>();
            List<int> rate = new List<int>();
            List<string> comment = new List<string>();

            names.Add("ahmed");
            names.Add("ali");
            names.Add("khaled");

            rate.Add(2);
            rate.Add(3);
            rate.Add(5);

            comment.Add("this was nice in buy. this was nice in buy. this was nice in buy. this was nice in buy this was nice in buy this was nice in buy this was nice in buy this was nice in buy");
            comment.Add("this was nice in buy. this was nice in buy. this was nice in buy. this was nice in buy this was nice in buy this was nice in buy this was nice in buy this was nice in buy");
            comment.Add("this was nice in buy. this was nice in buy. this was nice in buy. this was nice in buy this was nice in buy this was nice in buy this was nice in buy this was nice in buy");

            ViewBag.userName = names;
            ViewBag.rate = rate;
            ViewBag.comment = comment;
            ViewBag.index = 0;
            return View();
        }

        public ActionResult GymPackages()
        {
            ViewBag.Page = 1;
            ViewBag.type = "owner";
            ViewBag.Name = "Abdalrahman";
            List<DataPoint> pack = new List<DataPoint>();
            pack.Add(new DataPoint("yomna ", 50, "10"));
            ViewBag.Pakcage = pack;
            ViewBag.count = 1;
            return View();
        }

        public ActionResult PackageTrainings()
        {
            ViewBag.Page = 1;
            ViewBag.type = "owner";
            ViewBag.Name = "Abdalrahman";
            return View();
        }

        public ActionResult Offers()
        {
            ViewBag.Page = 1;
            ViewBag.type = "owner";
            ViewBag.Name = "YOMNA";
            List<DataPoint> pack = new List<DataPoint>();
            pack.Add(new DataPoint("yomna ", 50, "10"));
            ViewBag.Pakcage = pack;
            ViewBag.count = 1;
            return View();
        }

        public ActionResult GymCoaches()
        {
            ViewBag.Page = 2;
            ViewBag.type = "owner";
            ViewBag.Name = "Abdalrahman";
            List<string> coach = new List<string>();
            coach.Add("yomna");
            coach.Add("yomna");
            coach.Add("yomna");
            coach.Add("yomna");
            coach.Add("yomna");
            coach.Add("yomna");
            coach.Add("yomna");
            coach.Add("yomna");
            coach.Add("yomna");
            ViewBag.Coach = coach;
            ViewBag.count = 9;

            return View();
        }

        public ActionResult GymBranch()
        {
            ViewBag.Page = 3;
            ViewBag.type = "owner";
            ViewBag.Name = "Abdalrahman";
            return View();
        }

        public ActionResult GymSetting()
        {
            ViewBag.Page = 4;
            ViewBag.type = "owner";
            ViewBag.Name = "Abdalrahman";
            ViewBag.Photos = 2;
            List<string> s = new List<string>();
            s.Add("/Images/GymPhotos/avatar.png");
            s.Add("/Images/GymPhotos/Erorr_404.png");
            ViewBag.Src = s;
            return View();
        }

        public ActionResult CoachStatistic()
        {
            ViewBag.type = "coach";
            ViewBag.Name = "Abdalrahman";
            ViewBag.Page = 0;
            List<string> names = new List<string>();
            List<int> rate = new List<int>();
            List<string> comment = new List<string>();

            names.Add("ahmed");
            names.Add("ali");
            names.Add("khaled");

            rate.Add(2);
            rate.Add(3);
            rate.Add(5);

            comment.Add("this was nice in buy. this was nice in buy. this was nice in buy. this was nice in buy this was nice in buy this was nice in buy this was nice in buy this was nice in buy");
            comment.Add("this was nice in buy. this was nice in buy. this was nice in buy. this was nice in buy this was nice in buy this was nice in buy this was nice in buy this was nice in buy");
            comment.Add("this was nice in buy. this was nice in buy. this was nice in buy. this was nice in buy this was nice in buy this was nice in buy this was nice in buy this was nice in buy");

            ViewBag.userName = names;
            ViewBag.rate = rate;
            ViewBag.comment = comment;
            ViewBag.index = 0;
            return View();
        }

        public ActionResult CoachTraning()
        {
            ViewBag.type = "coach";
            ViewBag.Name = "Abdalrahman";
            ViewBag.Page = 1;
            return View();
        }

        [HttpPost]
        public ActionResult PackageTrainings(int id, Training trainingObject)
        {
            ViewBag.Page = 1;
            ViewBag.type = "owner";
            ViewBag.Name = "Abdalrahman";
            DB dataObject = new DB();
            try
            {
                dataObject.open();

                string Query = "INSERT INTO training (Name , Duration , Description , TraineesNumber , coach_Id) VALUES ('" + trainingObject.tName 
                    + "','" + trainingObject.tDuration + "','" + trainingObject.tDescription + "','" + trainingObject.NumOfTrainee + "','" 
                    + trainingObject.coachID + "')";

                ViewBag.errorMessage = Query;

                dataObject.Modify(Query);

                dataObject.close();

                ViewBag.errorMessage = Query;
            }
            catch(Exception ex)
            {
                ViewBag.errorMessage = ex.ToString();
            }
            return View();
        }

        public ActionResult CoachMessage()
        {
            ViewBag.type = "coach";
            ViewBag.Name = "Abdalrahman";
            ViewBag.Page = 2;
            return View();
        }

        public ActionResult CoachSetting()
        {
            ViewBag.type = "coach";
            ViewBag.Name = "Abdalrahman";
            ViewBag.Page = 3;
            return View();
        }
        
        [HttpPost]
        public ActionResult GymPackages(Packege pac)
        {
            try
            {
                int id = 8;
                string Query = "insert into package (Name,Price,gym_Id) values ('"+pac.packageName+"','"+pac.packagePrice+"','"+id+"')";
                DB db = new DB();
                db.open();
                db.Modify(Query);
                db.close();
                ViewBag.errorMessag = "Done";
            }
            catch (MySqlException ex)
            {
                ViewBag.errorMessag = ex;
            }
            return View();
        }
    }
}
