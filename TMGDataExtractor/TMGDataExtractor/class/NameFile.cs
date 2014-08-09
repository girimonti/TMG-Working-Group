using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class NameFile : VFPDataAccess
	{
		public NameFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_n.dbf");			

			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM Name;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO Name (NPER,ALTYPE,ISPICKED,INFS,INFG,\"PRIMARY\",NSURE,FSURE,NNOTE,RECNO,SENTENCE,NDATE,SRTDATE,DSURE,DSID,TT,SRNAMESORT,GVNAMESORT,STYLEID,SURID,GIVID,SRNAMEDISP,SNDXSURN,SNDXGVN,PBIRTH,PDEATH,REFER,PREF_ID,LAST_EDIT) ";
							sql += string.Format("VALUES ({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}','{12}','{13}',{14},'{15}','{16}','{17}',{18},{19},{20},'{21}','{22}','{23}','{24}','{25}','{26}',{27},'{28}');",
								 (int)row["NPER"], 								 
								 (int)row["ALTYPE"], 							 
								 (bool)row["ISPICKED"],
								 (bool)row["INFS"],								 
								 (bool)row["INFG"],								 
								 (bool)row["PRIMARY"],
								 row["NSURE"].ToString().Replace("'", "`"),
								 row["FSURE"].ToString().Replace("'", "`"),
								 row["NNOTE"].ToString().Replace("'", "`"),
								 (int)row["RECNO"],
								 row["SENTENCE"].ToString().Replace("'", "`"),
								 row["NDATE"].ToString().Replace("'", "`"),
								 row["SRTDATE"].ToString().Replace("'", "`"),
								 row["DSURE"].ToString().Replace("'", "`"),					 
								 (int)row["DSID"],
								 row["TT"].ToString(),
								 row["SRNAMESORT"].ToString().Replace("'", "`"),
								 row["GVNAMESORT"].ToString().Replace("'", "`"),
								 (int)row["STYLEID"],							 
								 (int)row["SURID"],								 
								 (int)row["GIVID"],
								 row["SRNAMEDISP"].ToString().Replace("'", "`"),
								 row["SNDXSURN"].ToString().Replace("'", "`"),
								 row["SNDXGVN"].ToString().Replace("'", "`"),
								 row["PBIRTH"].ToString().Replace("'", "`"),
								 row["PDEATH"].ToString().Replace("'", "`"),
								 row["REFER"].ToString().Replace("'", "`"),
								 (int)row["PREF_ID"],							 
								 (DateTime)row["LAST_EDIT"]
							);

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("Names Added: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}


