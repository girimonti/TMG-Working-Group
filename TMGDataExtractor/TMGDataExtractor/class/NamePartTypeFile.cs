using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class NamePartTypeFile : VFPDataAccess
	{
		public NamePartTypeFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_npt.dbf");			

			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM NamePartType;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO NamePartType (ID,VALUE,SYSTEM,TYPE,SHORTVALUE,TT,DSID,TEMPLATE) ";
							sql += string.Format("VALUES ({0},'{1}','{2}',{3},'{4}','{5}',{6},'{7}');",
									(int)row["ID"],
									row["VALUE"].ToString().Replace("'", "`"),
									(bool)row["SYSTEM"],
									(int)row["TYPE"],
									row["SHORTVALUE"].ToString().Replace("'", "`"),
									row["TT"].ToString(),
									(int)row["DSID"],
									row["TEMPLATE"].ToString().Replace("'", "`")
							);

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("Name Part Types: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}

