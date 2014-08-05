using System;
using System.Diagnostics;

namespace TMG.DataExtractor
{
	class Program
	{
		private static string displayMessage = string.Empty;
		private static int timerCount = 0;

		static void Main(string[] args)
		{
      Stopwatch stopWatch = new Stopwatch();
      stopWatch.Start();


			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.SetWindowSize(80, 24);
			Console.SetBufferSize(80, 24);
			Console.Title = "Migrating Data From TMG";

			PersonFile person = new PersonFile();
			displayMessage += string.Format("People Added: {0}\n", person.RecordCount);
			UpdateTitle(1);

			SourceTypeFile A = new SourceTypeFile();
			displayMessage += string.Format("Source Types Added: {0}\n", A.RecordCount);
			UpdateTitle(2);

			FocusGroupMemberFile B = new FocusGroupMemberFile();
			displayMessage += string.Format("Focus Group Members Added: {0}\n", B.RecordCount);
			UpdateTitle(3);

			FlagFile C = new FlagFile();
			displayMessage += string.Format("Flags Added: {0}\n", C.RecordCount);
			UpdateTitle(4);

			DataSetFile D = new DataSetFile();
			displayMessage += string.Format("Data Sets Added: {0}\n", D.RecordCount);
			UpdateTitle(5);

			DNAFile DNA = new DNAFile();
			displayMessage += string.Format("DNA Sets Added: {0}\n", DNA.RecordCount);
			UpdateTitle(6);

			EventWitnessFile E = new EventWitnessFile();
			displayMessage += string.Format("Event Witnesses Added: {0}\n", E.RecordCount);
			UpdateTitle(7);

			ParentChildRelationshipFile F = new ParentChildRelationshipFile();
			displayMessage += string.Format("Parent/Child Relationships Added: {0}\n", F.RecordCount);
			UpdateTitle(8);

			EventFile G = new EventFile();
			displayMessage += string.Format("Events Added: {0}\n", G.RecordCount);
			UpdateTitle(9);

			ExhibitFile I = new ExhibitFile();
			displayMessage += string.Format("Exhibits Added: {0}\n", I.RecordCount);
			UpdateTitle(10);

			TimelineLockFile K = new TimelineLockFile();
			displayMessage += string.Format("Timeline Locks Added: {0}\n", K.RecordCount);
			UpdateTitle(11);

			ResearchLogFile L = new ResearchLogFile();
			displayMessage += string.Format("Research Logs Added: {0}\n", L.RecordCount);
			UpdateTitle(12);

			SourceFile M = new SourceFile();
			displayMessage += string.Format("Sources Added: {0}\n", M.RecordCount);
			UpdateTitle(13);

			NameFile N = new NameFile();
			displayMessage += string.Format("Names Added: {0}\n", N.RecordCount);
			UpdateTitle(14);

			NameDictionaryFile ND = new NameDictionaryFile();
			displayMessage += string.Format("Names Dictionaries Added: {0}\n", ND.RecordCount);
			UpdateTitle(15);

			NamePartTypeFile NPT = new NamePartTypeFile();
			displayMessage += string.Format("Name Part Types Added: {0}\n", NPT.RecordCount);
			UpdateTitle(16);

			NamePartValueFile NPV = new NamePartValueFile();
			displayMessage += string.Format("Name Part Values Added: {0}\n", NPV.RecordCount);
			UpdateTitle(17);

			FocusGroupFile O = new FocusGroupFile();
			displayMessage += string.Format("Focus Groups Added: {0}\n", O.RecordCount);
			UpdateTitle(18);

			StyleFile ST = new StyleFile();
			displayMessage += string.Format("Styles Added: {0}\n", ST.RecordCount);
			UpdateTitle(11);

			Console.Clear();
			UpdateTitle(29);
			Console.Write(displayMessage);


			stopWatch.Stop();
			TimeSpan ts = stopWatch.Elapsed;

      // Format and display the TimeSpan value. 
      string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

			Console.WriteLine("\nTime Elapsed: {0}", elapsedTime);
			Console.WriteLine("\nDone!\n\nPress any key to continue");
			Console.ReadKey();
		}

		private static void UpdateTitle(int Number)
		{
			decimal percentage = ((decimal)Number / 29) * 100;
			Console.Title = string.Format("Migrating Data From TMG: {0}% Complete", decimal.Round(percentage, 0).ToString());
		}
	}
}
