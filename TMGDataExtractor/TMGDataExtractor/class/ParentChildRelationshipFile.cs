using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class ParentChildRelationshipFile : VFPDataAccess
	{
		public ParentChildRelationshipFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_f.dbf");			

			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM ParentChildRelationship;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO ParentChildRelationship (\"PRIMARY\",CHILD,PARENT,PTYPE,PNOTE,PSURE,FSURE,RECNO,TT,DSID) ";
							sql += string.Format("VALUES ('{0}',{1},{2},{3},'{4}','{5}','{6}',{7},'{8}',{9});",
								 (bool)row["PRIMARY"],
								 (int)row["CHILD"],
								 (int)row["PARENT"],
								 (int)row["PTYPE"],
								 row["PNOTE"].ToString().Replace("'", "`"),
								 row["PSURE"].ToString().Replace("'", "`"),
								 row["FSURE"].ToString().Replace("'", "`"),
								 (int)row["RECNO"],
								 row["TT"].ToString(),
								 (int)row["DSID"]
							);

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("Parent Child Relationships: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}

