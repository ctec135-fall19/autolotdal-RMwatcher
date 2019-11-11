/*
Author: Richard Mora
Date: 11/10/2019
CTEC 135: Microsoft Software Development with C#

(Bonus) DAL Example
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotDAL.DataOperations;
using AutoLotDAL.Models;
using static System.Console;

namespace AutoLotClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryDAL dal = new InventoryDAL();
            var list = dal.GetAllInventory();

            WriteLine(" ***************** All Cars ***************** ");
            WriteLine("CarId\tMake\tColor\tPet Name");

            foreach (var item in list)
            {
                WriteLine($"{item.CarId}\t{item.Make}\t{item.Color}\t{item.PetName}\n");
            }
            var car = dal.GetCar(list.OrderBy(x => x.Color).Select(x => x.CarId).First());

            WriteLine(" ***************** First Car By Color *************** ");
            WriteLine("CarId\tMake\tColor\tPet Name");
            WriteLine($"{car.CarId}\t{car.Make}\t{car.Color}\t{car.PetName}");

            try
            {
                dal.DeleteCar(5);
                WriteLine("Car Deleted.");
            }

            catch (Exception ex)
            {
                WriteLine($"An exception occured: {ex.Message}");
            }

            dal.InsertAuto(new Car { Color = "Blue", Make = "Pilot", 
                PetName = "TowMonster" });
            list = dal.GetAllInventory();

            var newCar = list.First(x => x.PetName == "TowMonster");
            WriteLine(" ***************** New Car ********************* ");
            WriteLine("CarId\tMake\tColor\tPet Name");
            WriteLine($"{newCar.CarId}\t{newCar.Make}\t{newCar.Color}\t{newCar.PetName}");
            dal.DeleteCar(newCar.CarId);

            /*
            following lines is for store procedure ignore
            var petName = dal.LookUpPetName(car.CarId);
            WriteLine(" ***************** New Car ******************** ");
            WriteLine($"Car pet name: {petName}");
            */
            Write("Press enter to continue...");
            ReadLine();
        }
    }
}
