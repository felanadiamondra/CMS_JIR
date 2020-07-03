using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using StageL2.Views.Rapport;


namespace StageL2.Controllers
{
    public class RapportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AfficheRapport(string anneeR)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            FonctionRapport cmpt = new FonctionRapport();
            int nb = cmpt.CompterAnnee(anneeR);
            if (nb != 0)
            {
                ViewBag.MessageRapport = anneeR;
                return View();
            }
            else
            {
                TempData["text"] = "Aucune frequentation de l annee " + anneeR + " ! ";
                return RedirectToAction("Index", "Rapport");
            }
        }
    }
}