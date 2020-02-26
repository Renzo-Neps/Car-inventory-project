﻿using System;

public class ProgramRun
{
	static void Main(string[] args)
	{
		Logic logic = new Logic();
		Inventory inventory = new Inventory();
		bool keepgoing = true;


		while (keepgoing)
		{
			//Console.Clear();
			Console.WriteLine("Car Inventory Menu");
			Console.WriteLine();
			Console.WriteLine("There is currently " + inventory.InventoryLength() + " cars in the system.");
			Console.WriteLine();
			Console.WriteLine("1) Remove/Edit/Display car");
			Console.WriteLine("2) Display all cars");
			Console.WriteLine("3) Add car");
			Console.WriteLine("4) Exit");

			int? input = logic.ConvertToInteger(Console.ReadLine());

			while(input.HasValue == false || (input > 4 || input < 1))
			{
				Console.WriteLine("You done did messaed a-aron, try again!");
				input = logic.ConvertToInteger(Console.ReadLine());
			}

			Console.Clear();

			if (input == 1)
			{
				Console.WriteLine("Please type in ID # of car");
				int? carId = logic.ConvertToInteger(Console.ReadLine());
				while (carId.HasValue == false || inventory.SearchCar((int) carId) == null)
				{
					Console.WriteLine("Car does not exist");
					Console.WriteLine("Please input another ID number");
					carId = logic.ConvertToInteger(Console.ReadLine());
				}
				Car foundCar = inventory.SearchCar((int)carId);

				Console.WriteLine("Please input a number between 1-3");
				Console.WriteLine("1) Remove car");
				Console.WriteLine("2) Edit car");
				Console.WriteLine("3) Display car");
				Console.WriteLine("4) Exit");

				int? input2 = logic.ConvertToInteger(Console.ReadLine());
				while (input2 > 4 || input2 < 1)
				{
					Console.WriteLine("Please input a number between 1-4");
					input2 = Convert.ToInt32(Console.ReadLine());
				}
				
				if (input2 == 1)
				{
					Console.Clear();
					inventory.Display(foundCar);
					Console.WriteLine();
					Console.WriteLine("Are you sure that you want to remove car?");
					Console.WriteLine("1) Yes");
					Console.WriteLine("2) No");

					int? i = logic.ConvertToInteger(Console.ReadLine());
					if (i == 1)
					{ inventory.RemoveCar(foundCar); }
				}
				else if (input2 == 2)
				{
					Console.Clear();
					foundCar.Make = inventory.StringEditMethod(foundCar.Make, "make");
					Console.WriteLine(foundCar.Make);
					foundCar.Model = inventory.StringEditMethod(foundCar.Model, "model");
					Console.WriteLine(foundCar.Model);
					foundCar.Year = inventory.IntEditMethod(foundCar.Year, "year");
					Console.WriteLine(foundCar.Year);
					foundCar.PurchasePrice = inventory.IntEditMethod(foundCar.PurchasePrice, "purchase price");
					Console.WriteLine(foundCar.PurchasePrice);
					foundCar.Miles = inventory.IntEditMethod(foundCar.Miles, "miles");
					Console.WriteLine(foundCar.Miles);
					foundCar.SellingPrice = inventory.IntEditMethod(foundCar.SellingPrice, "selling price");
					Console.WriteLine(foundCar.SellingPrice);
					foundCar.SoldPrice = inventory.IntEditMethod(foundCar.SoldPrice, "sold price");
					Console.WriteLine(foundCar.SoldPrice);
					foundCar.Color = inventory.StringEditMethod(foundCar.Color, "color");
					Console.WriteLine(foundCar.Color);
					inventory.UpdateCar(foundCar);
				}
				else if (input2 == 3)
				{
					inventory.Display(inventory.SearchCar((int) carId));
					Console.WriteLine();
					Console.ReadLine();
				}
				else
				{
					Console.Clear();
				}
			}
			else if (input == 2)
			{
				Console.Clear();
				Console.WriteLine("Displaying all cars");
				inventory.DisplayAll();
			}
			else if (input == 3)
			{
				Console.Clear();
				Console.WriteLine("Add a new car");
				Console.WriteLine();
				Car c = new Car();

				// Get ID Number
				Console.WriteLine("Please type an ID number for the car");
				int? idNumber = logic.ConvertToInteger(Console.ReadLine());
				while (idNumber == null || inventory.SearchCar((int)idNumber) != null)
				{
					Console.WriteLine("Id is invalid or already exsits. Try again");
					idNumber = logic.ConvertToInteger(Console.ReadLine());
				}
				c.IDNumber = (int)idNumber;

				Console.WriteLine("Please type the car manufacturer");
				c.Make = Console.ReadLine();
				Console.WriteLine("Please type the model of the car");
				c.Model = Console.ReadLine();
				Console.WriteLine("Please type the year of the car");
				c.Year = Convert.ToInt32(Console.ReadLine());
				//re ask the question if answer isn't valid
				Console.WriteLine("Please type the purchase price of the car");
				c.PurchasePrice = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Please type the milage of the car");
				c.Miles = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Please type the selling price of the car");
				c.SellingPrice = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Please type the sold price of the car");
				c.SoldPrice = Convert.ToInt32(Console.ReadLine());
				Console.WriteLine("Please type the color of the car");
				c.Color = Console.ReadLine();
				/*We can't use decimals for prices*/
				inventory.AddCar(c);
				Console.WriteLine();
				Console.WriteLine("Car added");
				Console.ReadLine();
			}
			else
			{
				keepgoing = false;
				Environment.Exit(0);
			}
		}
	}
}