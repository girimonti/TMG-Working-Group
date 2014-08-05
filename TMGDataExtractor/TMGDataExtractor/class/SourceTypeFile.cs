using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class SourceTypeFile : VFPDataAccess
	{
		public SourceTypeFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_a.dbf");

			foreach (DbDataRecord row in oledbReader)
			{
				SourceType data = new SourceType();
				data.RULESET		= (decimal)row["RULESET"];
				data.DSID				= (int)row["DSID"];
				data.SOURTYPE		= (int)row["SOURTYPE"];
				data.TRANS_TO		= (int)row["TRANS_TO"];
				data.NAME				= row["NAME"].ToString();
				data.FOOT				= row["FOOT"].ToString(); 
				data.SHORT			= row["SHORT"].ToString();
				data.BIB				= row["BIB"].ToString();
				data.CUSTFOOT		= row["CUSTFOOT"].ToString();
				data.CUSTSHORT	= row["CUSTSHORT"].ToString();
				data.CUSTBIB		= row["CUSTBIB"].ToString();
				data.SAMEAS			= (int)row["SAMEAS"];
				data.SAMEASMSG	= row["SAMEASMSG"].ToString();
				data.PRIMARY		= (bool)row["PRIMARY"];
				data.REMINDERS	= row["REMINDERS"].ToString();
				data.TT					= row["TT"].ToString();

				TMGEntities db = new TMGEntities();
				db.SourceTypes.AddObject(data);

				try { db.SaveChanges(); Tracer("Source Types Added: {0} {1}%");}
				catch (Exception ex) {}// Console.WriteLine(ex.InnerException); }
			}
		}
	}
}
