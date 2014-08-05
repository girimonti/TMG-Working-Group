using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class DNAFile : VFPDataAccess
	{
		public DNAFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_dna.dbf");			
			

			foreach (DbDataRecord row in oledbReader)
			{
				DNA data = new DNA();
				data.DSID				= (int)row["DSID"];
				data.ID_DNA			= (int)row["ID_DNA"];
				data.ID_PERSON	= (int)row["ID_PERSON"];
				data.DNANAME		= row["DNANAME"].ToString();
				data.COMMENTS		= row["COMMENTS"].ToString();
				data.DESCRIPT		= row["DESCRIPT"].ToString();
				data.RESULT			= row["RESULT"].ToString();
				data.URL				= row["URL"].ToString();
				data.LOGO				= row["LOGO"].ToString();
				data.TT					= row["TT"].ToString();
				data.KITNUMBER	= row["KITNUMBER"].ToString();
				data.TYPE				= row["TYPE"].ToString();
				data.NAMEREC		= (int)row["ID_PERSON"];

				TMGEntities db = new TMGEntities();
				db.DNAs.AddObject(data);
				
				try { db.SaveChanges(); Tracer("DNA Sets Added: {0} {1}%"); }
				catch (Exception ex) {} 
			}
		}
	}
}
