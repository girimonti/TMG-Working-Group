using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class NameDictionaryFile : VFPDataAccess
	{
		public NameDictionaryFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_nd.dbf");			

			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM NameDictionary;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO NameDictionary (UID,VALUE,SDX,TT) ";
							sql += string.Format("VALUES ({0},'{1}','{2}','{3}');",
								 (int)row["UID"],
								 row["VALUE"].ToString().Replace("'","`"),
								 row["SDX"].ToString().Replace("'","`"),
								 row["TT"].ToString()
							);

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("Name Dictionaries Added: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}


