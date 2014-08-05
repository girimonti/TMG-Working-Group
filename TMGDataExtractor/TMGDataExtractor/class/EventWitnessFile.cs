using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class EventWitnessFile : VFPDataAccess
	{
		public EventWitnessFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_e.dbf");			
			

			foreach (DbDataRecord row in oledbReader)
			{
				EventWitness data = new EventWitness();
				data.EPER				= (int)row["EPER"];
				data.GNUM				= (int)row["GNUM"];
				data.PRIMARY		= (bool)row["PRIMARY"];
				data.WSENTENCE	= row["WSENTENCE"].ToString();
				data.TT					= row["TT"].ToString();
				data.ROLE				= row["ROLE"].ToString();
				data.DSID				= (int)row["DSID"];
				data.NAMEREC		= (int)row["NAMEREC"];
				data.WITMEMO		= row["WITMEMO"].ToString();
				data.TT					= row["TT"].ToString();
				data.SEQUENCE		= (int)row["SEQUENCE"];

				TMGEntities db = new TMGEntities();
				db.EventWitnesses.AddObject(data);

				try { db.SaveChanges(); Tracer("Event Witnesses Added: {0} {1}%");}
				catch (Exception ex) {}// Console.WriteLine(ex.InnerException); }			
			}
		}
	}
}
