using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nyandisk.TextAdvBase.Items;
using Nyandisk.TextAdvBase.Other;
using Nyandisk.TextAdvBase.Rooms;

namespace Nyandisk.TextAdvBase.Command
{
    public class CommandProcessor
    {
        /// <summary>
        /// Words/Phrases that trigger the inspect function
        /// </summary>
        public List<string> inspectCommands = new() {
            "inspect the",
            "look at the",
            "investigate the",
            "inspect",
            "look at",
            "investigate"
        };
        /// <summary>
        /// Words/Phrases that trigger the use function
        /// </summary>
        public List<string> useCommands = new() {
            "use the",
            "use"
        };
        /// <summary>
        /// Words/Phrases that trigger the move function
        /// </summary>
        public List<string> moveCommands = new() {
            "move to",
            "move",
            "move to the",
            "go to",
            "go",
            "go to the",
            "travel to",
            "travel to the",
            "travel"
        };
        /// <summary>
        /// Words/Phrases that trigger the take function
        /// </summary>
        public List<string> takeCommands = new() {
            "grab the",
            "grab",
            "take the",
            "take",
            "get the",
            "get"
        };
        /// <summary>
        /// Takes arguments (lowercase) and player (instance) .
        /// checks if room has item, then gets said item and runs the item's OnInspect.
        /// </summary>
        public void Inspect(string args, Player player) {
            if (player.CurrentRoom.Objects.HasItem(args))
            {
                Item? chosenItem = player.CurrentRoom.Objects.GetItem(args);
                if (chosenItem != null)
                {
                    chosenItem.OnInspect();
                    return;
                }
            }
            Console.WriteLine("You can't inspect that item.");

        }
        /// <summary>
        /// Takes arguments (lowercase) and player (instance) .
        /// checks if room has item, then gets said item, checks if it can be taken and if player has enough room in inventory.
        /// if all that is true, the AddItem function will add the item. Otherwise error message.
        /// </summary>
        public void Take(string args, Player player)
        {
            if (player.CurrentRoom.Objects.HasItem(args))
            {
                Item? chosenItem = player.CurrentRoom.Objects.GetItem(args);
                if (chosenItem != null)
                {
                    if (chosenItem.CanBeTaken)
                    {
                        bool worked = player.PlayerInventory.AddItem(chosenItem);
                        if (worked) {
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("Item can't be taken, or you do not have enough room in your inventory.");
        }
        /// <summary>
        /// Takes arguments (lowercase) and player (instance) .
        /// checks if inventory has item, then gets said item, and runs OnUse.
        /// if something goes wrong, displays error.
        /// </summary>
        public void Use(string args, Player player)
        {
            if (player.PlayerInventory.HasItem(args))
            {
                Item? chosenItem = player.PlayerInventory.GetItem(args);
                if (chosenItem != null)
                {
                    chosenItem.OnUse();
                    return;
                }
            }
            Console.WriteLine("You can't use that item.");
        }
        /// <summary>
        /// Takes arguments (lowercase) and player (instance) 
        /// checks if the current room has an exit called whatever args is, if it exists, calls player.ChangeRoom.
        /// 
        /// if something goes wrong, displays error.
        /// </summary>
        public void Move(string args, Player player) {
            Room currentRoom = player.CurrentRoom;
            Exit? chosen = currentRoom.GetExit(args);
            if (chosen == null)
            {
                Console.WriteLine("You can't move there.");
                return;
            }
            player.ChangeRoom(chosen.Target);
        }
        /// <summary>
        /// Processes raw player input and checks for any internal commands.
        /// </summary>
        /// <param name="command"> The raw user input provided. Gets turned into lower case.</param>
        /// <param name="p"> Player passthrough</param>
        public void ProcessCommand(string command, Player p) {
            command= command.ToLower();
            string[] parts = command.Split(" ");
            if (parts[0] == "inventory")
            {
                Console.WriteLine($"Backpack: {p.PlayerInventory.Items.Count}/{p.PlayerInventory.GetContainerSize()}");
                if (p.PlayerInventory.Items.Count > 0)
                {
                    foreach (Item i in p.PlayerInventory.Items)
                    {
                        Console.WriteLine($"+ {i.Name}");
                    }

                }
                else
                {
                    Console.WriteLine("Your backpack is empty. There is nothing to display.");
                }
                return;
            }
            if (parts[0] == "clear")
            {
                Console.Clear();
                p.CurrentRoom.IntroDisplay();
                return;
            }
            foreach (string inspectCommand in inspectCommands) {
                if (command.Contains(inspectCommand))
                {
                    int wordsInInspectCommand = inspectCommand.Split(" ").Length;
                    var otherParts = parts.Skip(wordsInInspectCommand).Take(parts.Length-wordsInInspectCommand).Select(eachElement => eachElement.Clone()).ToArray();
                    Inspect(string.Join(" ",otherParts), p);
                    return;
                }
            }
            foreach (string useCommand in useCommands)
            {
                if (command.Contains(useCommand))
                {
                    int wordsInUseCommand = useCommand.Split(" ").Length;
                    var otherParts = parts.Skip(wordsInUseCommand).Take(parts.Length - wordsInUseCommand).Select(eachElement => eachElement.Clone()).ToArray();
                    Use(string.Join(" ", otherParts), p);
                    return;
                }
            }
            foreach (string moveCommand in moveCommands)
            {
                if (command.Contains(moveCommand))
                {
                    int wordsInMoveCommand = moveCommand.Split(" ").Length;
                    var otherParts = parts.Skip(wordsInMoveCommand).Take(parts.Length - wordsInMoveCommand).Select(eachElement => eachElement.Clone()).ToArray();
                    Move(string.Join(" ", otherParts), p);
                    return;
                }
            }
            foreach (string takeCommand in takeCommands)
            {
                if (command.Contains(takeCommand))
                {
                    int wordsInTakeCommand = takeCommand.Split(" ").Length;
                    var otherParts = parts.Skip(wordsInTakeCommand).Take(parts.Length - wordsInTakeCommand).Select(eachElement => eachElement.Clone()).ToArray();
                    Take(string.Join(" ", otherParts), p);
                    return;
                }
            }
            Console.WriteLine("Invalid command.");
        }  
    }
}
