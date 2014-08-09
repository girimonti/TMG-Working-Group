using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class SourceFile : VFPDataAccess
	{
		public SourceFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_m.dbf");			

			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM Source;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO Source (MACTIVE,MAJNUM,REF_ID,ABBREV,DEFSURE,TITLE,TYPE,RECORDER,MEDIA,FIDELITY,INDEXED,STATUS,TEXT,SPERNO,ISPICKED,";
							sql += "INFO,FFORM,SFORM,BFORM,CITED,IBIDTYPE,SUBJECTID,COMPILERID,EDITORID,SPERNO2,UNCITEDFLD,CUSTTYPE,FIRSTCD,DSID,REMINDERS,TT) ";
							sql += string.Format("VALUES ('{0}',{1},{2},'{3}','{4}','{5}',{6},{7},{8},{9},{10},{11},'{12}',{13},'{14}','{15}','{16}','{17}','{18}','{19}',{20},{21},{22},{23},{24},'{25}',{26},'{27}',{28},'{29}','{30}');",
									(bool)row["MACTIVE"],
									(int)row["MAJNUM"],
									(int)row["REF_ID"],
									row["ABBREV"].ToString().Replace("'","`"),
									row["DEFSURE"].ToString().Replace("'","`"),
									row["TITLE"].ToString().Replace("'","`"),
									(decimal)row["TYPE"],
									(decimal)row["RECORDER"],
									(decimal)row["MEDIA"],
									(decimal)row["FIDELITY"],
									(decimal)row["INDEXED"],
									(decimal)row["STATUS"],
									row["TEXT"].ToString().Replace("'","`"),
									(int)row["SPERNO"],
									(bool)row["ISPICKED"],
									row["INFO"].ToString().Replace("'","`"),
									row["FFORM"].ToString().Replace("'","`"),
									row["SFORM"].ToString().Replace("'","`"),
									row["BFORM"].ToString().Replace("'","`"),
									(bool)row["CITED"],
									(decimal)row["IBIDTYPE"],
									(int)row["SUBJECTID"],
									(int)row["COMPILERID"],
									(int)row["EDITORID"],
									(int)row["SPERNO2"],
									row["UNCITEDFLD"].ToString().Replace("'","`"),
									(int)row["CUSTTYPE"],
									row["FIRSTCD"].ToString().Replace("'","`"),
									(int)row["DSID"],
									row["REMINDERS"].ToString().Replace("'","`"),
									row["TT"].ToString().Replace("'","`")
							);

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("Sources: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}

