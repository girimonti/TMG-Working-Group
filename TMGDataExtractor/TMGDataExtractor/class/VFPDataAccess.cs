using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Data.OleDb;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Configuration;


namespace TMG.DataExtractor
{
	public class VFPDataAccess
	{
		OleDbConnection oledbConnection;
		private string dataPath = ConfigurationManager.AppSettings["DataPath"];

		private int myRecordCount = 0;
		private int myCount = 0;

		public int RecordCount
		{
			get { return myRecordCount; }
		}

		internal int CurrentCount
		{
			get { return myCount; }
			set { myCount = value;}
		}

		internal string Percentage
		{
			get 
			{ 
				decimal myPercentage = ((decimal)myCount / myRecordCount) * 100;
				return decimal.Round(myPercentage,0).ToString(); 
			}
		}

		internal OleDbDataReader GetOleDbDataReader(string DataFileType)
		{
			OleDbDataReader retval;
			string fileName = GetFileName(DataFileType);
			string sql = string.Format("SELECT * FROM {0}", fileName);

			oledbConnection = GetOleDbConnection();
			oledbConnection.Open();

			OleDbCommand cmd1 = new OleDbCommand(sql, oledbConnection);

			retval = cmd1.ExecuteReader();
			myRecordCount = retval.RecordsAffected;

			return retval;
		}
		
		private string GetFileName(string FileType)
		{
			string retval = string.Empty;
			string[] files = Directory.GetFiles(dataPath,FileType);

			foreach (string file in files)
			{
			//just grab the first matching file for now
			//TODO: allow iteration through all matching files to accomodate for multiple projects
				retval = file.Replace(dataPath, "");
				retval = retval.Replace("\\", "");
				break;
			}

			return retval;
		}

		private OleDbConnection GetOleDbConnection()
		{
			string provider = string.Format("Provider=VFPOLEDB.1;Data Source={0}", dataPath);
			OleDbConnection retval = new OleDbConnection(provider);
			return retval;
		}

		internal void Tracer(string TracerText)
		{
			Console.Clear();
			CurrentCount += 1;
			Console.WriteLine(TracerText, CurrentCount, Percentage);
		}
	}
}
