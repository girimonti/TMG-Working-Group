using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class PersonFile : VFPDataAccess
	{
		public PersonFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_$.dbf");
			
			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM Person;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql =	"INSERT INTO Person (";
							sql += "PER_NO, FATHER, MOTHER, LAST_EDIT, DSID, REF_ID, REFERENCE, SPOULAST, SCBUFF, PBIRTH, PDEATH, SEX, LIVING, ";
							sql += "BIRTHORDER, MULTIBIRTH, ADOPTED, ANCE_INT, DESC_INT, RELATE, RELATEFO, TT, FLAG1) VALUES (";
							sql += string.Format("{0},{1},{2},'{3}',{4},{5},'{6}',{7},'{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}',{18},{19},'{20}','{21}');",
							(int)row["PER_NO"], 
							(int)row["FATHER"],
							(int)row["MOTHER"],
							(DateTime)row["LAST_EDIT"],
							(int)row["DSID"],
							(int)row["REF_ID"],
							row["REFERENCE"].ToString().Replace("'", "`"),
							(int)row["SPOULAST"],
							row["SCBUFF"].ToString().Replace("'", "`"),
							row["PBIRTH"].ToString().Replace("'", "`"),
							row["PDEATH"].ToString().Replace("'", "`"),
							row["SEX"].ToString().Replace("'", "`"),
							row["LIVING"].ToString().Replace("'", "`"),
							row["BIRTHORDER"].ToString().Replace("'", "`"),
							row["ADOPTED"].ToString().Replace("'", "`"),
							row["MULTIBIRTH"].ToString().Replace("'", "`"),
							row["ANCE_INT"].ToString().Replace("'", "`"),
							row["DESC_INT"].ToString().Replace("'", "`"),
							(int)row["RELATE"],
							(int)row["RELATEFO"],
							row["TT"].ToString(),
							row["FLAG1"].ToString());
							//TODO: Need to add the dynamically generated flag columns
							
							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("People Added: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}


