using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class ExhibitFile : VFPDataAccess
	{
		public ExhibitFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = GetOleDbDataReader("*_i.dbf");			
			
			foreach (DbDataRecord row in oledbReader)
			{
				Exhibit data = new Exhibit();
				data.IDEXHIBIT	= (int)row["IDEXHIBIT"];
				data.IDREF			= (int)row["IDREF"];
				data.RLTYPE			= row["RLTYPE"].ToString();
				data.RLNUM			= (int)row["RLNUM"];
				data.XNAME			= row["XNAME"].ToString();
				data.VFILENAME	= row["VFILENAME"].ToString();
				data.IFILENAME	= row["IFILENAME"].ToString();
				data.AFILENAME	= row["AFILENAME"].ToString();
				data.TFILENAME	= row["TFILENAME"].ToString();
				data.REFERENCE	= row["REFERENCE"].ToString();
				data.TEXT				= row["TEXT"].ToString();				
				data.DESCRIPT		= row["DESCRIPT"].ToString();
				data.RLPER1			= (int)row["RLPER1"];
				data.RLPER2			= (int)row["RLPER2"];
				data.RLGTYPE		= (int)row["RLGTYPE"];
				data.PRIMARY		= (bool)row["PRIMARY"];
				data.PROPERTY		= row["PROPERTY"].ToString();
				data.DSID				= (int)row["DSID"];
				data.TT					= row["TT"].ToString();
				data.ID_PERSON	= (int)row["ID_PERSON"];
				data.ID_EVENT		= (int)row["ID_EVENT"];
				data.ID_SOURCE	= (int)row["ID_SOURCE"];
				data.ID_REPOS		= (int)row["ID_REPOS"];

				data.ID_CIT			= (int)row["ID_CIT"];
				data.ID_PLACE		= (int)row["ID_PLACE"];
				data.CAPTION		= row["CAPTION"].ToString();
				data.SORTEXH		= (int)row["SORTEXH"];
				data.TRANSPAR		= (decimal)row["TRANSPAR"];

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

				TMGEntities db = new TMGEntities();
				db.Exhibits.AddObject(data);
				
				try { db.SaveChanges(); Tracer("Exhibits Added: {0} {1}%");}
				catch (Exception ex) {}// Console.WriteLine(ex.InnerException); }
			}
		}
	}
}
