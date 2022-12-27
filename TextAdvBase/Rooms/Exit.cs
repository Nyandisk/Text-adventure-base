using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nyandisk.TextAdvBase.ID;

namespace Nyandisk.TextAdvBase.Rooms
{
    /// <summary>
    /// Used inside rooms to provide the player with exits to move to.
    /// </summary>
    public class Exit
    {
        /// <summary>
        /// Exit name
        /// </summary>
        public string Name;
        /// <summary>
        /// Target room name (the room that the exit exits to)
        /// </summary>
        public Room Target;
        /// <summary>
        /// Exit ID
        /// </summary>
        public GlobalIdentification.ExitID ID;
        /// <summary>
        /// Exit constructor. takes a name (string), target (Room), id (GlobalIdentification.ExitID) 
        /// </summary>
        /// <param name="name">Name of the exit</param>
        /// <param name="target">The room that the exit exits to</param>
        /// <param name="id">ID of the exit</param>
        public Exit(string name, Room target, GlobalIdentification.ExitID id) {
            Name = name; Target = target; ID = id;
        }
    }
}
