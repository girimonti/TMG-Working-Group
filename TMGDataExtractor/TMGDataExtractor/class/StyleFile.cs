using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class StyleFile : VFPDataAccess
	{
		public StyleFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_st.dbf");			

			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM Style;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO Style (STYLEID,ST_DISPLAY,ST_OUTPUT,\"GROUP\",SRNAMESORT,SRNAMEDISP,GVNAMESORT,GVNAMEDISP,OTHERDISP,TT,DSID,STYLENAME) ";
							sql += string.Format("VALUES ({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},'{11}');",
									(int)row["STYLEID"],
									row["ST_DISPLAY"].ToString().Replace("'","`"),
									row["ST_OUTPUT"].ToString().Replace("'","`"),
									row["GROUP"].ToString().Replace("'","`"),
									row["SRNAMESORT"].ToString().Replace("'","`"),
									row["SRNAMEDISP"].ToString().Replace("'","`"),
									row["GVNAMESORT"].ToString().Replace("'","`"),
									row["GVNAMEDISP"].ToString().Replace("'","`"),
									row["OTHERDISP"].ToString().Replace("'","`"),
									row["TT"].ToString().Replace("'","`"),
									(int)row["DSID"],
									row["STYLENAME"].ToString().Replace("'","`")
							);

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("Styles: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}

