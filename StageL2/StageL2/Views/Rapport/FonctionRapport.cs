using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace StageL2.Views.Rapport
{
    public class FonctionRapport
    {
        OracleDataReader Rdr;
        //Vérifie l'existence d'une Frequentation de l'année indiquée
        public int CompterAnnee(string anneeR)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            Int32 nb;
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(FREQMALA) FROM FREQMALA_JDE WHERE EXTRACT(YEAR FROM DFREQ) = '" + anneeR + "'",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                Rdr = cmd.ExecuteReader();
                // On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
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
            Rdr.Read();
            nb = Rdr.GetInt32(0);
            return nb;
        }

        //Rapport des patients Femmes
        public int[] RapportFemme(string anneeR)
        {
            int[] tabFemme = new int[12];
            int i = 0;
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(NUMERO) FROM FREQMALA_JDE WHERE SEXE = 'F' AND EXTRACT(YEAR FROM DFREQ) = '" + anneeR + "' GROUP BY EXTRACT(MONTH FROM DFREQ) ORDER BY EXTRACT(MONTH FROM DFREQ) ASC",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                //Exécution de la requête
                Rdr = cmd.ExecuteReader();
                //On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
            }
            catch (Exception ex)
            {
                //Une erreur est survenue: on ne valide pas la requête
                trans.Rollback();
                Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
            }
            finally
            {   
                // Libération des ressources     
                cmd.Dispose();
            }
            while(Rdr.Read())
            {
                tabFemme[i] = Rdr.GetInt32(0);
                i++;
            }
            return tabFemme;
        }

        //Rapport des patients Hommes
        public int[] RapportHomme(string anneeR)
        {
            int[] tabHomme = new int[12];
            int i = 0;
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(NUMERO) FROM FREQMALA_JDE WHERE SEXE = 'H' AND EXTRACT(YEAR FROM DFREQ) = '" + anneeR + "' GROUP BY EXTRACT(MONTH FROM DFREQ) ORDER BY EXTRACT(MONTH FROM DFREQ) ASC",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                //Exécution de la requête
                Rdr = cmd.ExecuteReader();
                //On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
            }
            catch (Exception ex)
            {
                //Une erreur est survenue: on ne valide pas la requête
                trans.Rollback();
                Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
            }
            finally
            {
                // Libération des ressources     
                cmd.Dispose();
            }
            while (Rdr.Read())
            {
                tabHomme[i] = Rdr.GetInt32(0);
                i++;
            }
            return tabHomme;
        }

        //Rapport des patients Internes
        public int[] RapportInterne(string anneeR)
        {
            int[] tabInterne = new int[12];
            int i = 0;
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(NUMERO) FROM FREQMALA_JDE WHERE TYPE_CLI = 'INTERNE' AND EXTRACT(YEAR FROM DFREQ) = '" + anneeR + "' GROUP BY EXTRACT(MONTH FROM DFREQ) ORDER BY EXTRACT(MONTH FROM DFREQ) ASC",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                //Exécution de la requête
                Rdr = cmd.ExecuteReader();
                //On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
            }
            catch (Exception ex)
            {
                //Une erreur est survenue: on ne valide pas la requête
                trans.Rollback();
                Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
            }
            finally
            {
                // Libération des ressources     
                cmd.Dispose();
            }
            while (Rdr.Read())
            {
                tabInterne[i] = Rdr.GetInt32(0);
                i++;
            }
            return tabInterne;
        }

        //Rapport des patients Externes
        public int[] RapportExterne(string anneeR)
        {
            int[] tabExterne = new int[12];
            int i = 0;
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(NUMERO) FROM FREQMALA_JDE WHERE TYPE_CLI = 'EXTERNE' AND EXTRACT(YEAR FROM DFREQ) = '" + anneeR + "' GROUP BY EXTRACT(MONTH FROM DFREQ) ORDER BY EXTRACT(MONTH FROM DFREQ) ASC",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                //Exécution de la requête
                Rdr = cmd.ExecuteReader();
                //On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
            }
            catch (Exception ex)
            {
                //Une erreur est survenue: on ne valide pas la requête
                trans.Rollback();
                Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
            }
            finally
            {
                // Libération des ressources     
                cmd.Dispose();
            }
            while (Rdr.Read())
            {
                tabExterne[i] = Rdr.GetInt32(0);
                i++;
            }
            return tabExterne;
        }

        //Rapport des patients Enfants
        public int[] RapportEnfant(string anneeR)
        {
            int[] tabEnf = new int[12];
            int i = 0;
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(NUMERO) FROM FREQMALA_JDE WHERE AGE <= 5 AND EXTRACT(YEAR FROM DFREQ) = '" + anneeR + "' GROUP BY EXTRACT(MONTH FROM DFREQ) ORDER BY EXTRACT(MONTH FROM DFREQ) ASC",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                //Exécution de la requête
                Rdr = cmd.ExecuteReader();
                //On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
            }
            catch (Exception ex)
            {
                //Une erreur est survenue: on ne valide pas la requête
                trans.Rollback();
                Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
            }
            finally
            {
                // Libération des ressources     
                cmd.Dispose();
            }
            while (Rdr.Read())
            {
                tabEnf[i] = Rdr.GetInt32(0);
                i++;
            }
            return tabEnf;
        }

        //Rapport des patients Jeune
        public int[] RapportJeune(string anneeR)
        {
            int[] tabJeune = new int[12];
            int i = 0;
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(NUMERO) FROM FREQMALA_JDE WHERE AGE > 6 AND AGE < 25 AND EXTRACT(YEAR FROM DFREQ) = '" + anneeR + "' GROUP BY EXTRACT(MONTH FROM DFREQ) ORDER BY EXTRACT(MONTH FROM DFREQ) ASC",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                //Exécution de la requête
                Rdr = cmd.ExecuteReader();
                //On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
            }
            catch (Exception ex)
            {
                //Une erreur est survenue: on ne valide pas la requête
                trans.Rollback();
                Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
            }
            finally
            {
                // Libération des ressources     
                cmd.Dispose();
            }
            while (Rdr.Read())
            {
                tabJeune[i] = Rdr.GetInt32(0);
                i++;
            }
            return tabJeune;
        }

        //Rapport des patients Jeune
        public int[] RapportAdulte(string anneeR)
        {
            int[] tabAd = new int[12];
            int i = 0;
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(NUMERO) FROM FREQMALA_JDE WHERE AGE > 25 AND EXTRACT(YEAR FROM DFREQ) = '" + anneeR + "' GROUP BY EXTRACT(MONTH FROM DFREQ) ORDER BY EXTRACT(MONTH FROM DFREQ) ASC",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                //Exécution de la requête
                Rdr = cmd.ExecuteReader();
                //On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
            }
            catch (Exception ex)
            {
                //Une erreur est survenue: on ne valide pas la requête
                trans.Rollback();
                Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
            }
            finally
            {
                // Libération des ressources     
                cmd.Dispose();
            }
            while (Rdr.Read())
            {
                tabAd[i] = Rdr.GetInt32(0);
                i++;
            }
            return tabAd;
        }

        //Rapport des patients par Année (pie chart)
        public int[] RapportParAnnee()
        {
            int[] tab = new int[8];
            int i = 0;
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(FREQMALA) FROM FREQMALA_JDE GROUP BY EXTRACT(YEAR FROM DFREQ) ORDER BY EXTRACT(YEAR FROM DFREQ) ASC",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                //Exécution de la requête
                Rdr = cmd.ExecuteReader();
                //On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
            }
            catch (Exception ex)
            {
                //Une erreur est survenue: on ne valide pas la requête
                trans.Rollback();
                Console.WriteLine("Requête non effectuée !!\nErreur: '" + ex.Message);
            }
            finally
            {
                // Libération des ressources     
                cmd.Dispose();
            }
            while (Rdr.Read())
            {
                tab[i] = Rdr.GetInt32(0);
                i++;
            }
            return tab;
        }

        //Rapport des patients Externes
        public int[] RapportGetAnnee()
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();

            int[] tabAnnee = new int[8];
            int i = 0;

            OracleTransaction trans = conn.BeginTransaction();

            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT EXTRACT(YEAR FROM DFREQ) FROM FREQMALA_JDE GROUP BY EXTRACT(YEAR FROM DFREQ) ORDER BY EXTRACT(YEAR FROM DFREQ) ASC",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                //Exécution de la requête
                Rdr = cmd.ExecuteReader();
                //On soumet la requête au serveur: tout s'est bien déroulé , la requête est exécutée    
                trans.Commit();
            }
            catch (Exception ex)
            {
                //Une erreur est survenue: on ne valide pas la requête
                trans.Rollback();
                Console.WriteLine("<body><script >alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
            }
            finally
            {
                // Libération des ressources     
                cmd.Dispose();
            }
            while (Rdr.Read())
            {
                tabAnnee[i] = Rdr.GetInt32(0);
                i++;
            }
            return tabAnnee;
        }
    }
}
