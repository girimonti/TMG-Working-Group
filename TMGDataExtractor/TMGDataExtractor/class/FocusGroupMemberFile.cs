using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class FocusGroupMemberFile : VFPDataAccess
	{
		public FocusGroupMemberFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_b.dbf");			

			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM FocusGroupMember;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO FocusGroupMember (GROUPNUM,MEMBERNUM,TT,DSID) ";
							sql += string.Format("VALUES ({0},{1},'{2}',{3});",
								(int)row["GROUPNUM"],
								(int)row["MEMBERNUM"],
								row["TT"].ToString(),
								(int)row["DSID"]
							);

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("Focus Group Members Added: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}


