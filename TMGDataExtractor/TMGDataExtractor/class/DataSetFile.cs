using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class DataSetFile : VFPDataAccess
	{
		public DataSetFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_d.dbf");			

			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM DataSet;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO DataSet (DSID,DSNAME,DSLOCATION,DSTYPE,DSLOCKED,DSENABLED,PROPERTY,DSP,DSP2,TT,DCOMMENT,HOST,NAMESTYLE,PLACESTYLE) ";
							sql += string.Format("VALUES ({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12},{13});",
							(int)row["DSID"]						 ,
							row["DSNAME"].ToString().Replace("'","`")		 ,
							row["DSLOCATION"].ToString().Replace("'", "`"),
							(decimal)row["DSTYPE"]			 ,
							(bool)row["DSLOCKED"]				 ,
							(bool)row["DSENABLED"]			 ,
							row["PROPERTY"].ToString().Replace("'", "`"),
							row["DSP"].ToString().Replace("'", "`"),
							row["DSP2"].ToString().Replace("'", "`"),
							row["TT"].ToString()				 ,
							row["DCOMMENT"].ToString().Replace("'", "`"),
							row["HOST"].ToString().Replace("'", "`"),
							(int)row["NAMESTYLE"]				 ,
							(int)row["PLACESTYLE"]		);	 

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("Data Sets Added: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}


