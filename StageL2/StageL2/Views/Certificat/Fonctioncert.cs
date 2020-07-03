using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace StageL2.Views.Certificat
{
    public class Fonctioncert
    {
        OracleDataReader dr;

        /// <summary>
        /// Afficher la liste Certificats (table)
        /// </summary>
        public OracleDataReader AfficheCert()
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT MATR_NOUV, MATR, TYPAT, NOM,  ANNEE_CERT, CERT_SCOL, CERT_CELIB , TO_CHAR(DATE_SAI ,'DD/MM/YYYY') FROM CERTIFICAT_AG ORDER BY DATE_SAI DESC",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
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
            return dr;
        }

        /// <summary>
        /// Verifier le certificat de la personne s'il en existe déjà pour l'année concernée
        /// </summary>
        public int VerifierCertScol(string nom, string annee, int type)
        {
            DBConnect d = new DBConnect();
            OracleConnection conn = d.GetConnection();
            int nb = 0;
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(1) FROM CERTIFICAT_AG WHERE NOM = '" + nom + "' AND ANNEE_CERT = '" + annee+ "' AND TYPAT = '" + type + "' AND CERT_SCOL = 'O'",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
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
            dr.Read();
            nb = dr.GetInt16(0);
            return nb;
        }

        //Verifier CERTIFICAT DE CELIBAT FAMILLE s'il en existe déjà pour l'année concernée
        public int VerifierCertCelib(string nom, string annee, int type)
        {
            DBConnect d = new DBConnect();
            OracleConnection conn = d.GetConnection();
            int nb = 0;
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(1) FROM CERTIFICAT_AG WHERE NOM = '" + nom + "' AND ANNEE_CERT = '" + annee + "' AND TYPAT = '" + type + "' AND CERT_CELIB = 'O'",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
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
            dr.Read();
            nb = dr.GetInt16(0);
            return nb;
        }

        //Verifier l'existence de la matricule du Certificat dans JDE
        public int ComptCertMatr(string matr)
        {
            DBConnectJDE d = new DBConnectJDE();
            OracleConnection conn = d.GetConnectionJDE(); /*connexion avec JDE*/
            int nb = 0;
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            //compter matricule 
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(YAOEMP) FROM F55EMPME WHERE YAOEMP= '" + matr + "'",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
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
            dr.Read();
            nb = dr.GetInt16(0);
            return nb;
        }
       
        public int ComptCertNvMatr(string nvmatr)
        {
            DBConnectJDE e = new DBConnectJDE(); /*ito ny connexion amin'ny serveur JDE*/
            OracleConnection Conn = e.GetConnectionJDE();

            //DBConnect d = new DBConnect();
            //OracleConnection connex = d.GetConnection(); /*connexion avec JDE*/
            int nb = 0;
            Conn.Open();
            OracleTransaction trans = Conn.BeginTransaction();
            //compter nouveau matricule
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(YAAN8) FROM F55EMPME WHERE YAAN8 = '" + nvmatr + "' ",
                Connection = Conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
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
            dr.Read();
            nb = dr.GetInt16(0);
            return nb;
        }

        //Verifier Certficat JDE avec nouveau matricule
        public int ComptCertNvMatrInt(int nvmatr)
        {
            DBConnectJDE e = new DBConnectJDE(); /*ito ny connexion amin'ny serveur JDE*/
            OracleConnection Conn = e.GetConnectionJDE();
            int nb = 0;
            Conn.Open();
            OracleTransaction trans = Conn.BeginTransaction();
            //compter nouveau matricule
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(YAAN8) FROM F55EMPME WHERE YAAN8 = '" + nvmatr + "' ",
                Connection = Conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
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
            dr.Read();
            nb = dr.GetInt16(0);
            return nb;
        }

        //Afiche famille agent avec ajax (Recherche Agent)
        public OracleDataReader GetAgent(string agent)
        {
            DBConnectJDE c = new DBConnectJDE();
            OracleConnection conn = c.GetConnectionJDE();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT YAAN8, YAOEMP, YAALPH, YADSC1,  to_char(to_date(to_char(1900 + FLOOR(YATRDJ / 1000)), 'YYYY') + MOD(YATRDJ, 1000) - 1, 'DD-MM-YYYY'), EXTRACT(YEAR FROM SYSDATE)-EXTRACT(YEAR FROM to_date(to_char(1900 + FLOOR(YATRDJ / 1000)), 'YYYY') + MOD(YATRDJ, 1000) - 1 ) AS AGE  FROM F55EMPME WHERE YAOEMP LIKE '%" + agent + "%' OR YAAN8 LIKE '%" + agent + "%' OR YAALPH LIKE '%" + agent + "%' AND EXTRACT(YEAR FROM SYSDATE)-EXTRACT(YEAR FROM TO_DATE(to_char(1900 + FLOOR(YATRDJ / 1000)), 'YYYY') + MOD(YATRDJ, 1000) - 1 ) < 25 ",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = cmd.ExecuteReader();
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
            return dr;
        }

        //Verifier existence Agent
        public int CompterAgent(string agent)
        {
            DBConnectJDE c = new DBConnectJDE();
            OracleConnection conn = c.GetConnectionJDE();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            Int32 nb = 0;
            OracleCommand req = new OracleCommand
            {
                CommandText = "SELECT COUNT(YAALPH) FROM F55EMPME WHERE YAOEMP LIKE '%" + agent + "%' OR YAAN8 LIKE '%" + agent + "%' OR YAALPH LIKE '%" + agent + "%' ",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                dr = req.ExecuteReader();
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
                req.Dispose();
            }
            dr.Read();
            nb = dr.GetInt32(0);
            return nb;
        }
    }
}