using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdvBase.CreatedObjects;
using Nyandisk.TextAdvBase.Rooms;

namespace Nyandisk.TextAdvBase.ID
{
    /// <summary>
    /// The static class that contains all IDs and the starting room. Used everywhere.
    /// </summary>
    public static class GlobalIdentification
    {
        /// <summary>
        /// The starting room that the player starts in. Has to be set manually otherwise an engine error appears.
        /// </summary>
        public static Room? StartingRoom = new ParkingLot();
        //reserved 1-1000
        /// <summary>
        /// All exit IDs. Has to be declared manually. Value range is 1-1000
        /// </summary>
        public enum ExitID
        {
            PARKING_LOT_HOME = 1
        }
        //reserved 1001-2000
        /// <summary>
        /// All room IDs. Has to be declared manually. Value range is 1001-2000
        /// </summary>
        public enum RoomID
        {
            PARKING_LOT = 1001
        }
        //reserved 2001-4000
        /// <summary>
        /// All item IDs. Has to be declared manually. Value range is 2001-4000
        /// </summary>
        public enum ItemID
        {
            SHOPPING_CART = 2001
        }
        //reserved 4001-5000
        /// <summary>
        /// All inventory IDs. Has to be declared manually. Value range is 4001-5000
        /// </summary>
        public enum InventoryID
        {
            PLAYER = 4001,
            PARKING_LOT_OBJECTS = 4002
        }
    }
}
