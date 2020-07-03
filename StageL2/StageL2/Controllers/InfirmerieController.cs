using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace StageL2.Controllers
{
    public class InfirmerieController : Controller
    {
        OracleDataReader dr;

        public IActionResult Index()
        {
            return View();
        }

        //Ajout Frequentation Infirmerie (mise à jour de celle de l'accueil)
        public IActionResult ValiderFreq(string id, double temp, double tamax, double tamin, double puls, double poids, double taille, double pc, double album, double glycemie)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "UPDATE FREQMALA_JDE SET TEMP = '" + temp + "' , TAMAX = '" + tamax + "' , TAMIN ='" + tamin + "' , PULLS = '" + puls + "' , POIDS = '" + poids + "', PC = '" + pc + "' , ALBUM = '" + album + "' , TAILLE = '"+ taille +"' , GLICEMIE = '" + glycemie + "' , HACMS = SYSDATE WHERE FREQMALA ='" + id + "'",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
                // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
                conn.Close();
                TempData["text"] = "Donnee enregistree successivement !";
            }
            catch (Exception ex)
            {
                // Une erreur est survenue: on ne valide pas la requête     
                trans.Rollback();
                TempData["text"] = "Requete non effectuee \nErreur: " + ex.Message;
            }
            finally
            {     // Libération des ressources     
                cmd.Dispose();
            }

            return RedirectToAction("Index", "Infirmerie");
        }
    }
}