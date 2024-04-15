using static System.Console;
using System;
using System.IO;

namespace IFN563_Assessment_1_SOS;


class Program
{

    static void Main(string[] args)
    {
        HelpSystem.Welcome();
        HelpSystem.SelectGame();
        StartNewOrLoad();

    }

    public static void StartNewOrLoad()
    {
        WriteLine();
        Write("Please choose a command to procceed or enter Q to quit!(1.Begin a new Game 2.Load Saved Game)>> ");
        string command = ReadLine();
        HelpSystem.CheckValidCommand(command);
        command = HelpSystem.RePrompt(command);

        switch (command)
        {
            case "1":Game SOSGame = new SOSGame();SOSGame.StartGame();break;
            case "2":IFileHandler SOSfh = new SOSGameFileHandling();SOSfh.LoadGame();break;
        }
    }

}