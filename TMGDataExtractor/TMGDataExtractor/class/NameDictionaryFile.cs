using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class NameDictionaryFile : VFPDataAccess
	{
		public NameDictionaryFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_nd.dbf");

			foreach (DbDataRecord row in oledbReader)
			{
				NameDictionary data = new NameDictionary();
				data.UID		= (int)row["UID"];
				data.VALUE	= row["VALUE"].ToString();
				data.SDX		= row["SDX"].ToString();
				data.TT			= row["TT"].ToString();

				TMGEntities db = new TMGEntities();
				db.NameDictionaries.AddObject(data);

				try { db.SaveChanges(); Tracer("Name Dictionaries Added: {0} {1}%"); }
				catch (Exception ex) {}//Console.WriteLine(ex.InnerException);}	 
			}
		}
	}
}
