using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class NamePartValueFile : VFPDataAccess
	{
		public NamePartValueFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_npv.dbf");

			foreach (DbDataRecord row in oledbReader)
			{
				NamePartValue data = new NamePartValue();
				data.RECNO	= (int)row["RECNO"];
				data.UID		= (int)row["UID"];
				data.TYPE		= (int)row["TYPE"];
				data.ID			= (int)row["ID"];
				data.TT			= row["TT"].ToString();
				data.DSID		= (int)row["DSID"];

				TMGEntities db = new TMGEntities();
				db.NamePartValues.AddObject(data);

				try { db.SaveChanges(); Tracer("Name Part Values Added: {0} {1}%"); }
				catch (Exception ex) {}//Console.WriteLine(ex.InnerException);}	 
			}
		}
	}
}
