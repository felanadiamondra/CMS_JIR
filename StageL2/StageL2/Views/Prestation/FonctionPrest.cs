using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;


namespace StageL2.Views.Prestation
{
    public class FonctionPrest
    {
        OracleDataReader dr;

        //Affiche prestation table
        public OracleDataReader AffichePrest()
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT CODE_PREST, LIB_PREST, CODE_ACT, PRIX_INT, PU, TO_CHAR(DATE_SAI, 'DD/MM/YYYY'), TO_CHAR(DATE_MOD, 'DD/MM/YYYY') FROM PRESTAT",
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
                Console.WriteLine("Requête non effectuée !!\nErreur: '" + ex.Message);
            }
            finally
            {     // Libération des ressources     
                cmd.Dispose();
            }
            return dr;
        }

        //Vérifie l'existence de la Prestation
        public int CompterPrest(string code)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            Int32 nb = 0;
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(CODE_PREST) FROM PRESTAT WHERE CODE_PREST= '" + code + "'",
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
                Console.WriteLine("Requête non effectuée !!\nErreur: '" + ex.Message);
            }
            finally
            {     // Libération des ressources     
                cmd.Dispose();
            }
            dr.Read();
            nb = dr.GetInt32(0);
            return nb;
        }

        //Affiche prestation avec ajax
        public OracleDataReader AfficherPrest(string code)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT CODE_PREST, LIB_PREST, CODE_ACT, PRIX_INT, PU, TO_CHAR(DATE_SAI, 'DD/MM/YYYY HH24:MI:SS') FROM PRESTAT WHERE CODE_PREST= '" + code + "' ",
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
                Console.WriteLine("Requête non effectuée !!\nErreur: '" + ex.Message);
            }
            finally
            {     // Libération des ressources     
                cmd.Dispose();
            }
            return dr;
        }

        //Liste les Activités (select)
        public OracleDataReader ListeAct()
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT CODE_ACT, LIBELLE FROM ACTIVITE ORDER BY LIBELLE ASC ",
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
                Console.WriteLine("Requête non effectuée !!\nErreur: '" + ex.Message);
            }
            finally
            {     // Libération des ressources     
                cmd.Dispose();
            }
            return dr;
        }
    }
}
