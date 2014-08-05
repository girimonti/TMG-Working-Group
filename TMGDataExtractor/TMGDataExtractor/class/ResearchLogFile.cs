using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class ResearchLogFile : VFPDataAccess
	{
		public ResearchLogFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = GetOleDbDataReader("*_l.dbf");			
			
			foreach (DbDataRecord row in oledbReader)
			{
				ResearchLog data = new ResearchLog();
				data.RLTYPE			= row["RLTYPE"].ToString();
				data.RLNUM			= (int)row["RLNUM"];
				data.RLPER1			= (int)row["RLPER1"];
				data.RLPER2			= (int)row["RLPER2"];
				data.RLGTYPE		= (int)row["RLGTYPE"];
				data.TASK				= row["TASK"].ToString();
				data.RLEDITED		= row["RLEDITED"].ToString();
				data.DESIGNED		= row["DESIGNED"].ToString();
				data.BEGUN			= row["BEGUN"].ToString();
				data.PROGRESS		= row["PROGRESS"].ToString();
				data.COMPLETED	= row["COMPLETED"].ToString();
				data.PLANNED		= row["PLANNED"].ToString();
				data.EXPENSES		= (decimal)row["EXPENSES"];
				data.COMMENTS		= row["COMMENTS"].ToString();
				data.RLNOTE			= row["RLNOTE"].ToString();
				data.KEYWORDS		= row["KEYWORDS"].ToString();
				data.DSID				= (int)row["DSID"];
				data.ID_PERSON	= (int)row["ID_PERSON"];
				data.ID_EVENT		= (int)row["ID_EVENT"];
				data.ID_SOURCE	= (int)row["ID_SOURCE"];
				data.ID_REPOS		= (int)row["ID_REPOS"];
				data.TT					= row["TT"].ToString();
				data.REFERENCE	= row["REFERENCE"].ToString();

				TMGEntities db = new TMGEntities();
				db.ResearchLogs.AddObject(data);

				try { db.SaveChanges(); Tracer("Research Logs Added: {0} {1}%"); }
				catch (Exception ex) {}// Console.WriteLine(ex.InnerException); }
			}
		}
	}
}
