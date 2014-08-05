using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class TimelineLockFile : VFPDataAccess
	{
		public TimelineLockFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_k.dbf");
			
			foreach (DbDataRecord row in oledbReader)
			{
				TimelineLock data = new TimelineLock();
				data.IDLOCK = (int)row["IDLOCK"];
				data.TNAME	= row["TNAME"].ToString();
				data.DSID		= (int)row["DSID"];
				data.TT			= row["TT"].ToString();

				TMGEntities db = new TMGEntities();
				db.TimelineLocks.AddObject(data);

				try { db.SaveChanges(); Tracer("Timeline Locks Added: {0} {1}%"); }
				catch (Exception ex) {}//Console.WriteLine(ex.InnerException);}	 
			}
		}
	}
}
