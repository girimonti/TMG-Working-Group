using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class FlagFile : VFPDataAccess
	{
		public FlagFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_c.dbf");
			

			foreach (DbDataRecord row in oledbReader)
			{
				Flag data = new Flag();
				data.FLAGLABEL	= row["FLAGLABEL"].ToString();
				data.FLAGFIELD	= row["FLAGFIELD"].ToString();
				data.FLAGVALUE	= row["FLAGVALUE"].ToString();
				data.SEQUENCE		= (int)row["SEQUENCE"];
				data.DESCRIPT		= row["DESCRIPT"].ToString();
				data.ACTIVE			= (bool)row["ACTIVE"];
				data.FLAGID			= (int)row["FLAGID"];
				data.PROPERTY		= row["PROPERTY"].ToString();
				data.DSID				= (int)row["DSID"];
				data.TT					= row["TT"].ToString();

				TMGEntities db = new TMGEntities();
				db.Flags.AddObject(data);
				
				try {	db.SaveChanges(); Tracer("Flags Added: {0} {1}%");}
				catch (Exception ex) {}//Console.WriteLine(ex.InnerException);}	 
			}
		}
	}
}
