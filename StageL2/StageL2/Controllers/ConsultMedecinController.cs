using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using StageL2.Views.ConsultMedecin;
using StageL2.Views.Activite;
using System.Data;
using StageL2.Models;

namespace StageL2.Controllers
{
    public class ConsultMedecinController : Controller
    {
        OracleDataReader dr;
      
        public IActionResult Index(string Log)
        {
            FonctionA a = new FonctionA();
            int b = a.Comptlog(Log);
            if (b != 0)
            {
                GlobalVariable.GlobalVar = Log;
                string id = a.getIdent(Log);
                GlobalVariable.ImportantData = id;
                ViewBag.message = Log;
                return View();
            }
            else
            {
                return RedirectToAction("Erreur", "Activite");
            }
        }

        public IActionResult updateFreq(string obs, string daterdz , int Jrepos , int num)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "UPDATE FREQMALA_JDE SET AVIS_MEDE ='" + obs + "' , DATE_RENDEZ_VOUS =TO_DATE('" + daterdz + "', 'DD/MM/YYYY HH24:MI:SS') , JREPOS ='"+ Jrepos +"' , HAMEDE = SYSDATE WHERE NUMERO= '"+ num + "' AND (TO_DATE(DFREQ, 'DD/MM/YYYY') = TO_DATE(SYSDATE, 'DD/MM/YYYY')) AND IDENTIFIANT = '"+GlobalVariable.ImportantData+"'  ",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
                // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
                TempData["text"] = "Traitement reussi du patient "+ num +" ! ";
                conn.Close();
            }
            catch (Exception ex)
            {
                // Une erreur est survenue: on ne valide pas la requête     
                trans.Rollback();
                TempData["text"] = "Requete non effectue \nErreur: " + ex.Message;
            }
            finally
            {     // Libération des ressources     
                cmd.Dispose();
            }
             return RedirectToAction("Index", "ConsultMedecin"  , new {Log = GlobalVariable.GlobalVar });
        }
    }
}