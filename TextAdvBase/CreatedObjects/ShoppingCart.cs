
using Nyandisk.TextAdvBase.ID;
using Nyandisk.TextAdvBase.Items;

namespace TextAdvBase.CreatedObjects
{
    public class ShoppingCart : Item
    {
        public override GlobalIdentification.ItemID ID => GlobalIdentification.ItemID.SHOPPING_CART;

        public override string Name => "Shopping cart";

        public override string Description => "Abandoned by netq. How sad.";

        public override bool CanBeTaken => false;

        public override void OnUse()
        {
            throw new NotImplementedException();
        }
        
    }
}
