using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class NameFile : VFPDataAccess
	{
		public NameFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = GetOleDbDataReader("*_n.dbf");			
			
			foreach (DbDataRecord row in oledbReader)
			{
				Name data = new Name();
				data.NPER				= (int)row["NPER"];
				data.ALTYPE			= (int)row["ALTYPE"];
				data.ISPICKED		= (bool)row["ISPICKED"];
				data.INFS				= (bool)row["INFS"];
				data.INFG				= (bool)row["INFG"];
				data.PRIMARY		= (bool)row["PRIMARY"];
				data.NSURE			= row["NSURE"].ToString();
				data.FSURE			= row["FSURE"].ToString();
				data.NNOTE			= row["NNOTE"].ToString();
				data.RECNO			= (int)row["RECNO"];
				data.SENTENCE		= row["SENTENCE"].ToString();
				data.NDATE			= row["NDATE"].ToString();
				data.SRTDATE		= row["SRTDATE"].ToString();
				data.DSURE			= row["DSURE"].ToString();
				data.DSID				= (int)row["DSID"];
				data.TT					= row["TT"].ToString();
				data.SRNAMESORT = row["SRNAMESORT"].ToString();
				data.GVNAMESORT = row["GVNAMESORT"].ToString();
				data.STYLEID		= (int)row["STYLEID"];
				data.SURID			= (int)row["SURID"];
				data.GIVID			= (int)row["GIVID"];
				data.SRNAMEDISP = row["SRNAMEDISP"].ToString();
				data.SNDXSURN		= row["SNDXSURN"].ToString();
				data.SNDXGVN		= row["SNDXGVN"].ToString();
				data.PBIRTH			= row["PBIRTH"].ToString();
				data.PDEATH			= row["PDEATH"].ToString();
				data.REFER			= row["REFER"].ToString();
				data.PREF_ID		= (int)row["PREF_ID"];
				data.LAST_EDIT	= (DateTime)row["LAST_EDIT"];

				TMGEntities db = new TMGEntities();
				db.Names.AddObject(data);

				try { db.SaveChanges(); Tracer("Names Added: {0} {1}%"); }
				catch (Exception ex) {}// Console.WriteLine(ex.InnerException); }
			}
		}
	}
}
