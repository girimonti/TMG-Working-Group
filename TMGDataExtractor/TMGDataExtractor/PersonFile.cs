using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.Common;
using System.Configuration;

namespace TMG.DataExtractor
{
	public class PersonFile : VFPDataAccess
	{
		public PersonFile()
		{
			OleDbDataReader reader;
			base.DataPath = ConfigurationManager.AppSettings["DataPath"]; 
			reader = base.GetOleDbDataReader("*_$.dbf");			

			foreach (DbDataRecord row in reader)
			{
				Person data = new Person();
				data.PER_NO = (int)row.GetValue(0);
				data.FATHER = (int)row.GetValue(1);
				data.MOTHER = (int)row.GetValue(2);
				data.LAST_EDIT = (DateTime)row.GetValue(3);
				data.DSID = (int)row.GetValue(4);
				data.REF_ID = (int)row.GetValue(5);
				data.REFERENCE = row.GetValue(6).ToString();
				data.SPOULAST = (int)row.GetValue(7);
				data.SCBUFF = row.GetValue(8).ToString();
				data.PBIRTH = row.GetValue(9).ToString();
				data.PDEATH = row.GetValue(10).ToString();
				data.SEX = row.GetValue(11).ToString();
				data.LIVING = row.GetValue(12).ToString();
				data.BIRTHORDER = row.GetValue(13).ToString();
				data.MULTIBIRTH = row.GetValue(14).ToString();
				data.ADOPTED = row.GetValue(15).ToString();
				data.ANCE_INT = row.GetValue(16).ToString();
				data.DESC_INT = row.GetValue(17).ToString();
				data.RELATE = (int)row.GetValue(18);
				data.RELATEFO = (int)row.GetValue(19);
				data.TT = row.GetValue(20).ToString();
				data.FLAG1 = row.GetValue(21).ToString();
				//data.FLAG2 = row.GetValue(22).ToString();

				TMGEntities db = new TMGEntities();
				db.People.AddObject(data);
				db.SaveChanges();

				Console.WriteLine("Person Row Data Added");
			}

			Console.ReadKey();
		}
	}
}
