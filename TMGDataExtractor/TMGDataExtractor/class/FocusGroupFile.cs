using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class FocusGroupFile : VFPDataAccess
	{
		public FocusGroupFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_o.dbf");			

			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM FocusGroup;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO FocusGroup (GROUPNUM,GROUPNAME,RECENT,TT) ";
							sql += string.Format("VALUES ({0},'{1}','{2}','{3}');",
								(int)row["GROUPNUM"],
								row["GROUPNAME"].ToString().Replace("'","`"),
								(bool)row["RECENT"],
								row["TT"].ToString()
							);

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("Focus Groups Added: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}


