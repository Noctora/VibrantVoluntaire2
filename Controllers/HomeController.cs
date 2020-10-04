using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VibrantVoluntaire2.Data;
using VibrantVoluntaire2.Models;

namespace VibrantVoluntaire2.Controllers
{
    public class HomeController : Controller
    {

 

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult NGO()
        {
            List<NGOAcc> ngo = new List<NGOAcc>();

            //ngo.Add(new NGOAcc(111, "asda", "adas", "dasdsa", "dasdasd", "dasdasd", "dasdsa", "dqawewq", "dqawedwq", "1/1/2001", "dqwewq"));

            NGODAO ngoDAO = new NGODAO();

            ngo = ngoDAO.FetchAll();

            return View("NGO", ngo);
        }

        public ActionResult NGODetails(int id)
        {
            NGODAO ngoDAO = new NGODAO();
            NGOAcc ngo = ngoDAO.FetchOne(id);

            return View("NGODetails", ngo);
        }

        public ActionResult CreateNGO()
        {
            NGOAcc ngo = new NGOAcc();
            return View("NGOForm", ngo);
        }

        public ActionResult EditNGO(int id)
        {
            NGODAO ngoDAO = new NGODAO();
            NGOAcc ngo = ngoDAO.FetchOne(id);
            return View("NGOForm", ngo);
        }

        public ActionResult DeleteNGO(int id)
        {
            NGODAO ngoDAO = new NGODAO();
            ngoDAO.Delete(id);

            List<NGOAcc> ngo = ngoDAO.FetchAll();

            return View("NGO", ngo);
        }

        [HttpPost]
        public ActionResult ProcessNGO(NGOAcc ngoAcc)
        {
            //save to the db.
            NGODAO ngoDAO = new NGODAO();

            ngoDAO.CreateOrUpdate(ngoAcc);

            return View("NGODetails", ngoAcc);
        }

        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }

        public ActionResult SearchForName(string searchPhrase)
        {

            // get a list of search resultss from the database.
            NGODAO ngoDAO = new NGODAO();
            List<NGOAcc> searchResults = ngoDAO.SearchForName(searchPhrase);

            return View("NGO", searchResults);
        }
    }
}