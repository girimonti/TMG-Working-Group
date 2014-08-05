using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class SourceFile : VFPDataAccess
	{
		public SourceFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = GetOleDbDataReader("*_m.dbf");			
			
			foreach (DbDataRecord row in oledbReader)
			{
				Source data = new Source();
				data.MACTIVE		= (bool)row["MACTIVE"];
				data.MAJNUM			= (int)row["MAJNUM"];
				data.REF_ID			= (int)row["REF_ID"];
				data.ABBREV			= row["ABBREV"].ToString();
				data.DEFSURE		= row["DEFSURE"].ToString();
				data.TITLE			= row["TITLE"].ToString();
				data.TYPE				= (decimal)row["TYPE"];
				data.RECORDER		= (decimal)row["RECORDER"];
				data.MEDIA			= (decimal)row["MEDIA"];
				data.FIDELITY		= (decimal)row["FIDELITY"];
				data.INDEXED		= (decimal)row["INDEXED"];
				data.STATUS			= (decimal)row["STATUS"];
				data.TEXT				= row["TEXT"].ToString();
				data.SPERNO			= (int)row["SPERNO"];
				data.ISPICKED		= (bool)row["ISPICKED"];
				data.INFO				= row["INFO"].ToString();
				data.FFORM			= row["FFORM"].ToString();
				data.SFORM			= row["SFORM"].ToString();
				data.BFORM			= row["BFORM"].ToString();
				data.CITED			= (bool)row["CITED"];
				data.IBIDTYPE		= (decimal)row["IBIDTYPE"];
				data.SUBJECTID	= (int)row["SUBJECTID"];
				data.COMPILERID	= (int)row["COMPILERID"];
				data.EDITORID		= (int)row["EDITORID"];
				data.SPERNO2		= (int)row["SPERNO2"];
				data.UNCITEDFLD = row["UNCITEDFLD"].ToString();
				data.CUSTTYPE		= (int)row["CUSTTYPE"];
				data.FIRSTCD		= row["FIRSTCD"].ToString();
				data.DSID				= (int)row["DSID"];
				data.REMINDERS	= row["REMINDERS"].ToString();
				data.TT					= row["TT"].ToString();

				TMGEntities db = new TMGEntities();
				db.Sources.AddObject(data);

				try { db.SaveChanges(); Tracer("Sources Added: {0} {1}%"); }
				catch (Exception ex) {}// Console.WriteLine(ex.InnerException); }
			}
		}
	}
}
