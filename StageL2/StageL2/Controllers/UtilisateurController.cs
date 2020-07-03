using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using StageL2.Views.Utilisateur;
using System;
using System.Data;

namespace StageL2.Controllers
{

    public class UtilisateurController : Controller
    {
        OracleDataReader dr;
        string identifiant;

        //Obtenir l'identifiant de l'utilisateur
        public IActionResult Index(string ID)
        {
            identifiant = ID;
            return View();
        }

        //Affiche formulaire à ajouter
        public IActionResult AddUser()
        {
            return View();
        }

        //Affiche Utilisateur à Modifier
        public IActionResult AfficheUser(string identifiant)
        {
            FonctionUser cmpt = new FonctionUser();
            int nb = cmpt.CompterUser(identifiant);
            if (nb != 0)
            {
                ViewBag.Message = identifiant;
                return View();
            }
            else
            {
                return RedirectToAction("Erreur", "Activite");
            }
        }

        //Ajouter Utilisateur
        public IActionResult AjoutUser(string nom, string ID, string mdp, string groupe, string login, string prest, string statut)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();

            FonctionUser user2 = new FonctionUser();
            int cmpt = user2.CompterUser(ID);
            FonctionUser log = new FonctionUser();
            int nb = log.CompterLogin(login);

            if (cmpt == 0)
            {
                if (nb == 0)
                {
                    OracleCommand cmd = new OracleCommand
                    {
                        CommandText = "INSERT INTO UTILISATEUR (IDENTIFIANT, PASSWORD , GROUPE, LOGIN ,CODE_PREST ,NOM ,DATE_SAI,STATUT) VALUES('" + ID + "', '" + mdp + "','" + groupe + "','" + login + "','" + prest + "', '" + nom + "', sysdate, '" + statut + "')",
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
                        TempData["text"] = " Utilisateur " + ID + " enregistre successivement !";

                    }
                    catch (Exception ex)
                    {
                        // Une erreur est survenue: on ne valide pas la requête     
                        trans.Rollback();
                        TempData["text"] = "Erreur de requete " + ex + "";
                    }
                    finally
                    {     // Libération des ressources     
                        cmd.Dispose();
                    }
                }

                else
                {
                    TempData["text"] = "Login < " + login + " > existant !! Veuillez en saisir un autre !";
                }
            }
            else
            {
                TempData["text"] = "Identifiant " + ID + " existant !! Veuillez en saisir un autre !";
            }
            return RedirectToAction("Index", "Utilisateur");
        }


        //Modifier Utilisateur
        public IActionResult ModifierUser(string nom, string ID, string mdp, string groupe, string login, string prest, string statut)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            FonctionUser user2 = new FonctionUser();
            int cmpt = user2.CompterUser(ID);
            if (cmpt == 1)
            {
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "UPDATE UTILISATEUR SET NOM='" + nom + "' ,PASSWORD='" + mdp + "' ,GROUPE='" + groupe + "',LOGIN='" + login + "',CODE_PREST='" + prest + "',DATE_MOD = sysdate , MODIFIANT ='" + identifiant + "', STATUT= '" + statut + "' WHERE IDENTIFIANT='" + ID + "'",
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
                    TempData["text"] = "Erreur de requete " + ex + "";
                }
                finally
                {     // Libération des ressources     
                    cmd.Dispose();

                }
            }
            else
            {
                TempData["text"] = "Identifiant " + ID + " introuvable !! Veuillez verifier votre saisie !";
            }
            return RedirectToAction("Index", "Utilisateur");
        }


        public IActionResult AfficherPrestUser(string CodeAct)
        {
            ViewBag.Message = CodeAct;
            return View();
        }
    }
}