using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class EventFile : VFPDataAccess
	{
		public EventFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = GetOleDbDataReader("*_g.dbf");			
			
			foreach (DbDataRecord row in oledbReader)
			{
				Event data = new Event();
				data.ETYPE		= (int)row["ETYPE"];
				data.DSID			= (int)row["DSID"];
				data.PER1SHOW = (bool)row["PER1SHOW"];
				data.PER2SHOW = (bool)row["PER2SHOW"];
				data.PER1			= (int)row["PER1"];
				data.PER2			= (int)row["PER2"];
				data.EDATE		= row["EDATE"].ToString();
				data.PLACENUM = (int)row["PLACENUM"];
				data.EFOOT		= row["EFOOT"].ToString();
				data.ENSURE		= row["ENSURE"].ToString();
				data.ESSURE		= row["ESSURE"].ToString();
				data.EDSURE		= row["EDSURE"].ToString();
				data.EPSURE		= row["EPSURE"].ToString();
				data.EFSURE		= row["EFSURE"].ToString();
				data.RECNO		= (int)row["RECNO"];
				data.SENTENCE = row["SENTENCE"].ToString();
				data.SRTDATE	= row["SRTDATE"].ToString();
				data.TT				= row["TT"].ToString();
				data.REF_ID		= (int)row["REF_ID"];

				TMGEntities db = new TMGEntities();
				db.Events.AddObject(data);

				try { db.SaveChanges(); Tracer("Events Added: {0} {1}%");}
				catch (Exception ex) { }//Console.WriteLine(ex.InnerException); }
			}
		}
	}
}
