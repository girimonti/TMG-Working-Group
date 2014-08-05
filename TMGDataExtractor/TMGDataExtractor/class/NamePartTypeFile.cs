using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class NamePartTypeFile : VFPDataAccess
	{
		public NamePartTypeFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_npt.dbf");

			foreach (DbDataRecord row in oledbReader)
			{
				NamePartType data = new NamePartType();
				data.ID					= (int)row["ID"];
				data.VALUE			= row["VALUE"].ToString();
				data.SYSTEM			= (bool)row["SYSTEM"];
				data.TYPE				= (int)row["TYPE"];
				data.SHORTVALUE = row["SHORTVALUE"].ToString();
				data.TT					= row["TT"].ToString();
				data.DSID				= (int)row["DSID"];
				data.TEMPLATE		= row["TEMPLATE"].ToString();

				TMGEntities db = new TMGEntities();
				db.NamePartTypes.AddObject(data);

				try { db.SaveChanges(); Tracer("Name Part Types Added: {0} {1}%"); }
				catch (Exception ex) {}//Console.WriteLine(ex.InnerException);}	 
			}
		}
	}
}
