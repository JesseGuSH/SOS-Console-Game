using static System.Console;
using System;
namespace IFN563_Assessment_1_SOS
{
    public class HelpSystem
    {

        public HelpSystem()
        {
        }

        public static void Welcome()
        {
            WriteLine("Welcome to the board game Hub! ");
            WriteLine("");
            WriteLine("Some essential guidelines:");
            WriteLine("1.Navigate the action by inputting command numbers or enter Q to quit the program.");
            WriteLine("2.When placing a move, please enter the row and column numbers separated by a white space.");
        }

        public static void SelectGame()
        {
            WriteLine();
            Write("Please choose a game by inputting the command number or enter Q to quit. (1.SOS Game 2.Connect Four(Not available Yet ^-^)) >> ");
            string command = ReadLine();
            CheckValidCommand(command);
            command = RePrompt(command);

            if (command == "2")
            {
                WriteLine("");
                WriteLine("Currently, I'm here to guide you through a game of SOS as I'm flying solo :)!");
                WriteLine("But who knows what the future holds? Perhaps you'll be able to playing a Connect Four match in this application someday.");
                WriteLine("");
                Write("Press any key to SOS Game.....");
                ReadKey();
            }

            Clear();
            SOSGameRules();
        }


        public static void SOSGameRules()
        {
            WriteLine("Welcome to the SOS game!Here are the general rules:");
            WriteLine("1.Players take turns to add either an X or an O on a 3x3 board.");
            WriteLine("2.2 modes are up for selection:Human vs Human and Computer vs Human:");
            WriteLine("3.If a player makes the sequence SOS vertically, horizontally or diagonally they get a point and also take another turn. ");
            WriteLine("4.Once the board has been filled up, the winner is the player who made the most consecutive 3-letter chains.");
            WriteLine("5.Players could undo and redo their previous move during their turn.");
            WriteLine("6.Game could be saved at any point before its conclusion.");
        }

        public static string SelectMode()
        {
            WriteLine("");
            WriteLine("Now please enter the number to select the mode of the play or enter Q to quit:\n 1.Human vs Human \n 2.Computer vs Human ");
            Write("Please enter your choice>> ");
            string command = ReadLine();
            CheckValidCommand(command);
            command = RePrompt(command);
            return command;
        }


        public static string SelectCommand()
        {
            Write("Please enter your command or Q to quit the game (1.Make a Move 2.Undo a Previous Move 3.SaveGame)>> ");
            string command = ReadLine();
            while (!CheckValidCommand(command))
            {
                if (command == "3") break;
                Write("Invalid Command!Please re-enter>> ");
                command = ReadLine();
            };
            return command;
        }


        public static bool CheckValidCommand(string command)
        {
            if (command.ToUpper() == "Q") Environment.Exit(0);
            if (command == "1" || command == "2") return true;
            return false;
        }

        public static string RePrompt(string command)
        {
            while (!CheckValidCommand(command))
            {
                Write("Invalid Command!Please re-enter>> ");
                command = ReadLine();
            };

            return command;
        }
    }
}
