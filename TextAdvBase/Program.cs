

using Nyandisk.TextAdvBase.Command;
using Nyandisk.TextAdvBase.ID;
using Nyandisk.TextAdvBase.Other;
using Nyandisk.TextAdvBase.Rooms;

namespace Nyandisk.TextAdvBase
{
    class Program {
        public static Room? playerStartingRoom;
        public static void Main(string[] args) {
            playerStartingRoom = GlobalIdentification.StartingRoom;
            if (Program.playerStartingRoom == null)
            {
                Console.WriteLine("Engine configuration error. Player starting room not set.");
                return;
            }
            string? un;
            while (true)
            {
                Console.WriteLine("Whats your name?");
                Console.Write("> ");
                un = Console.ReadLine();
                if (un != null && !string.IsNullOrEmpty(un))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("I'm sorry, but a valid username is required.");
                }
            }
            Player player = new(username: un, Program.playerStartingRoom);
            CommandProcessor commandProcessor = new();
            while (true)
            {
                Console.Write("> ");
                string? cmd = Console.ReadLine();
                if (cmd != null && !string.IsNullOrEmpty(cmd))
                {
                    commandProcessor.ProcessCommand(cmd, player);
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                }
                
            }
        }
    }
}