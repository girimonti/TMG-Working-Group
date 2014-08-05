using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class DataSetFile : VFPDataAccess
	{
		public DataSetFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_d.dbf");			

			foreach (DbDataRecord row in oledbReader)
			{
				DataSet data = new DataSet();
				data.DSID				= (int)row["DSID"];
				data.DSNAME			= row["DSNAME"].ToString();
				data.DSLOCATION = row["DSLOCATION"].ToString();
				data.DSTYPE			= (decimal)row["DSTYPE"];
				data.DSLOCKED		= (bool)row["DSLOCKED"];
				data.DSENABLED	= (bool)row["DSENABLED"];
				data.PROPERTY		= row["PROPERTY"].ToString();
				data.DSP				= row["DSP"].ToString();
				data.DSP2				= row["DSP2"].ToString();
				data.TT					= row["TT"].ToString();
				data.DCOMMENT		= row["DCOMMENT"].ToString();
				data.HOST				= row["HOST"].ToString();
				data.NAMESTYLE	= (int)row["NAMESTYLE"];
				data.PLACESTYLE = (int)row["PLACESTYLE"];

				TMGEntities db = new TMGEntities();
				db.DataSets.AddObject(data);

				try { db.SaveChanges(); Tracer("Data Sets Added: {0} {1}%"); }
				catch (Exception ex) {}
			}
		}
	}
}
