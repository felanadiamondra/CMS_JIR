using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using StageL2.Views.Activite;
using StageL2.Views.Prestation;
using System;
using System.Data;
namespace StageL2.Controllers
{
    public class PrestationController : Controller
    {
        OracleDataReader dr;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AjouterPrest()
        {
            return View();
        }

        //Affiche la Prestation avec ajax à supprimer
        public IActionResult DeletePrest(string code)
        {
            FonctionPrest cmpt = new FonctionPrest();
            int nb = cmpt.CompterPrest(code);
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

        //Affiche Prestation avec ajax à modifier
        public IActionResult AffichePrest(string code)
        {
            FonctionPrest cmpt = new FonctionPrest();
            int nb = cmpt.CompterPrest(code);
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

        //Ajout prestation
        public IActionResult AjoutPrest(string libelle, string code, string act, int puInt, int puExt)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            FonctionPrest prest = new FonctionPrest();
            int cmpt = prest.CompterPrest(code);
            if (cmpt == 0)
            {
                if (code != null && libelle != null && act != null)
                {
                    FonctionAct sa = new FonctionAct();
                    int cmptsa = sa.CompterAct(act);
                    if (cmptsa != 0)
                    {

                        OracleCommand cmd = new OracleCommand
                        {
                            CommandText = "INSERT INTO PRESTAT (CODE_PREST, LIB_PREST, CODE_ACT, PU, PRIX_INT, DATE_SAI) VALUES('" + code + "', '" + libelle + "','" + act + "','" + puExt + "','" + puInt + "' , sysdate)",
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
                            TempData["text"] = " Prestation " + code + " enregistree successivement!";
                        }
                        catch (Exception ex)
                        {
                            // Une erreur est survenue: on ne valide pas la requête     
                            trans.Rollback();
                            Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
                        }
                        finally
                        {     // Libération des ressources     
                            cmd.Dispose();
                        }
                    }
                    else
                    {
                        TempData["text"] = "Activite  " + act + "  introuvable !! Veuillez verifier votre saisie!";
                    }
                }
                else
                {
                    TempData["text"] = "Veuillez-remplir tous les champs correspondants !";
                }
            }
            else
            {
                TempData["text"] = "Identifiant  " + code + "  existant!! Veuillez en saisir un autre!";
            }
            return RedirectToAction("Index", "Prestation");
        }

        //Update Prestation
        public IActionResult ModifierPrest(string libelle, string code, string act, int puInt, int puExt)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            FonctionPrest prest = new FonctionPrest();
            int cmpt = prest.CompterPrest(code);
            if (cmpt == 1)
            {
                if (code != null && libelle != null && act != null)
                {
                    FonctionAct sa = new FonctionAct();
                    int cmptsa = sa.CompterAct(act);
                    if (cmptsa != 0)
                    {
                        OracleCommand cmd = new OracleCommand
                        {
                            CommandText = "UPDATE PRESTAT SET LIB_PREST='" + libelle + "' , CODE_ACT ='" + act + "' , PRIX_INT = '" + puInt + "', PU='" + puExt + "' , DATE_MOD = sysdate WHERE CODE_PREST ='" + code + "'",
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
                            cmd.Dispose();
                        }
                    }
                    else
                    {
                        TempData["text"] = "Activite  " + act + "  introuvable!! Veuillez verifier votre saisie!";
                    }
                }
                else
                {
                    TempData["text"] = "Veuillez remplir tous les champs correspondants!";
                }
            }
            else
            {
                TempData["text"] = "Prestation  " + code + "  introuvable!";
            }
            return RedirectToAction("Index", "Prestation");
        }

        //Supprime Prestation
        public IActionResult Supprimer(string code)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            FonctionPrest prest = new FonctionPrest();
            int cmpt = prest.CompterPrest(code);
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            if (cmpt == 1)
            {
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "DELETE FROM PRESTAT WHERE CODE_PREST= '" + code + "'",
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
                    TempData["confirm"] = "Supression reussie de la prestation  " + code + " !";
                }
                catch (Exception ex)
                {
                    // Une erreur est survenue: on ne valide pas la requête     
                    trans.Rollback();
                    Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
                }
                finally
                {     // Libération des ressources     
                    cmd.Dispose();
                }
            }
            else
            {
                TempData["confirm"] = "Prestation " + code + "  introuvable !! Veuillez verifier votre saisie !";
            }
            return RedirectToAction("Index", "Prestation");
        }
    }
}