using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using StageL2.Views.Activite;
using System;
using System.Data;

namespace StageL2.Controllers
{
    public class ActiviteController : Controller
    {
        OracleDataReader dr;
        public IActionResult Index()
        {
            return View();
        }

        //Affiche "Ajout activité"
        public IActionResult AjouterAct()
        {
            return View();
        }

        //Affichée ou cas ou l'identifiant n'existe pas
        public IActionResult Erreur()
        {
            return View();
        }

        //Ajout activité
        public IActionResult AjoutAct(string code, string libelle)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            FonctionAct sa = new FonctionAct();
            int cmpt = sa.CompterAct(code);
            if (cmpt == 0)
            {

                    OracleCommand req = new OracleCommand
                    {
                        CommandText = "INSERT INTO ACTIVITE (CODE_ACT, LIBELLE, DATE_SAI) VALUES('" + code + "', '" + libelle + "' , sysdate)",
                        Connection = conn,
                        CommandType = CommandType.Text
                    };
                    try
                    {
                        // Exécution de la requête     
                        dr = req.ExecuteReader();
                        // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                        trans.Commit();
                        conn.Close();
                        TempData["text"] = " Activite " + code + " enregistree successivement!";
                    }
                    catch (Exception ex)
                    {
                        // Une erreur est survenue: on ne valide pas la requête     
                        trans.Rollback();
                        Console.WriteLine("Requête non effectuée !!\nErreur: '" + ex.Message);
                    }
                    finally
                    {     // Libération des ressources     
                        req.Dispose();
                    }            
            }
            else
            {
                TempData["text"] = "Identifiant " + code + "  existant! Veuillez en saisir un autre!";
            }
            return RedirectToAction("Index", "Activite");
        }

        //Affiche activité à supprimer avec ajax
        public IActionResult AfficheAct(string code)
        {
            FonctionAct cmpt = new FonctionAct();
            int nb = cmpt.CompterAct(code);
            if (nb != 0)
            {
                ViewBag.Message = code;
                return View();
            }
            else
            {
                return RedirectToAction("Erreur", "Activite");
            }
        }

        //Affiche activité à modifier avec ajax
        public IActionResult ModifierAct(string code, string libelle)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            FonctionAct prest = new FonctionAct();
            int cmpt = prest.CompterAct(code);
            if (cmpt != 0)
            {

                    OracleCommand req = new OracleCommand
                    {
                        CommandText = "UPDATE ACTIVITE SET LIBELLE='" + libelle + "', DATE_MOD = sysdate WHERE CODE_ACT ='" + code + "'",
                        Connection = conn,
                        CommandType = CommandType.Text
                    };
                    try
                    {
                        // Exécution de la requête     
                        dr = req.ExecuteReader();
                        // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                        trans.Commit();
                        conn.Close();
                        TempData["text"] = "Modification reussie !";
                    }
                    catch (Exception ex)
                    {
                        // Une erreur est survenue: on ne valide pas la requête     
                        trans.Rollback();
                        Console.WriteLine("Requête non effectuée !!\nErreur: '" + ex.Message);
                    }
                    finally
                    {     // Libération des ressources     
                        req.Dispose();
                    }
            }
            else
            {
                TempData["text"] = "Activite  " + code + "  introuvable! Veuillez verifier votre saisie !";
            }
            return RedirectToAction("Index", "Activite");
        }

        //Affiche l'activité à supprimer
        public IActionResult DeleteAct(string code)
        {
            FonctionAct cmpt = new FonctionAct();
            int nb = cmpt.CompterAct(code);
            if (nb == 1)
            {
                ViewBag.Message = code;
                return View();
            }
            else
            {
                return RedirectToAction("Erreur", "Activite");
            }
        }

        //Supprime activité
        public IActionResult SupprimerAct(string code)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            FonctionAct sa = new FonctionAct();
            int cmpt = sa.CompterAct(code);
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            if (cmpt == 1)
            {
                OracleCommand req = new OracleCommand
                {
                    CommandText = "DELETE FROM ACTIVITE WHERE CODE_ACT= '" + code + "'",
                    Connection = conn,
                    CommandType = CommandType.Text
                };
                try
                {
                    // Exécution de la requête     
                    dr = req.ExecuteReader();
                    // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                    trans.Commit();
                    conn.Close();
                    TempData["confirm"] = "Supression reussie de l'activite " + code + "!";
                }
                catch (Exception ex)
                {
                    // Une erreur est survenue: on ne valide pas la requête     
                    trans.Rollback();
                    Console.WriteLine("Requête non effectuée !!\nErreur: '" + ex.Message);
                }
                finally
                {     // Libération des ressources     
                    req.Dispose();
                }
            }
            else
            {
                TempData["confirm"] = "Activite " + code + " introuvable! Veuillez verifier votre saisie!";
            }
            return RedirectToAction("Index", "Activite");
        }
    }
}