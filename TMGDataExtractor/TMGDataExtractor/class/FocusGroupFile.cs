using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class FocusGroupFile : VFPDataAccess
	{
		public FocusGroupFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_o.dbf");

			foreach (DbDataRecord row in oledbReader)
			{
				FocusGroup data = new FocusGroup();
				data.GROUPNUM		= (int)row["GROUPNUM"];
				data.GROUPNAME	= row["GROUPNAME"].ToString();
				data.RECENT			= (bool)row["RECENT"];
				data.TT					= row["TT"].ToString();

				TMGEntities db = new TMGEntities();
				db.FocusGroups.AddObject(data);

				try { db.SaveChanges(); Tracer("Focus Groups Added: {0} {1}%"); }
				catch (Exception ex) {}//Console.WriteLine(ex.InnerException);}	 
			}
		}
	}
}
