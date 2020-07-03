using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using StageL2.Views.Certificat;
using System;
using System.Data;

namespace StageL2.Controllers
{
    public class CertificatController : Controller
    {
        OracleDataReader dr;
        public IActionResult Index()
        {
            return View();
        }

        //Affiche la vue pour ajouter un certificat
        public IActionResult Addcertificat()
        {
            return View();
        }

        //Affiche la liste de la famille de l'agent (recherche)
        public IActionResult AfficheFamille(string agent)
        {
            if (agent != null)
            {
                Fonctioncert cmpt = new Fonctioncert();
                int nb = cmpt.CompterAgent(agent);
                if (nb != 0)
                {
                    ViewBag.Message = agent;
                    return View();
                }
                else
                {
                    return RedirectToAction("Erreur", "Activite");
                }
            }
            else
            {
                return RedirectToAction("Fin", "Frequentation");
            }
        }

        //Ajouter certificat
        public IActionResult Ajoutcert(string matr, string nom, string nvmatr, int type, char certCelib, char certScol, string annee)
        {
            char oui = 'O';
            char non = 'N';

            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            Fonctioncert user1 = new Fonctioncert();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();

            Int32 nvmatricule = user1.ComptCertNvMatr(nvmatr);
            Int32 matricule = user1.ComptCertMatr(matr);

            Fonctioncert cert = new Fonctioncert();
            Int32 certC = cert.VerifierCertCelib(nom, annee, type);
            Int32 certS = cert.VerifierCertScol(nom, annee, type);

            if (nvmatricule != 0 || matricule != 0) /*si le matricule ou nvmatricule existe*/
            {
                if (certCelib.Equals(oui) && certScol.Equals(non)) /*insérer célibat*/
                {
                    if (certC == 0 && certS == 0)
                    {
                        OracleCommand cmd = new OracleCommand
                        {
                            CommandText = "INSERT INTO CERTIFICAT_AG (MATR, MATR_NOUV, TYPAT, CERT_CELIB , ANNEE_CERT ,DATE_SAI, CERT_SCOL, NOM) VALUES('" + matr + "' ,'" + nvmatr + "','" + type + "','O','" + annee + "', sysdate, 'N' , '" + nom + "')",
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
                            TempData["text"] = " Certificat de celibat de " + nom + " , annee : " + annee + " enregistre successivement ! ";
                        }
                        catch (Exception ex)
                        {
                            // Une erreur est survenue: on ne valide pas la requête     
                            trans.Rollback();
                            TempData["text"] = "Requête non effectuée !!\nErreur: '" + ex.Message;
                        }
                        finally
                        {     // Libération des ressources     
                            cmd.Dispose();
                        }
                    }
                    else if (certC == 0 && certS == 1)
                    {

                        OracleCommand cmd = new OracleCommand
                        {
                            CommandText = "UPDATE CERTIFICAT_AG SET CERT_CELIB = 'O', DATE_SAI = sysdate WHERE NOM = '" + nom + "' AND TYPAT = '" + type + "' AND ANNEE_CERT = '" + annee + "' AND (MATR = '" + matr + "' OR MATR_NOUV = '" + nvmatr + "')",
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
                            TempData["text"] = "  Certificat de celibat de " + nom + " , annee : " + annee + " enregistre successivement ! ";
                        }
                        catch (Exception ex)
                        {
                            // Une erreur est survenue: on ne valide pas la requête     
                            trans.Rollback();
                            TempData["text"] = "Requête non effectuée !!\nErreur: '" + ex.Message;
                        }
                        finally
                        {     // Libération des ressources     
                            cmd.Dispose();
                        }
                    }
                    else
                    {
                        TempData["text"] = "  Certificat de celibat de " + nom + " , annee : " + annee + " deja remis ! ";
                    }
                }
                else if (certScol.Equals(oui) && certCelib.Equals(non)) /* insérer scolat*/
                {
                    if (certC == 0 && certS == 0)
                    {
                        OracleCommand cmd = new OracleCommand
                        {
                            CommandText = "INSERT INTO CERTIFICAT_AG (MATR, MATR_NOUV, TYPAT, CERT_SCOL , ANNEE_CERT , DATE_SAI, CERT_CELIB, NOM) VALUES('" + matr + "' ,'" + nvmatr + "','" + type + "','O','" + annee + "', sysdate, 'N' , '" + nom + "')",
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
                            TempData["text"] = " Certificat de scolarite de " + nom + " , annee : " + annee + " enregistre successivement ! ";
                        }
                        catch (Exception ex)
                        {
                            // Une erreur est survenue: on ne valide pas la requête     
                            trans.Rollback();
                            TempData["text"] = "Requête non effectuée !!\nErreur: '" + ex.Message;
                        }
                        finally
                        {     // Libération des ressources     
                            cmd.Dispose();
                        }
                    }
                    else if (certC == 1 && certS == 0)
                    {
                        OracleCommand cmd = new OracleCommand
                        {
                            CommandText = "UPDATE CERTIFICAT_AG SET CERT_SCOL = 'O', DATE_SAI = sysdate WHERE NOM = '" + nom + "' AND TYPAT = '" + type + "' AND ANNEE_CERT = '" + annee + "' AND (MATR = '" + matr + "' OR MATR_NOUV = '" + nvmatr + "')",
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
                            TempData["text"] = " Certificat de scolarite de " + nom + " , annee : " + annee + " enregistre successivement !  ";
                        }
                        catch (Exception ex)
                        {
                            // Une erreur est survenue: on ne valide pas la requête     
                            trans.Rollback();
                            TempData["text"] = "Requête non effectuée !!\nErreur: '" + ex.Message ;
                        }
                        finally
                        {     // Libération des ressources     
                            cmd.Dispose();
                        }
                    }
                    else
                    {
                        TempData["text"] = "  Certificat de scolarite de " + nom + " , annee : " + annee + " deja remis ! ";
                    }
                }
                else if (certScol.Equals(oui) && certCelib.Equals(oui)) //Cocher certificat de celibat et scolarité en même temps
                {
                    if (certC == 0 && certS == 0)
                    {
                        OracleCommand cmd = new OracleCommand
                        {
                            CommandText = "INSERT INTO CERTIFICAT_AG (MATR, MATR_NOUV, TYPAT, CERT_SCOL, CERT_CELIB, ANNEE_CERT, DATE_SAI, NOM) VALUES('" + matr + "', '" + nvmatr + "', '" + type + "', 'O', 'O', '" + annee + "', sysdate , '"+ nom + "')",
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
                            TempData["text"] = " Certificat de scolarite et de celibat de " + nom + " , annee : " + annee + " enregistres successivement ! ";
                        }
                        catch (Exception ex)
                        {
                            // Une erreur est survenue: on ne valide pas la requête     
                            trans.Rollback();
                            TempData["text"] = "Requête non effectuée !!\nErreur: '" + ex.Message;
                        }
                        finally
                        {     // Libération des ressources     
                            cmd.Dispose();
                        }
                    }
                    else if (certC == 1 && certS == 0)
                    {
                        OracleCommand cmd = new OracleCommand
                        {
                            CommandText = "UPDATE CERTIFICAT_AG SET CERT_SCOL = 'O', DATE_SAI = SYSDATE WHERE NOM = '" + nom + "' AND TYPAT = '" + type + "' AND ANNEE_CERT = '" + annee + "' AND (MATR = '" + matr + "' OR MATR_NOUV = '" + nvmatr + "')",
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
                            TempData["text"] = "Certificat de celibat deja remis ! | | Certificat de scolarite de " + nom + " , annee : " + annee + " enregistre successivement ! ";
                        }
                        catch (Exception ex)
                        {
                            // Une erreur est survenue: on ne valide pas la requête     
                            trans.Rollback();
                            TempData["text"] = "Requête non effectuée !!\nErreur: '" + ex.Message;
                        }
                        finally
                        {     // Libération des ressources     
                            cmd.Dispose();
                        }
                    }
                    else if (certC == 0 && certS == 1)
                    {
                        OracleCommand cmd = new OracleCommand
                        {
                            CommandText = "UPDATE CERTIFICAT_AG SET CERT_CELIB = 'O', DATE_SAI = SYSDATE WHERE NOM = '" + nom + "' AND TYPAT = '" + type + "' AND ANNEE_CERT = '" + annee + "' AND (MATR = '" + matr + "' OR MATR_NOUV = '" + nvmatr + "')",
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
                            TempData["text"] = "Certificat de scolarite deja remis ! | | Certificat de celibat de " + nom + " , annee : " + annee + " enregistre successivement ! ";
                        }
                        catch (Exception ex)
                        {
                            // Une erreur est survenue: on ne valide pas la requête     
                            trans.Rollback();
                            TempData["text"] = "Requête non effectuée !!\nErreur: '" + ex.Message;
                        }
                        finally
                        {     // Libération des ressources     
                            cmd.Dispose();
                        }
                    }
                    else if (certC == 1 && certS == 1)
                    {
                        TempData["text"] = "Certificats de scolarite et de celibat de " + nom + " , annee : " + annee + " deja remis !";
                    }
                }
                else if (certScol.Equals(non) && certCelib.Equals(non))
                {
                    TempData["text"] = "Veuillez selectionner au moins un certificat a ajouter !";
                }
            }
            else
            {
                TempData["text"] = "Matricule introuvable !! Veuillez verifier votre saisie !";
            }
            return RedirectToAction("Index", "Certificat");
        }
    }
}