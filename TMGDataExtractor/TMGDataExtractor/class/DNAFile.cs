using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class DNAFile : VFPDataAccess
	{
		public DNAFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_dna.dbf");			
			
			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM DNA;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO DNA (DSID,ID_DNA,ID_PERSON,DNANAME,COMMENTS,DESCRIPT,RESULT,URL,LOGO,TT,KITNUMBER,TYPE,NAMEREC) ";
							sql += string.Format("VALUES ({0},{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12});",
							(int)row["DSID"]				,
							(int)row["ID_DNA"]				,
							(int)row["ID_PERSON"]				,
							row["DNANAME"].ToString().Replace("'","`")	,
							row["COMMENTS"].ToString().Replace("'", "`"),
							row["DESCRIPT"].ToString().Replace("'", "`"),
							row["RESULT"].ToString().Replace("'", "`"),
							row["URL"].ToString()	,
							row["LOGO"].ToString().Replace("'", "`"),
							row["TT"].ToString()	,
							row["KITNUMBER"].ToString().Replace("'", "`"),
							row["TYPE"].ToString().Replace("'", "`"),
							(int)row["ID_PERSON"]);			
				
							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("DNA Results Added: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}


