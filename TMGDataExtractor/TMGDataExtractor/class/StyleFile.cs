using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class StyleFile : VFPDataAccess
	{
		public StyleFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_st.dbf");			

			foreach (DbDataRecord row in oledbReader)
			{
				Style data = new Style();
				data.STYLEID		= (int)row["STYLEID"];
				data.ST_DISPLAY = row["ST_DISPLAY"].ToString();
				data.ST_OUTPUT	= row["ST_OUTPUT"].ToString();
				data.GROUP			= row["GROUP"].ToString();
				data.SRNAMESORT = row["SRNAMESORT"].ToString();
				data.SRNAMEDISP = row["SRNAMEDISP"].ToString();
				data.GVNAMESORT = row["GVNAMESORT"].ToString();
				data.GVNAMEDISP = row["GVNAMEDISP"].ToString();
				data.OTHERDISP	= row["OTHERDISP"].ToString();
				data.TT					= row["TT"].ToString();
				data.DSID				= (int)row["DSID"];
				data.STYLENAME	= row["STYLENAME"].ToString();

				TMGEntities db = new TMGEntities();
				db.Styles.AddObject(data);
				
				try { db.SaveChanges(); Tracer("Styles Added: {0} {1}%");}
				catch (Exception ex) {}// Console.WriteLine(ex.InnerException); }
			}
		}
	}
}
