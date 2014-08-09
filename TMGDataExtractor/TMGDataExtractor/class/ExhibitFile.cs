using System;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class ExhibitFile : VFPDataAccess
	{
		public ExhibitFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = GetOleDbDataReader("*_i.dbf");			
			
			using (var conn = new SQLiteConnection(ConfigurationManager.ConnectionStrings["TMG.DataExtractor.Properties.Settings.tmgConnectionString"].ToString()))
			{
				conn.Open();

				using (var cmd = new SQLiteCommand(conn))
				{
					using (var transaction = conn.BeginTransaction())
					{
						cmd.CommandText = "DELETE FROM Exhibit;";
						cmd.ExecuteNonQuery();

						foreach (DbDataRecord row in oledbReader)
						{
							string sql = "INSERT INTO Exhibit (IDEXHIBIT,IDREF,RLTYPE,RLNUM,XNAME,VFILENAME,IFILENAME,AFILENAME,TFILENAME,REFERENCE,TEXT,DESCRIPT,RLPER1,RLPER2,RLGTYPE,\"PRIMARY\", ";
							sql += "PROPERTY,DSID,TT,ID_PERSON,ID_EVENT,ID_SOURCE,ID_REPOS,ID_CIT,ID_PLACE,CAPTION,SORTEXH,TRANSPAR) ";
							sql += string.Format("VALUES ({0},{1},'{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12},{13},{14},'{15}','{16}',{17},'{18}',{19},{20},{21},{22},{23},{24},'{25}',{26},{27});",
								(int)row["IDEXHIBIT"]				 ,
								(int)row["IDREF"]						 ,
								row["RLTYPE"].ToString().Replace("'", "`"),
								(int)row["RLNUM"]						 ,
								row["XNAME"].ToString().Replace("'","`")			 ,
								row["VFILENAME"].ToString().Replace("'", "`"),
								row["IFILENAME"].ToString().Replace("'", "`"),
								row["AFILENAME"].ToString().Replace("'", "`"),
								row["TFILENAME"].ToString().Replace("'", "`"),
								row["REFERENCE"].ToString().Replace("'", "`"),
								row["TEXT"].ToString().Replace("'", "`"),
								row["DESCRIPT"].ToString().Replace("'", "`"),
								(int)row["RLPER1"]					 ,
								(int)row["RLPER2"]					 ,
								(int)row["RLGTYPE"]					 ,
								(bool)row["PRIMARY"]				 ,
								row["PROPERTY"].ToString().Replace("'", "`"),
								(int)row["DSID"]						 ,
								row["TT"].ToString()				 ,
								(int)row["ID_PERSON"]				 ,
								(int)row["ID_EVENT"]				 ,
								(int)row["ID_SOURCE"]				 ,
								(int)row["ID_REPOS"]				 ,
								(int)row["ID_CIT"]					 ,
								(int)row["ID_PLACE"]				 ,
								row["CAPTION"].ToString().Replace("'", "`"),
								(int)row["SORTEXH"]					 ,
								(decimal)row["TRANSPAR"]
							);		 

				//TODO: Fix the binary data being interpreted as strings!
				//if (row["IMAGE"] == null)
				//{ data.IMAGE = null; }
				//else
				//{ data.IMAGE = (byte[])row["IMAGE"]; }

				//if (row["AUDIO"] == null)
				//{ data.AUDIO = null; }
				//else
				//{ data.AUDIO = (byte[])row["AUDIO"]; }

				//if (row["VIDEO"] == null)
				//{ data.VIDEO = null; }
				//else
				//{ data.VIDEO = (byte[])row["VIDEO"]; }

				//if (row["OLE_OBJECT"] == null)
				//{ data.OLE_OBJECT = null; }
				//else
				//{ data.OLE_OBJECT = (byte[])row["OLE_OBJECT"]; }

				//if (row["IMAGEFORE"] == null)
				//{ data.IMAGEFORE = null; }
				//else
				//{ data.IMAGEFORE = (byte[])row["IMAGEFORE"]; }

				//if (row["IMAGEBACK"] == null)
				//{ data.IMAGEBACK = null; }
				//else
				//{ data.IMAGEBACK = (byte[])row["IMAGEBACK"]; }

				//if (row["THUMB"] == null)
				//{ data.THUMB = null; }
				//else
				//{ data.THUMB = (byte[])row["THUMB"]; }

							cmd.CommandText = sql;
							cmd.ExecuteNonQuery();
							Tracer("Exhibits Added: {0} {1}%");
						}
						transaction.Commit();
					}
				}
				conn.Close();
			}
		}
	}
}


