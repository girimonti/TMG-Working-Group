using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class ResearchLogFile : VFPDataAccess
	{
		public ResearchLogFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_l.dbf");			

			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM ResearchLog;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO ResearchLog (RLTYPE,RLNUM,RLPER1,RLPER2,RLGTYPE,TASK,RLEDITED,DESIGNED,BEGUN,PROGRESS,COMPLETED,PLANNED,";
							sql += "EXPENSES,COMMENTS,RLNOTE,KEYWORDS,DSID,ID_PERSON,ID_EVENT,ID_SOURCE,ID_REPOS,TT,REFERENCE) ";
							sql += string.Format("VALUES ('{0}',{1},{2},{3},{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12},'{13}','{14}','{15}',{16},{17},{18},{19},{20},'{21}','{22}');",
									row["RLTYPE"].ToString().Replace("'","`"),
									(int)row["RLNUM"],
									(int)row["RLPER1"],
									(int)row["RLPER2"],
									(int)row["RLGTYPE"],
									row["TASK"].ToString().Replace("'","`"),
									row["RLEDITED"].ToString().Replace("'","`"),
									row["DESIGNED"].ToString().Replace("'","`"),
									row["BEGUN"].ToString().Replace("'","`"),
									row["PROGRESS"].ToString().Replace("'","`"),
									row["COMPLETED"].ToString().Replace("'","`"),
									row["PLANNED"].ToString().Replace("'","`"),
									(decimal)row["EXPENSES"],
									row["COMMENTS"].ToString().Replace("'","`"),
									row["RLNOTE"].ToString().Replace("'","`"),
									row["KEYWORDS"].ToString().Replace("'","`"),
									(int)row["DSID"],
									(int)row["ID_PERSON"],
									(int)row["ID_EVENT"],
									(int)row["ID_SOURCE"],
									(int)row["ID_REPOS"],
									row["TT"].ToString(),
									row["REFERENCE"].ToString().Replace("'","`")
							);

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("Research Logs: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}

