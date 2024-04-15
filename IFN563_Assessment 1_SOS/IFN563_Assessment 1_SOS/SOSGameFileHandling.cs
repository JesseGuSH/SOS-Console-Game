using static System.Console;
using System;
namespace IFN563_Assessment_1_SOS
{
    public class SOSGameFileHandling : IFileHandler
    {
        public SOSGameFileHandling()
        {
        }

        public void LoadGame()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string[] txtFiles = Directory.GetFiles(currentDirectory, "*.txt");
            WriteLine("Current Saved SOSGame FileNames:");

            if (txtFiles.Length == 0)
            {
                Write("No Saved Game files found!");
                WriteLine("");
                Program.StartNewOrLoad();
            }
            else
            {
                foreach (string txtFile in txtFiles)
                {
                    string savedFileName = Path.GetFileNameWithoutExtension(txtFile);
                    WriteLine(savedFileName);
                }
            }
 
            WriteLine("");

            Write("Please enter the filename>> ");
            string filenameWithoutExtension = ReadLine();
            string filenameToUpper = filenameWithoutExtension.ToUpper();
            string filePath = Path.Combine(currentDirectory, $"{filenameToUpper}.txt");
            List<string> lines = new List<string>();

            while (!File.Exists(filePath))
            {

                Write("Invalid Input,please try again>>");
                filenameToUpper = ReadLine();
                filePath = Path.Combine(currentDirectory, $"{filenameToUpper}.txt");
            }

                // Open the file to read from.
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                        lines.Add(s);
                }
            }
            Clear();

            var d = lines.ToArray();
            WriteLine("Here's the board to resume the game: ");
            if (d.Length == 5) { var SOSGame = new SOSGame(d[0], d[1], d[2]); SOSGame.ResumeGame(); }
            else { var SOSGame = new SOSGame(d[0], d[1], d[2], d[3], d[4], d[5]); SOSGame.ResumeGame(); }
        }
    }

}

