using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Nyandisk.TextAdvBase.ID;

namespace Nyandisk.TextAdvBase.Items
{
    /// <summary>
    /// Any container (Containers are not implemented yet) that can have items inside of it must  be an inventory.
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// name of the inventory
        /// </summary>
        public string ContainerName = string.Empty;
        /// <summary>
        /// max items in inventory
        /// </summary>
        public int ContainerSize = 0;
        /// <summary>
        /// All items in the inventory
        /// </summary>
        public List<Item> Items = new List<Item>();
        /// <summary>
        /// ID of the inventory
        /// </summary>
        public GlobalIdentification.InventoryID ID;
        
        public Inventory(string inventoryParentName, int size, GlobalIdentification.InventoryID IID, List<Item>? baseItems = null) {
            if (baseItems != null)
            {
                Items = baseItems;
            }
            ContainerName = inventoryParentName;
            ContainerSize = size;
            ID = IID;
        }
        /// <summary>
        /// Checks if inventory has item
        /// </summary>
        /// <param name="i">item reference</param>
        /// <returns>true or false</returns>
        public bool HasItem(Item i)
        {
            return Items.Contains(i);
        }
        /// <summary>
        /// Checks if inventory has item
        /// </summary>
        /// <param name="name">string name</param>
        /// <returns>true or false</returns>
        public bool HasItem(string name)
        {
            foreach(Item i in Items)
            {
                if (i.Name.ToLower() == name.ToLower()) {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if inventory has item
        /// </summary>
        /// <param name="id">itemid id</param>
        /// <returns>true or false</returns>
        public bool HasItem(GlobalIdentification.ItemID id)
        {
            foreach (Item i in Items)
            {
                if (i.ID == id)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Size of the inventory
        /// </summary>
        /// <returns>Size of the inventory</returns>
        public int GetContainerSize()
        {
            return ContainerSize;
        }
        /// <summary>
        /// Gets the name of the inventory
        /// </summary>
        /// <returns>Name of the inventory</returns>
        public string GetContainerName()
        {
            return ContainerName;
        }
        /// <summary>
        /// Gets an item by the name provided
        /// </summary>
        /// <param name="name">item name</param>
        /// <returns>item if it exists, null if item doesnt exist</returns>
        public Item? GetItem(string name)
        {
            foreach (Item i in Items)
            {
                if (i.Name.ToLower() == name.ToLower())
                {
                    return i;
                }
            }
            return null;
        }
        /// <summary>
        /// Gets an item by the id provided
        /// </summary>
        /// <param name="id">item id</param>
        /// <returns>item if it exists, null if item doesnt exist</returns>
        public Item? GetItem(GlobalIdentification.ItemID id)
        {
            foreach (Item i in Items)
            {
                if (i.ID == id)
                {
                    return i;
                }
            }
            return null;
        }
        /// <summary>
        /// Adds an item into the inventory. If the inventory is full, returns false. (fail)
        /// </summary>
        /// <param name="i">item to add</param>
        /// <returns>true or false</returns>
        public bool AddItem(Item i) {
            if (Items.Count + 1 <= ContainerSize)
            {
                Items.Add(i);
                return true;
            }
            else {
                return false;
            }
        }
        /// <summary>
        /// Removes an item from the inventory, if it exists that is. (returns false if item doesnt exist in inventory)
        /// </summary>
        /// <param name="i">Item to remove</param>
        /// <returns>true or false</returns>
        public bool RemoveItem(Item i)
        {
            if (Items.Contains(i))
            {
                Items.Remove(i);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
