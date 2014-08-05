using System;
using System.Data.OleDb;
using System.Data.Common;

namespace TMG.DataExtractor
{
	public class PersonFile : VFPDataAccess
	{
		public PersonFile()
		{
			OleDbDataReader oledbReader;
			oledbReader = base.GetOleDbDataReader("*_$.dbf");			

			foreach (DbDataRecord row in oledbReader)
			{
				Person data = new Person();
				data.PER_NO			= (int)row["PER_NO"];
				data.FATHER			= (int)row["FATHER"];
				data.MOTHER			= (int)row["MOTHER"];
				data.LAST_EDIT	= (DateTime)row["LAST_EDIT"];
				data.DSID				= (int)row["DSID"];
				data.REF_ID			= (int)row["REF_ID"];
				data.REFERENCE	= row["REFERENCE"].ToString();
				data.SPOULAST		= (int)row["SPOULAST"];
				data.SCBUFF			= row["SCBUFF"].ToString();
				data.PBIRTH			= row["PBIRTH"].ToString();
				data.PDEATH			= row["PDEATH"].ToString();
				data.SEX				= row["SEX"].ToString();
				data.LIVING			= row["LIVING"].ToString();
				data.BIRTHORDER = row["BIRTHORDER"].ToString();
				data.MULTIBIRTH = row["MULTIBIRTH"].ToString();
				data.ADOPTED		= row["ADOPTED"].ToString();
				data.ANCE_INT		= row["ANCE_INT"].ToString();
				data.DESC_INT		= row["DESC_INT"].ToString();
				data.RELATE			= (int)row["RELATE"];
				data.RELATEFO		= (int)row["RELATEFO"];
				data.TT					= row["TT"].ToString();
				data.FLAG1			= row["FLAG1"].ToString();
				//data.FLAG2 = row.GetValue(22).ToString();
				//TODO: Need to add the dynamically generated flag columns

				TMGEntities db = new TMGEntities();
				db.People.AddObject(data);

				try { db.SaveChanges(); Tracer("People Added: {0} {1}%");}
				catch (Exception ex) {}// Console.WriteLine(ex.InnerException); }
			}
		}
	}
}
