using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using StageL2.Views.Frequentation;
using StageL2.Views.Societe;
using System;
using StageL2.Models;
using System.Data;

namespace StageL2.Controllers
{
    public class FrequentationController : Controller
    {
        OracleDataReader dr;

        public IActionResult Index()
        {
            return View();
        }

        //Fin de recherche
        public IActionResult Fin()
        {
            return View();
        }

        //Affiche Type société avec ajax
        public IActionResult AfficherTypeSTE(string codeSte)
        {
            FonctionSociete ste = new FonctionSociete();
            int nb = ste.CompterSte(codeSte);
            if (nb != 0)
            {
                ViewBag.Message = codeSte;
                FonctionFreq fr = new FonctionFreq();
                int t = fr.CompteType(codeSte);
                if (t == 1)
                {
                    return View("Interne", "Frequentation");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Fin", "Frequentation");
            }
        }

        //Affiche l'etat des certificats des patients
        public IActionResult AfficherCert(string nom)
        {
            FonctionFreq cmpt = new FonctionFreq();
            int nb = cmpt.CompterNomPat(nom);
            if (nb != 0)
            {
                ViewBag.Message = nom;
                return View();
            }
            else
            {
                return RedirectToAction("Fin", "Frequentation");
            }
        }

        //Affiche Formulaire Agent interne avec ajax
        public IActionResult Interne()
        {
            return View();
        }

        //Affiche Num patient avec ajax
        public IActionResult AfficherNumero(string codeMed)
        {
            ViewBag.Message = codeMed;
            return View();
        }

        //Affiche JDE avec ajax (table)
        public IActionResult AfficherJDE(string matricule)
        {
            FonctionFreq cmpt = new FonctionFreq();
            int nb = cmpt.CompterAgent(matricule);
            if (nb != 0)
            {
                ViewBag.Message = matricule;
                return View();
            }
            else
            {
                return RedirectToAction("Erreur", "Activite");
            }
        }

        //Affiche Age patient avec ajax 
        public IActionResult AfficherAge(string datenais)
        {
            ViewBag.Message = datenais;
            return View();
        }

        //Affiche Prestation avec ajax (select)
        public IActionResult AfficherPrest(string codeAct)
        {
            ViewBag.Message = codeAct;
            return View();
        }

        //Affiche Medecin avec ajax (select)
        public IActionResult AfficherMed(string codePrest)
        {
            ViewBag.Message = codePrest;
            return View();
        }

        //Affiche agent avec ajax (recherche)
        public IActionResult AfficherAgent(string agent)
        {
            if (agent != null)
            {
                FonctionFreq cmpt = new FonctionFreq();
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

        //Affiche medecin avec ajax (recherche)
        public IActionResult AfficherMedecin(string med)
        {
            if (med != null)
            {
                FonctionFreq cmpt = new FonctionFreq();
                int nb = cmpt.CompterMed(med);
                if (nb != 0)
                {
                    ViewBag.Message = med;
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


        //Ajout Frequentation
        public IActionResult AjoutFreq(string ste, string typeSte, string matr, string nomAG, string SA, int etab, string nomPat, int typePat, string dateNais, int age, char sexe, string adr, int numero, string natConsul, string codeMed, string act, string prest)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();

            FonctionFreq f = new FonctionFreq();
            int id = f.IDFreq();

            OracleTransaction trans = conn.BeginTransaction();
            string type = "INTERNE";
            if (typeSte.Equals(type))
            {
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "INSERT INTO FREQMALA_JDE(FREQMALA, NUMERO , MATR , ETAB , IDENTIFIANT  , STE , TYPE_CLI , TYPAT , CODE_ACT , CODE_PREST , NAT_CONSULT , SA , NOM , DNAIS , ADRESSE, SEXE, AGE, DFREQ ) VALUES('" + id + "' , '" + numero + "' , '" + matr + "' ,'" + etab + "', '" + codeMed + "' , '" + ste + "' , '" + typeSte + "' , '" + typePat + "', '" + act + "' , '" + prest + "' , '" + natConsul + "' , '" + SA + "' , '" + nomPat + "',TO_DATE('" + dateNais + "', 'DD/MM/YYYY') , '" + adr + "' , '" + sexe + "', '" + age + "' , sysdate)",
                    Connection = conn,
                    CommandType = CommandType.Text
                };
                try
                {
                    // Exécution de la requête     
                    dr = cmd.ExecuteReader();
                    // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                    trans.Commit();
                    TempData["text"] = "Insertion reussie";
                    conn.Close();
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
            }
            else
            {
                OracleCommand cmd = new OracleCommand
                {
                    CommandText = "INSERT INTO FREQMALA_JDE(FREQMALA, NUMERO , IDENTIFIANT , STE , TYPE_CLI , CODE_ACT , CODE_PREST , NAT_CONSULT, NOM, DNAIS , ADRESSE, SEXE, AGE, DFREQ ) VALUES('" + id + "' , '" + numero + "' , '" + codeMed + "' , '" + ste + "' , '" + typeSte + "' , '" + act + "' , '" + prest + "' , '" + natConsul + "' , '" + nomPat + "', TO_CHAR(TO_DATE('" + dateNais + "', 'DD/MM/YYYY'), 'DD/MM/YYYY') , '" + adr + "', '" + sexe + "', '" + age + "',  sysdate)",
                    Connection = conn,
                    CommandType = CommandType.Text
                };
                try
                {
                    // Exécution de la requête     
                    dr = cmd.ExecuteReader();
                    // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                    trans.Commit();
                    TempData["text"] = "Insertion reussie";
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
            }
            return RedirectToAction("Index", "Frequentation");
        }

        public IActionResult GetFreq(int ID)
        {
            FonctionFreq cmpt = new FonctionFreq();
            int nb = cmpt.CompterID(ID);
            if (nb != 0)
            {
                ViewBag.Message = ID;
                return View();
            }
            else
            {
                return RedirectToAction("Erreur", "Activite");
            }
        }

        //Afficher le numéro du patient pour la modification
        public IActionResult AfficherNum(string codeMed)
        {
            ViewBag.Message = codeMed;
            return View();
        }

        //Modifier une fréquentation
        public IActionResult UpdateFrequentation(int id ,string med , int num , string nom , int age ,string sexe , string prest, string adr)
        {
           
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();

            FonctionFreq f = new FonctionFreq();

            OracleTransaction trans = conn.BeginTransaction();

            OracleCommand cmd = new OracleCommand
            {
                CommandText ="UPDATE FREQMALA_JDE SET IDENTIFIANT ='"+ med +"' ,NUMERO ='"+ num +"' , NOM='"+ nom +"' , AGE='"+ age +"' , SEXE= '"+ sexe +"' , CODE_PREST='"+ prest +"' , ADRESSE ='"+ adr +"' , DATE_MOD = sysdate WHERE FREQMALA= '"+id+"'",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
                // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
                TempData["text"] = "Modification reussie";
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
            return RedirectToAction("Index", "Frequentation");
        }


        //Recherche patient 
        public IActionResult AfficherPat(string pat)
        {
            if (pat != null)
            {
                FonctionFreq cmpt = new FonctionFreq();
                int nb = cmpt.CompterPat(pat);
                if (nb != 0)
                {
                    ViewBag.Message = pat;
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
    }
}