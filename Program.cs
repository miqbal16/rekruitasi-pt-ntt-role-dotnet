using System;
using System.Security.Cryptography;

namespace ParkingLot
{
  public class Program
  {
    public static void Main(string[] args)
    {

      var parkingLot = new ParkingLot();

      Console.WriteLine("\nPress 'help' for check list command: \n");
      while (true)
      {
        Console.Write("$ ");
        string input = Console.ReadLine()!;
        var inputArray = input.Split(" ");
        switch (inputArray[0])
        {
          case "help":
            {
              Console.WriteLine("----------------------------------------------------------------------");
              Console.WriteLine("LIST COMMAND: ");
              Console.WriteLine("----------------------------------------------------------------------");
              Console.WriteLine("- create_parking_lot 'input_capacity_parking_lot'");
              Console.WriteLine("- park 'data_vehicle'");
              Console.WriteLine("- leave 'slotNumber'");
              Console.WriteLine("- status");
              Console.WriteLine("- type_of_vehicles 'type_vehicle'");
              Console.WriteLine("- registration_numbers_for_vehicles_with_ood_plate");
              Console.WriteLine("- registration_numbers_for_vehicles_with_event_plate");
              Console.WriteLine("- registration_numbers_for_vehicles_with_colour 'color_value'");
              Console.WriteLine("- slot_numbers_for_vehicles_with_colour 'color_value'");
              Console.WriteLine("- slot_number_for_registration_number 'plate_number'");
              Console.WriteLine("- exit\n");

              Console.WriteLine("[Example Use: leave 4]\n");
              Console.WriteLine("Note: '' is a value must input\n");
              Console.WriteLine("----------------------------------------------------------------------\n");
              break;
            }
          case "create_parking_lot":
            {

              if (inputArray.Length == 1)
              {
                Console.WriteLine("No value is input to the parameter\n");
              }
              else
              {
                int capacity;
                bool isSuccess = int.TryParse(inputArray[1].Trim(), out capacity);
                if (!isSuccess)
                {
                  Console.WriteLine("Capacity value input is not valid\n");
                }
                else
                {
                  parkingLot.CreateParkingLot(capacity);
                }
              }
              break;
            }
          case "park":
            {

              if (inputArray.Length < 4 || inputArray[1] == "" || inputArray[2] == "" || inputArray[3] == "")
              {
                Console.WriteLine("No value is input to the parameter\n");
              }
              else
              {
                string vehicle = $"{inputArray[1]} {inputArray[2]} {inputArray[3]}".Trim();
                parkingLot.Park(vehicle);
              }
              break;
            }
          case "leave":
            {

              if (inputArray.Length == 1)
              {
                Console.WriteLine("No value is input to the parameter\n");
              }
              else
              {
                int slotNumber;
                bool isSuccess = int.TryParse(inputArray[1].Trim(), out slotNumber);

                if (!isSuccess)
                {
                  Console.WriteLine("Slot number input is not valid\n");
                }
                else
                {
                  parkingLot.Leave(slotNumber);
                }
              }
              break;
            }
          case "status":
            {
              parkingLot.Status();
              break;
            }
          case "type_of_vehicles":
            {
              if (inputArray.Length == 1)
              {
                Console.WriteLine("No value is input to the parameter\n");
              }
              else
              {
                string vehicle = inputArray[1].Trim();
                parkingLot.TypeOfVehicles(vehicle);
              }
              break;
            }
          case "registration_numbers_for_vehicles_with_ood_plate":
            parkingLot.RegistrationNumbersForVehiclesWithOodPlate();
            break;
          case "registration_numbers_for_vehicles_with_event_plate":
            parkingLot.RegistrationNumbersForVehiclesWithEventPlate();
            break;
          case "registration_numbers_for_vehicles_with_colour":
            {
              if (inputArray.Length == 1)
              {
                Console.WriteLine("No value is input to the parameter\n");
              }
              else
              {
                string color = inputArray[1];
                parkingLot.RegistrationNumbersForVehiclesWithColour(color);
              }
              break;
            }
          case "slot_numbers_for_vehicles_with_colour":
            {
              if (inputArray.Length == 1)
              {
                Console.WriteLine("No value is input to the parameter\n");
              }
              else
              {
                string color = inputArray[1];
                parkingLot.SlotNumbersForVehiclesWithColour(color);
              }
              break;
            }
          case "slot_number_for_registration_number":
            {
              if (inputArray.Length == 1)
              {
                Console.WriteLine("No value is input to the parameter\n");
              }
              else
              {
                string registrationNumber = inputArray[1];
                parkingLot.SlotNumberForRegistrationNumber(registrationNumber);
              }
              break;
            }
          case "exit":
            {
              Environment.Exit(0);
              break;
            }
          default:
            Console.WriteLine("Command not found\n");
            break;
        }
      }
    }
  }
}