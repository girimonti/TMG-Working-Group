using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class EventWitnessFile : VFPDataAccess
	{
		public EventWitnessFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_e.dbf");			
			
			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM EventWitness;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO EventWitness (EPER,GNUM,\"PRIMARY\",WSENTENCE,TT,ROLE,DSID,NAMEREC,WITMEMO,SEQUENCE) ";
							sql += string.Format("VALUES({0},{1},'{2}','{3}','{4}','{5}',{6},{7},'{8}',{9});",
							(int)row["EPER"],
							(int)row["GNUM"],
							(bool)row["PRIMARY"],
							row["WSENTENCE"].ToString(),
							row["TT"].ToString(),
							row["ROLE"].ToString(),
							(int)row["DSID"],
							(int)row["NAMEREC"],
							row["WITMEMO"].ToString(),
							(int)row["SEQUENCE"]);

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("Event Witnesses Added: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}


