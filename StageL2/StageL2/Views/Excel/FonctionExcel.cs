using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.OleDb;

namespace StageL2.Views.Excel
{
    public class FonctionExcel
    {

        DataTable dt;
        OracleDataReader listeNum;
        OracleDataReader dr;

        public DataTable Readfile(string nomFichier, string nomfeuil)
        {
            if (nomfeuil != string.Empty && nomFichier != string.Empty)
            {
                string ExcelConnectionStr = "Provider=Microsoft.ACE.OLEDB.12.0;"
                + "Data Source= '" + nomFichier + "';"
                + " Extended Properties= \"Excel 12.0;\"";
                OleDbConnection con = new OleDbConnection(ExcelConnectionStr);
                OleDbDataAdapter da = new OleDbDataAdapter();

                con.Open();
                OleDbCommand cmdSelect = new OleDbCommand("SELECT * FROM [" + nomfeuil + "$]", con);
                da.SelectCommand = cmdSelect;
                DataSet ds = new DataSet();
                dt = ds.Tables.Add("result");
                da.Fill(ds, "result");
            }
            return dt;
        }

        //Avoir le numero du patient dans la liste du Medecin concerné
        public int GetNums(string identifiant, string dateFreq)
        {
            Int32 num = 0;
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT COUNT(IDENTIFIANT) + 1 FROM FREQMALA_JDE WHERE IDENTIFIANT = '" + identifiant + "' AND TO_DATE('" + dateFreq + "', 'DD/MM/YY HH24:MI:SS') = TO_DATE(DFREQ, 'DD/MM/YY')",
                Connection = conn,
                CommandType = CommandType.Text
            };
            dr = cmd.ExecuteReader();
            dr.Read();
            num = dr.GetInt32(0);
            return num;
        }

        //Vérifie l'existance du Medecin concerné
        public bool GetIdentifiantFreq(string ID)
        {
            bool val = false;
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT IDENTIFIANT FROM UTILISATEUR WHERE CODE_PREST is not null ",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                listeNum = cmd.ExecuteReader();
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

            while (listeNum.Read())
            {
                if (ID == listeNum.GetString(0))
                {
                    return val = true;
                }
            }
            return val;
        }
        public bool getNums(int num, string identifiant)
        {
            DBConnect c = new DBConnect();
            OracleConnection conn = c.GetConnection();
            bool val = true;
            conn.Open();
            OracleTransaction trans = conn.BeginTransaction();
            OracleCommand cmd = new OracleCommand
            {
                CommandText = "SELECT NUMERO FROM FREQMALA_JDE WHERE TO_DATE(DFREQ, 'DD/MM/YYYY') = TO_DATE(SYSDATE, 'DD/MM/YYYY') AND IDENTIFIANT = '" + identifiant + "'",
                Connection = conn,
                CommandType = CommandType.Text
            };
            try
            {
                // Exécution de la requête     
                listeNum = cmd.ExecuteReader();
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
            if (listeNum.HasRows)
            {
                while (listeNum.Read())
                {
                    if (num == listeNum.GetInt16(0))
                    {
                        return val = false;
                    }
                }
            }
            return val;

        }
    }
}
