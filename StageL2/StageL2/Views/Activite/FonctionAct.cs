using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace StageL2.Views.Activite
{
    public class FonctionAct
    {
        OracleDataReader dr;

        //Affiche prestation table
        public OracleDataReader AfficheAct()
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT CODE_ACT, LIBELLE, TO_CHAR(DATE_SAI, 'DD/MM/YYYY HH24:MI:SS'), TO_CHAR(DATE_MOD, 'DD/MM/YYYY HH24:MI:SS') FROM ACTIVITE ORDER BY DATE_SAI ASC",
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

        //Vérifie l'existance de l'identifiant
        public int CompterAct(string code)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            Int32 nb = 0;
            OracleCommand req = new OracleCommand
            {
                CommandText = "SELECT COUNT(CODE_ACT) AS nb FROM ACTIVITE WHERE CODE_ACT= '" + code + "'",
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

        //Affiche activité avec ajax
        public OracleDataReader AfficherAct(string code)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();

            OracleCommand req = new OracleCommand
            {
                CommandText = "SELECT CODE_ACT, LIBELLE, TO_CHAR(DATE_SAI, 'DD/MM/YYYY HH24:MI:SS') FROM ACTIVITE WHERE CODE_ACT= '" + code + "' ",
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
                Console.WriteLine("<body><script>alert('Requête non effectuée !!\nErreur: '" + ex.Message + "'');</script></body>");
            }
            finally
            {
                // Libération des ressources     
                req.Dispose();
            }
            return dr;
        }
    }
}
