using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nyandisk.TextAdvBase.Items;
using Nyandisk.TextAdvBase.ID;
using System.Xml.Linq;
using System.Data;
using Nyandisk.TextAdvBase.Other;

namespace Nyandisk.TextAdvBase.Rooms
{
    /// <summary>
    /// Provides a space for the player to be in.
    /// </summary>
    public abstract class Room
    {
        /// <summary>
        /// The ID of the room. Must be created manually in GlobalIdentification.cs
        /// </summary>
        public abstract GlobalIdentification.RoomID ID { get; }
        /// <summary>
        /// Display name
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// Display description
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        /// Inventory instance with all the level's objects.
        /// </summary>
        public abstract Inventory Objects { get; }
        /// <summary>
        /// List<Exit> With references to all the exits
        /// </summary>
        public abstract List<Exit> Exits { get; }
        /// <summary>
        /// Displays Name, Description, Objects, Exits. Then calls OnEnter.
        /// Can be overriden. (However not suggested.)
        /// </summary>
        public virtual void IntroDisplay()
        {
            Console.WriteLine(Name);
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
            Console.Write("Objects: ");
            foreach (Item i in Objects.Items)
            {
                Console.Write(i.Name);
            }
            Console.WriteLine();
            Console.Write("Exits: ");
            foreach(Exit e in Exits)
            {
                Console.Write(e.Name);
            }
            Console.WriteLine();
            OnEnter();
        }
        /// <summary>
        /// Gets the exit based on the name given
        /// </summary>
        /// <param name="name">Name of the exit</param>
        /// <returns>null if exit couldn't be found, Exit if exit found</returns>
        public Exit? GetExit(string name)
        {
            if (HasExit(name))
            {
                foreach (Exit e in Exits)
                {
                    if (e.Name.ToLower() == name.ToLower())
                    {
                        return e;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Gets the exit based on the name given
        /// </summary>
        /// <param name="id">ID of the exit</param>
        /// <returns>null if exit couldn't be found, Exit if exit found</returns>
        public Exit? GetExit(GlobalIdentification.ExitID id)
        {
            if (HasExit(id))
            {
                foreach(Exit e in Exits)
                {
                    if (e.ID == id)
                    {
                        return e;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Exits the room with the given exit.
        /// </summary>
        /// <param name="exitName">Name of the exit</param>
        /// <param name="p">Player that exits</param>
        /// <returns>if exit was successful, true, else false.</returns>
        public bool ExitUsing(string exitName,Player p)
        {
            if (HasExit(exitName))
            {
                Exit? exit = GetExit(exitName);
                if (exit == null)
                {
                    return false;
                }
                OnLeave();
                p.ChangeRoom(exit.Target);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Check if room has an exit by the name of ...
        /// </summary>
        /// <param name="name">Exit name</param>
        /// <returns>true if has, else false</returns>
        public bool HasExit(string name)
        {
            foreach (Exit e in Exits)
            {
                if (e.Name.ToLower() == name.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Check if room has an exit by the id of ...
        /// </summary>
        /// <param name="id">Exit id</param>
        /// <returns>true if has, else false</returns>
        public bool HasExit(GlobalIdentification.ExitID id)
        {
            foreach (Exit e in Exits)
            {
                if (e.ID == id)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Triggered after IntroDisplay
        /// </summary>
        public abstract void OnEnter();
        /// <summary>
        /// Triggered in ExitUsing, right before player.ChangeRoom
        /// </summary>
        public abstract void OnLeave();

    }
}
