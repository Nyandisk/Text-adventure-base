using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nyandisk.TextAdvBase.ID;
using Nyandisk.TextAdvBase.Items;
using Nyandisk.TextAdvBase.Rooms;

namespace Nyandisk.TextAdvBase.Other
{
    /// <summary>
    /// The player that plays the game perhaps
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Health of the player.
        /// </summary>
        public double Health;
        /// <summary>
        /// Username of the player
        /// </summary>
        public string Username;
        /// <summary>
        /// Inventory of the player
        /// </summary>
        public Inventory PlayerInventory;
        /// <summary>
        /// The current room that the player is in.
        /// </summary>
        public Room CurrentRoom;
        /// <summary>
        /// Change the room that the player is in.
        /// </summary>
        /// <param name="rm">Room to change to</param>
        public void ChangeRoom(Room rm)
        {
            CurrentRoom = rm;
            CurrentRoom.IntroDisplay();
        }
        /// <summary>
        /// Sets parameters, calls CurrentRoom.IntroDisplay
        /// </summary>
        /// <param name="username">Username of the player</param>
        /// <param name="startingRoom">Starting room</param>
        /// <param name="startingItems">Items that the player starts with</param>
        /// <param name="startingHealth">Health amount at the start</param>
        public Player(string username,Room startingRoom,List<Item>? startingItems =null, double startingHealth=100.0) {
            PlayerInventory = new Inventory(inventoryParentName: "Player",size: 8,baseItems: startingItems,IID:GlobalIdentification.InventoryID.PLAYER);
            Health = startingHealth;
            Username = username;
            CurrentRoom= startingRoom;
            CurrentRoom.IntroDisplay();
        }
    }
}
