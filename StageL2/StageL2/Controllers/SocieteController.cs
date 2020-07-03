using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using StageL2.Views.Societe;
using System;
using System.Data;


namespace StageL2.Controllers
{
    public class SocieteController : Controller
    {
        OracleDataReader dr;
        public IActionResult Index()
        {
            return View();
        }

        //Affiche Société à modifier
        public IActionResult AfficheSte(string identifiant)
        {
            FonctionSociete cmpt = new FonctionSociete();
            int nb = cmpt.CompterSte(identifiant);
            if (nb == 1)
            {
                ViewBag.Message1 = identifiant;
                return View();
            }
            else
            {
                return RedirectToAction("Erreur", "Activite");
            }
        }

        //Affiche Société à Supprimer
        public IActionResult DeleteSte(string identifiant)
        {
            FonctionSociete cmpt = new FonctionSociete();
            int nb = cmpt.CompterSte(identifiant);
            if (nb == 1)
            {
                ViewBag.Message = identifiant;
                return View();
            }
            else
            {
                return RedirectToAction("Erreur", "Activite");
            }
        }

        //Affiche Formulaire à Ajouter
        public IActionResult AddSte()
        {
            return View();
        }

        //Ajout Société
        public IActionResult AjoutSte(string code, string lib, string type, string adr, string date)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            FonctionSociete user2 = new FonctionSociete();
            int cmpt = user2.CompterSte(code);
            if (cmpt == 0)
            {
                if (code != null && lib != null && type != null)
                {
                    OracleCommand cmd = new OracleCommand
                    {
                        CommandText = "INSERT INTO STE ( CODE_STE, LIBELLE, TYPE_CLI, ADRESSE1 ,DATE_SAI) VALUES('" + code + "', '" + lib + "','" + type + "','" + adr + "',sysdate)",
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
                        TempData["text"] = " Societe " + code + " enregistree successivement !";
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
                    TempData["text"] = "Veuillez remplir tous les champs correspondants !";
                }
            }
            else
            {
                TempData["text"] = "Identifiant  " + code + "  existant !! Veuillez en saisir un autre !";
            }
            return RedirectToAction("Index", "Societe");
        }

        //Update Société
        public IActionResult ModifierSte(string code, string lib, string type, string adr, string date)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            FonctionSociete user2 = new FonctionSociete();
            int cmpt = user2.CompterSte(code);
            if (cmpt == 1)
            {
                if (code != null && lib != null && type != null)
                {
                    OracleCommand cmd = new OracleCommand
                    {
                        CommandText = "UPDATE STE SET LIBELLE='" + lib + "' ,TYPE_CLI='" + type + "' , ADRESSE1 ='" + adr + "', DATE_MOD= sysdate  WHERE CODE_STE='" + code + "'",
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
                        Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
                    }
                    finally
                    {     // Libération des ressources     
                        cmd.Dispose();
                    }

                }
                else
                {
                    TempData["text"] = "Veuillez remplir tous les champs correspondants !";
                }
            }
            else
            {
                TempData["text"] = "Societe  " + code + "  introuvable! Veuillez verifier votre saisie !";
            }
            return RedirectToAction("Index", "Societe");
        }

        //Supprimer Société
        public IActionResult SupprimerSte(string code)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            FonctionSociete user2 = new FonctionSociete();
            int cmpt = user2.CompterSte(code);
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            if (cmpt != 0)
            {
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "DELETE FROM STE WHERE CODE_STE= '" + code + "'",
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
                    TempData["text"] = "Supression reussie de la Societe " + code + " !";
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
                TempData["text"] = "Societe  " + code + "  introuvable !! Veuillez verifier votre saisie !";
            }

            return RedirectToAction("Index", "Societe");
        }
    }
}