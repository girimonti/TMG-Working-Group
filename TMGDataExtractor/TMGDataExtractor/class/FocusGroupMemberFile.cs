using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class FocusGroupMemberFile : VFPDataAccess
	{
		public FocusGroupMemberFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_b.dbf");
			
			foreach (DbDataRecord row in oledbReader)
			{
				FocusGroupMember data = new FocusGroupMember();

				data.GROUPNUM		= (int)row["GROUPNUM"];
				data.MEMBERNUM	= (int)row["MEMBERNUM"];
				data.TT					= row["TT"].ToString();
				data.DSID				= (int)row["DSID"];

				TMGEntities db = new TMGEntities();
				db.FocusGroupMembers.AddObject(data);
				
				try { db.SaveChanges(); Tracer("Focus Group Member Rows Added: {0} {1}%");}
				catch (Exception ex) {}// Console.WriteLine(ex.InnerException); }	
			}
		}
	}
}
