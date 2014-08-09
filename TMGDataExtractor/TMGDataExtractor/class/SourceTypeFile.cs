using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class SourceTypeFile : VFPDataAccess
	{
		public SourceTypeFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_a.dbf");			

			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM SourceType;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO SourceType (RULESET,DSID,SOURTYPE,TRANS_TO,NAME,FOOT,SHORT,BIB,CUSTFOOT,CUSTSHORT,CUSTBIB,SAMEAS,SAMEASMSG,\"PRIMARY\",REMINDERS,TT) ";
							sql += string.Format("VALUES ({0},{1},{2},{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},'{12}','{13}','{14}','{15}');",
									(decimal)row["RULESET"],
									(int)row["DSID"],
									(int)row["SOURTYPE"],
									(int)row["TRANS_TO"],
									row["NAME"].ToString().Replace("'","`"),
									row["FOOT"].ToString().Replace("'","`"), 
									row["SHORT"].ToString().Replace("'","`"),
									row["BIB"].ToString().Replace("'","`"),
									row["CUSTFOOT"].ToString().Replace("'","`"),
									row["CUSTSHORT"].ToString().Replace("'","`"),
									row["CUSTBIB"].ToString().Replace("'","`"),
									(int)row["SAMEAS"],
									row["SAMEASMSG"].ToString().Replace("'","`"),
									(bool)row["PRIMARY"],
									row["REMINDERS"].ToString().Replace("'","`"),
									row["TT"].ToString().Replace("'","`")
							);

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("Source Types: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}

