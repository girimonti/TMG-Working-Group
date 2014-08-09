using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class TimelineLockFile : VFPDataAccess
	{
		public TimelineLockFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_k.dbf");			

			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM TimelineLock;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO TimelineLock (IDLOCK,TNAME,DSID,TT) ";
							sql += string.Format("VALUES ({0},'{1}',{2},'{3}');",
									(int)row["IDLOCK"],
									row["TNAME"].ToString().Replace("'","`"),
									(int)row["DSID"],
									row["TT"].ToString().Replace("'","`")
							);

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("Timeline Locks: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}

