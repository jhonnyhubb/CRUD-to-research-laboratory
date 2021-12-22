using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            string optionUser = ObtainOptionUser();

			while (optionUser.ToUpper() != "X")
			{
				switch (optionUser)
				{
					case "1":
						ListSeries();
						break;
					case "2":
						InsertSerie();
						break;
					case "3":
						UpdateSerie();
						break;
					case "4":
						DeleteSerie();
						break;
					case "5":
						ViewSerie();
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

        private static void DeleteSerie()
		{
			Console.Write("Insert the serie Id: ");
			int indexSerie = int.Parse(Console.ReadLine());

			repository.Delete(indexSerie);
		}

        private static void ViewSerie()
		{
			Console.Write("Insert the serie Id: ");
			int indexSerie = int.Parse(Console.ReadLine());

			var serie = repository.ReturnId(indexSerie);

			Console.WriteLine(serie);
		}

        private static void UpdateSerie()
		{
			Console.Write("Insert the serie Id: ");
			int indexSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Gender)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
			}
			Console.Write("Enter the gender between the options above: ");
			int inputGender = int.Parse(Console.ReadLine());

			Console.Write("Enter the serie title: ");
			string inputTitle = Console.ReadLine();

			Console.Write("Enter the year of start the serie: ");
			int inputYear = int.Parse(Console.ReadLine());

			Console.Write("Enter the serie description: ");
			string inputDescription = Console.ReadLine();

			Serie updateSerie = new Serie(id: indexSerie,
										gender: (Gender)inputGender,
										title: inputTitle,
										year: inputYear,
										description: inputDescription);

			repository.Update(indexSerie, updateSerie);
		}
        private static void ListSeries()
		{
			Console.WriteLine("List series");

			var list = repository.List();

			if (list.Count == 0)
			{
				Console.WriteLine("No série registered.");
				return;
			}

			foreach (var serie in list)
			{
                var deleted = serie.returnDeleted();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTitle(), (deleted ? "*Deleted*" : ""));
			}
		}

        private static void InsertSerie()
		{
			Console.WriteLine("Insert new serie: ");

			foreach (int i in Enum.GetValues(typeof(Gender)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
			}
			Console.Write("Enter the gender between the options above: ");
			int inputGender = int.Parse(Console.ReadLine());

			Console.Write("Enter the serie title: ");
			string inputTitle = Console.ReadLine();

			Console.Write("Enter the year of start the serie: ");
			int inputYear = int.Parse(Console.ReadLine());

			Console.Write("Enter the serie description: ");
			string inputDescription = Console.ReadLine();

			Serie newSerie = new Serie(id: repository.NextId(),
										gender: (Gender)inputGender,
										title: inputTitle,
										year: inputYear,
										description: inputDescription);

			repository.Insert(newSerie);			
		}

        private static string ObtainOptionUser()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Jhonny Séries at your service!!!");
            System.Console.WriteLine("which is your wish?");

            System.Console.WriteLine("1- list series");
            System.Console.WriteLine("2- Insert new serie");
            System.Console.WriteLine("3- Update serie");
            System.Console.WriteLine("4- Remove serie");
            System.Console.WriteLine("5- View serie");
            System.Console.WriteLine("C- Clean the window");
            System.Console.WriteLine("X- exit");
            
            string optionUser = Console.ReadLine().ToUpper();
            System.Console.WriteLine();
            return optionUser;
        }
    }
}
