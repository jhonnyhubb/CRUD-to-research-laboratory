using System;
using DIO.Laboratory;
using DIO.Laboratory.Interfaces;

namespace DIO.Laboratory
{
    public class Item : EntityBase
    {
        // Attributes
		private ItemType ItemType { get; set; }
		private string ItemName { get; set; }
		private string Description { get; set; }
		private int Year { get; set; }
        private bool Deleted {get; set;}

        // Métodos
		public Item(int id, ItemType itemType, string itemName, string description, int year)
		{
			this.Id = id;
			this.ItemType = itemType;
			this.ItemName = itemName;
			this.Description = description;
			this.Year = year;
            this.Deleted = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string regress = "";
            regress += "Item type: " + this.ItemType + Environment.NewLine;
            regress += "Item name: " + this.ItemName + Environment.NewLine;
            regress += "Description: " + this.Description + Environment.NewLine;
            regress += "We buy this item at: " + this.Year + Environment.NewLine;
            regress += "Deleted: " + this.Deleted;
			return regress;
		}

        public string returnItemName()
		{
			return this.ItemName;
		}

		public int returnId()
		{
			return this.Id;
		}
        public bool returnDeleted()
		{
			return this.Deleted;
		}
        public void Delete() {
            this.Deleted = true;
        }
    }
}