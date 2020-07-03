using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using StageL2.Views.Excel;
using StageL2.Views.Frequentation;
using System;
using System.Data;


namespace StageL2.Controllers
{
    public class ExcelController : Controller
    {
        OracleDataReader rdr;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AfficherTable(string nomFich, string nomFeuil)
        {
            ViewBag.Message1 = nomFich;
            ViewBag.Message = nomFeuil;
            return View();
        }
        //Chargement des données dans un fichier excel dans la base de données
        //Chargement des données dans un fichier excel dans la base de données
        public IActionResult AjoutDataOracle(string nomFich, string nomFeuil)
        {
            //Connexion fichier excel
            FonctionExcel vers1 = new FonctionExcel();
            DataTable table = vers1.Readfile(nomFich, nomFeuil);

            //Connexion base de données
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            //Ouverture de la transaction
            OracleTransaction trans = conn.BeginTransaction();


            //Creation objet user1 de la fonction dans la fréquentation
            FonctionFreq user1 = new FonctionFreq();


            //Appel de la focnction getnums
            FonctionExcel a = new FonctionExcel();

            //Déclaration des variable 
            string interne = "INTERNE";
            string externe = "EXTERNE";

            //Boucle qui compte le nombre de ligne dans le fichier excel
            for (int i = 0; i < table.Rows.Count; i++)
            {
                int num = System.Convert.ToInt32(table.Rows[i]["NUMERO"].ToString());
                bool val = a.getNums(num, table.Rows[i]["IDENTIFIANT"].ToString());
                bool valId = a.GetIdentifiantFreq(table.Rows[i]["IDENTIFIANT"].ToString());
                int freq = user1.IDFreq();
                //VERIFIE SI LE NUMERO EST DEJA UTILISE DANS LE MEDECIN
                if (valId)
                {
                    //VERIFIE SI L UTILISATEUR AFFECTER POSSEDE UNE CODE PRESTATION
                    if (val)
                    {
                        string typecli = table.Rows[i]["TYPE_CLI"].ToString().ToUpper();
                        //Conversion des types string en entier
                        string datefreq = table.Rows[i]["DFREQ"].ToString();
                        string datenais = table.Rows[i]["DNAIS"].ToString();
                        if (interne.Equals(typecli))
                        {
                            int matr = System.Convert.ToInt32(table.Rows[i]["MATR"].ToString());
                            int etab = System.Convert.ToInt32(table.Rows[i]["ETAB"].ToString());
                            int typat = System.Convert.ToInt32(table.Rows[i]["TYPAT"].ToString());
                            int age = System.Convert.ToInt32(table.Rows[i]["AGE"].ToString());

                            OracleCommand cmd = new OracleCommand
                            {
                                CommandText = "INSERT INTO FREQMALA_JDE(FREQMALA, NUMERO , MATR , ETAB , IDENTIFIANT  , STE , TYPE_CLI , TYPAT , CODE_ACT , CODE_PREST , NAT_CONSULT , SA , NOM , DNAIS , ADRESSE, SEXE, AGE, DFREQ ) VALUES('" + freq + "' , '" + num + "' , '" + matr + "' ,'" + etab + "', '" + table.Rows[i]["IDENTIFIANT"].ToString() + "' , '" + table.Rows[i]["STE"].ToString() + "' , '" + table.Rows[i]["TYPE_CLI"].ToString() + "' , '" + typat + "', '" + table.Rows[i]["CODE_ACT"].ToString() + "' , '" + table.Rows[i]["CODE_PREST"].ToString() + "' , '" + table.Rows[i]["NAT_CONSULT"].ToString() + "' , '" + table.Rows[i]["SA"].ToString() + "' , '" + table.Rows[i]["NOM"].ToString() + "', TO_DATE('" + datenais + "', 'DD/MM/YYYY HH24:MI:SS') , '" + table.Rows[i]["ADRESSE"].ToString() + "' , '" + table.Rows[i]["SEXE"].ToString() + "', '" + age + "' ,TO_DATE('" + datefreq + "', 'DD/MM/YYYY HH24:MI:SS') )",
                                Connection = conn,
                                CommandType = CommandType.Text
                            };
                            try
                            {
                                // Exécution de la requête     
                                rdr = cmd.ExecuteReader();
                                // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                                trans.Commit();
                                TempData["text"] = "Chargement des donnees reussie";

                            }
                            catch (Exception ex)
                            {
                                // Une erreur est survenue: on ne valide pas la requête     
                                TempData["text"] = "Requete non effectuee \nErreur: " + ex.Message;
                            }
                            finally
                            {     // Libération des ressources     
                                cmd.Dispose();
                            }
                        }
                        else if (externe.Equals(typecli))
                        {

                            int age = System.Convert.ToInt32(table.Rows[i]["AGE"].ToString());
                            OracleCommand cmd1 = new OracleCommand
                            {
                                CommandText = "INSERT INTO FREQMALA_JDE(FREQMALA, NUMERO , IDENTIFIANT  , STE , TYPE_CLI , CODE_ACT , CODE_PREST , NAT_CONSULT , NOM , DNAIS , ADRESSE, SEXE, AGE, DFREQ ) VALUES('" + freq + "' , '" + num + "' , '" + table.Rows[i]["IDENTIFIANT"].ToString() + "' , '" + table.Rows[i]["STE"].ToString() + "' , '" + table.Rows[i]["TYPE_CLI"].ToString() + "' , '" + table.Rows[i]["CODE_ACT"].ToString() + "' , '" + table.Rows[i]["CODE_PREST"].ToString() + "' , '" + table.Rows[i]["NAT_CONSULT"].ToString() + "' , '" + table.Rows[i]["NOM"].ToString() + "', TO_DATE('" + datenais + "', 'DD/MM/YYYY HH24:MI:SS') , '" + table.Rows[i]["ADRESSE"].ToString() + "' , '" + table.Rows[i]["SEXE"].ToString() + "', '" + age + "' ,TO_DATE('" + datefreq + "', 'DD/MM/YYYY HH24:MI:SS') )",
                                Connection = conn,
                                CommandType = CommandType.Text
                            };
                            try
                            {

                                // Exécution de la requête     
                                rdr = cmd1.ExecuteReader();
                                // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                                trans.Commit();
                                TempData["text"] = "Chargement des donnees reussie";

                            }
                            catch (Exception ex)
                            {
                                // Une erreur est survenue: on ne valide pas la requête     
                                TempData["text"] = "Requete non effectuee \nErreur: " + ex.Message;
                            }
                            finally
                            {     // Libération des ressources     
                                cmd1.Dispose();
                            }

                            TempData["text"] = "Chargement reussie";
                        }
                        else
                        {
                            TempData["text"] = "Le type societe est inexistant sur la ligne " + i + " , veuillez la modifier";
                            return RedirectToAction("Index", "Frequentation");
                        }

                    }
                    else
                    {
                        TempData["text"] = "NUMERO EXISTANT  SUR LA LIGNE " + i + " DANS LE MEDECIN AFFECTE, VEUILLEZ LA MODIFIER";
                        return RedirectToAction("Index", "Frequentation");
                    }
                }
                else
                {

                    TempData["text"] = "Utilisateur ne possede pas une prestation sur la ligne " + i + ", veuillez-la modifiee  ";
                    return RedirectToAction("Index", "Frequentation");
                }

            }
            return RedirectToAction("Index", "Frequentation");
        }
    }
}