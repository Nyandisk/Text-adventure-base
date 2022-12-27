using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nyandisk.TextAdvBase.ID;
using Nyandisk.TextAdvBase.Items;
using Nyandisk.TextAdvBase.Rooms;

namespace TextAdvBase.CreatedObjects
{
    public class ParkingLot : Room
    {
        public override GlobalIdentification.RoomID ID => GlobalIdentification.RoomID.PARKING_LOT;

        public override string Name => "Parking Lot";

        public override string Description => "You find yourself in a parking lot. It is quiet.";

        public override Inventory Objects => new Inventory(
            "ParkingLotObjects",
            20,
            GlobalIdentification.InventoryID.PARKING_LOT_OBJECTS,
            new List<Item>() {
                new ShoppingCart()
            }
        );

        public override List<Exit> Exits => new List<Exit>()
        {
            new Exit("Home",this,GlobalIdentification.ExitID.PARKING_LOT_HOME)
        };

        public override void OnEnter()
        {
            
        }

        public override void OnLeave()
        {
            
        }
    }
}
