using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.IO;

namespace TMG.DataExtractor
{
	public class VFPDataAccess
	{
		OleDbConnection connection;

		public string DataPath {get; set;}

		public OleDbDataReader GetOleDbDataReader(string DataFileType)
		{
			OleDbDataReader retval;
			string fileName = GetFileName(DataFileType);
			string sql = string.Format("SELECT * FROM {0}", fileName);

			connection = GetOleDbConnection();
			connection.Open();

			OleDbCommand cmd1 = new OleDbCommand(sql, connection);
			
			retval = cmd1.ExecuteReader();

			return retval;
		}				
		
		private string GetFileName(string FileType)
		{
			string retval = string.Empty;
			string[] files = Directory.GetFiles(this.DataPath,FileType);

			foreach (string file in files)
			{
			//just grab the first matching file for now
			//TODO: allow iteration through all matching files to accomodate for multiple projects
				retval = file.Replace(this.DataPath, "");
				retval = retval.Replace("\\", "");
				break;
			}

			return retval;
		}

		private OleDbConnection GetOleDbConnection()
		{
			string provider = string.Format("Provider=VFPOLEDB.1;Data Source={0}", this.DataPath);
			OleDbConnection retval = new OleDbConnection(provider);
			return retval;
		}
	}
}
