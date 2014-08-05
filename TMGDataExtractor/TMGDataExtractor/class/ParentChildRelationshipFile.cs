using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class ParentChildRelationshipFile : VFPDataAccess
	{
		public ParentChildRelationshipFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = GetOleDbDataReader("*_f.dbf");			
			
			foreach (DbDataRecord row in oledbReader)
			{
				ParentChildRelationship data = new ParentChildRelationship();
				data.PRIMARY	= (bool)row["PRIMARY"];
				data.CHILD		= (int)row["CHILD"];
				data.PARENT		= (int)row["PARENT"];
				data.PTYPE		= (int)row["PTYPE"];
				data.PNOTE		= row["PNOTE"].ToString();
				data.PSURE		= row["PSURE"].ToString();
				data.FSURE		= row["FSURE"].ToString();
				data.RECNO		= (int)row["RECNO"];
				data.TT				= row["TT"].ToString();
				data.DSID			= (int)row["DSID"];

				TMGEntities db = new TMGEntities();
				db.ParentChildRelationships.AddObject(data);

				try { db.SaveChanges(); Tracer("Parent/Child Relationships Added: {0} {1}%");}
				catch (Exception ex) {}// Console.WriteLine(ex.InnerException); }
			}
		}
	}
}
