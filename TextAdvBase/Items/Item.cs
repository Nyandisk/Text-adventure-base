using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nyandisk.TextAdvBase.ID;

namespace Nyandisk.TextAdvBase.Items
{
    /// <summary>
    /// An interactable Item.
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// ID of the item (must be declared manually like all other IDs)
        /// </summary>
        public abstract GlobalIdentification.ItemID ID { get; }
        /// <summary>
        /// Name of the item
        /// </summary>
        public abstract string Name { get; }
        /// <summary>
        /// Description of the item
        /// </summary>
        public abstract string Description { get; }
        /// <summary>
        /// Can the item be taken with take commands?
        /// </summary>
        public abstract bool CanBeTaken { get; }
        /// <summary>
        /// Called when the player uses a use command on the item
        /// </summary>
        public abstract void OnUse();
        /// <summary>
        /// Called when the player inspects the object. Can be overriden. By default displays description and if the item can be taken or not.
        /// </summary>
        public virtual void OnInspect()
        {
            Console.WriteLine(Description);
            Console.WriteLine((CanBeTaken) ? "Item can be taken." : "Item can't be taken.");
        }
    }
}
