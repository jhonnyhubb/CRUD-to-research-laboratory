using System;

namespace DIO.Laboratory
{
    class Program
    {
        static LaboratoryRepository repository = new LaboratoryRepository();
        static void Main(string[] args)
        {
            string optionUser = ObtainOptionUser();

			while (optionUser.ToUpper() != "X")
			{
				switch (optionUser)
				{
					case "1":
						ListItens();
						break;
					case "2":
						InsertItem();
						break;
					case "3":
						UpdateItem();
						break;
					case "4":
						DeleteItem();
						break;
					case "5":
						ViewItens();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				optionUser = ObtainOptionUser();
			}

			Console.WriteLine("Thank you for use our services.");
			Console.ReadLine();
        }

        private static void DeleteItem()
		{
			Console.Write("Insert the item Id: ");
			int indexItem = int.Parse(Console.ReadLine());

			repository.Delete(indexItem);
		}

        private static void ViewItens()
		{
			Console.Write("Insert the item Id: ");
			int indexItem = int.Parse(Console.ReadLine());

			var item = repository.ReturnId(indexItem);

			Console.WriteLine(item);
		}

        private static void UpdateItem()
		{
			Console.Write("Insert the item Id: ");
			int indexItem = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(ItemType)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(ItemType), i));
			}
			Console.Write("Enter the item type between the options above: ");
			int inputItemType = int.Parse(Console.ReadLine());

			Console.Write("Enter the name of item: ");
			string inputItemName = Console.ReadLine();

			Console.Write("Enter the year that we buy the item: ");
			int inputYear = int.Parse(Console.ReadLine());

			Console.Write("Enter the item description: ");
			string inputDescription = Console.ReadLine();

			Item updateItem = new Item(id: indexItem,
										itemType: (ItemType)inputItemType,
										itemName: inputItemName,
										year: inputYear,
										description: inputDescription);

			repository.Update(indexItem, updateItem);
		}
        private static void ListItens()
		{
			Console.WriteLine("List itens");

			var list = repository.List();

			if (list.Count == 0)
			{
				Console.WriteLine("No item registered.");
				return;
			}

			foreach (var item in list)
			{
                var deleted = item.returnDeleted();
                
				Console.WriteLine("#ID {0}: - {1} {2}", item.returnId(), item.returnItemName(), (deleted ? "*Deleted*" : ""));
			}
		}

        private static void InsertItem()
		{
			Console.WriteLine("Insert new item: ");

			foreach (int i in Enum.GetValues(typeof(ItemType)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(ItemType), i));
			}
			Console.Write("Enter the item type between the options above: ");
			int inputItemType = int.Parse(Console.ReadLine());

			Console.Write("Enter the name of item: ");
			string inputItemName = Console.ReadLine();

			Console.Write("Enter the year that we buy the item: ");
			int inputYear = int.Parse(Console.ReadLine());

			Console.Write("Enter the item description: ");
			string inputDescription = Console.ReadLine();

			Item newItem = new Item(id: repository.NextId(),
										itemType: (ItemType)inputItemType,
										itemName: inputItemName,
										year: inputYear,
										description: inputDescription);

			repository.Insert(newItem);			
		}

        private static string ObtainOptionUser()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("SUPRAMMAT Laboratory warehouse!!!");
            System.Console.WriteLine("Which is your wish?");

            System.Console.WriteLine("1- list itens");
            System.Console.WriteLine("2- Insert new item");
            System.Console.WriteLine("3- Update item");
            System.Console.WriteLine("4- Remove item");
            System.Console.WriteLine("5- View item");
            System.Console.WriteLine("C- Clean the window");
            System.Console.WriteLine("X- exit");
            
            string optionUser = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return optionUser;
        }
    }
}
