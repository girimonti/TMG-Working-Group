using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class EventFile : VFPDataAccess
	{
		public EventFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = GetOleDbDataReader("*_g.dbf");			
			
			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM Event;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO Event (ETYPE,DSID,PER1SHOW,PER2SHOW,PER1,PER2,EDATE,PLACENUM,EFOOT,ENSURE,ESSURE,EDSURE,EPSURE,EFSURE,RECNO,SENTENCE,SRTDATE,TT,REF_ID) ";
							sql += string.Format("VALUES({0},{1},'{2}','{3}',{4},{5},'{6}',{7},'{8}','{9}','{10}','{11}','{12}','{13}',{14},'{15}','{16}','{17}',{18});",
							(int)row["ETYPE"],
							(int)row["DSID"],
							(bool)row["PER1SHOW"],
							(bool)row["PER2SHOW"],
							(int)row["PER1"],
							(int)row["PER2"],
							row["EDATE"].ToString(),
							(int)row["PLACENUM"],
							row["EFOOT"].ToString().Replace("'","`"),
							row["ENSURE"].ToString(),
							row["ESSURE"].ToString(),
							row["EDSURE"].ToString(),
							row["EPSURE"].ToString(),
							row["EFSURE"].ToString(),
							(int)row["RECNO"],
							row["SENTENCE"].ToString(),
							row["SRTDATE"].ToString(),
							row["TT"].ToString(),
							(int)row["REF_ID"]);

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();

							Tracer("Events Added: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}


