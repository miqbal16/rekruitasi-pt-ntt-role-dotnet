
namespace ParkingLot
{
    public class ParkingLot
    {
        private Vehicle?[]? _lots;
        private int _slotLots;

        public void CreateParkingLot(int slotLots)
        {
            if (slotLots < 0)
            {
                Console.WriteLine("Slot parking must positive value\n");
            }
            else
            {
                _slotLots = slotLots;
                _lots = new Vehicle[_slotLots];
                Console.WriteLine($"Created a parking lot with {_slotLots} slots\n");
            }
        }


        public void Park(string vehicleData)
        {
            if (IsParkingLotCreated())
            {
                var vehicleDataArr = vehicleData.Split(" ");

                if (vehicleDataArr[2].ToLower() != "mobil" && vehicleDataArr[2].ToLower() != "motor")
                {
                    Console.WriteLine("Parking is only for cars and motorbikes\n");
                    return;
                }

                if (IsVehicleHasRegistered(vehicleDataArr[0]))
                {
                    Console.WriteLine("The vehicle has been registered in the parking lot\n");
                    return;
                }

                Vehicle vehicle = new Vehicle();

                vehicle.PlateNumber = vehicleDataArr[0];
                vehicle.ColorVehicle = vehicleDataArr[1];
                vehicle.TypeVehicle = (ETypeVehicle)Enum.Parse(typeof(ETypeVehicle), vehicleDataArr[2]);

                int indexLotNumber = Array.IndexOf(_lots!, null);

                if (indexLotNumber != -1)
                {
                    _lots![indexLotNumber] = vehicle;
                    Console.WriteLine($"Allocated slot number: {indexLotNumber + 1}\n");
                }
                else
                {
                    Console.WriteLine("Sorry, parking lot is full\n");
                }
            }
            else
            {
                Console.WriteLine("Parking space has not been created yet\n");
            }
        }

        public void Leave(int slotNumber)
        {
            if (IsParkingLotCreated())
            {

                if (slotNumber < 1 || slotNumber > _lots?.Length)
                {
                    Console.WriteLine($"Slot number {slotNumber} is nothing\n");
                    return;
                }

                if (_lots?[slotNumber - 1] != null)
                {
                    _lots[slotNumber - 1] = null;
                    Console.WriteLine($"Slot number {slotNumber} is free\n");
                }
                else
                {
                    Console.WriteLine("There are no registered vehicles in the parking lot\n");
                }
            }
            else
            {
                Console.WriteLine("Parking space has not been created yet\n");
            }
        }

        public void Status()
        {
            if (IsParkingLotCreated())
            {

                Console.WriteLine("---------------------------------------------------------");
                Console.Write("Slot\t");
                Console.Write("No.\t\t");
                Console.Write("Type\t");
                Console.Write("Registration No Colour\n");

                for (int i = 0; i < _lots?.Length; i++)
                {
                    if (_lots[i] == null)
                    {
                        continue;
                    }

                    Console.Write($"{i + 1}\t");
                    Console.Write(_lots[i]?.PlateNumber + "\t");
                    Console.Write(_lots[i]?.TypeVehicle + "\t");
                    Console.Write(_lots[i]?.ColorVehicle + "\t");
                    Console.WriteLine();
                }
                Console.WriteLine("---------------------------------------------------------\n");
            }
            else
            {
                Console.WriteLine("Parking space has not been created yet\n");
            }

        }

        public void TypeOfVehicles(string vehicleType)
        {

            if (IsParkingLotCreated())
            {
                int count = 0;

                if (vehicleType.ToLower() == ETypeVehicle.Mobil.ToString().ToLower())
                {
                    for (int i = 0; i < _lots?.Length; i++)
                    {
                        if (_lots[i]?.TypeVehicle == ETypeVehicle.Mobil)
                        {
                            count++;
                        }
                    }
                }
                else if (vehicleType.ToLower() == ETypeVehicle.Motor.ToString().ToLower())
                {
                    for (int i = 0; i < _lots?.Length; i++)
                    {
                        if (_lots[i]?.TypeVehicle == ETypeVehicle.Motor)
                        {
                            count++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Vehicle is not found\n");
                    return;
                }

                Console.WriteLine(count + "\n");
            }
            else
            {
                Console.WriteLine("Parking space has not been created yet\n");
            }


        }

        public void RegistrationNumbersForVehiclesWithOodPlate()
        {
            if (IsParkingLotCreated())
            {

                string resVehiclePlateNumber = "";
                for (int i = 0; i < _lots?.Length; i++)
                {
                    var vehiclePlateNumber = int.Parse(_lots[i]?.PlateNumber.Split("-")[1] ?? "-1");

                    if (vehiclePlateNumber == -1)
                    {
                        continue;
                    }

                    if (vehiclePlateNumber % 2 != 0)
                    {
                        resVehiclePlateNumber += _lots[i]?.PlateNumber;
                        if (i < _lots.Length - 1)
                        {
                            resVehiclePlateNumber += ", ";
                        }
                    }
                }
                if (resVehiclePlateNumber != "")
                {
                    resVehiclePlateNumber = resVehiclePlateNumber.Trim();
                    if (resVehiclePlateNumber[resVehiclePlateNumber.Length - 1] == ',')
                    {
                        resVehiclePlateNumber = resVehiclePlateNumber.Substring(0, resVehiclePlateNumber.Length - 1);
                    }
                }
                Console.WriteLine(resVehiclePlateNumber + "\n");
            }
            else
            {
                Console.WriteLine("Parking space has not been created yet\n");
            }

        }

        public void RegistrationNumbersForVehiclesWithEventPlate()
        {
            if (IsParkingLotCreated())
            {
                string resVehiclePlateNumber = "";
                for (int i = 0; i < _lots!.Length; i++)
                {
                    var vehiclePlateNumber = int.Parse(_lots[i]?.PlateNumber.Split("-")[1] ?? "-1");

                    if (vehiclePlateNumber == -1)
                    {
                        continue;
                    }

                    if (vehiclePlateNumber % 2 == 0)
                    {
                        resVehiclePlateNumber += _lots[i]?.PlateNumber;
                        if (i < _lots.Length - 1)
                        {
                            resVehiclePlateNumber += ", ";
                        }
                    }
                }

                if (resVehiclePlateNumber != "")
                {
                    resVehiclePlateNumber = resVehiclePlateNumber.Trim();
                    if (resVehiclePlateNumber[resVehiclePlateNumber.Length - 1] == ',')
                    {
                        resVehiclePlateNumber = resVehiclePlateNumber.Substring(0, resVehiclePlateNumber.Length - 1);
                    }
                }

                Console.WriteLine(resVehiclePlateNumber + "\n");
            }
            else
            {
                Console.WriteLine("Parking space has not been created yet\n");
            }

        }

        public void RegistrationNumbersForVehiclesWithColour(string color)
        {
            if (IsParkingLotCreated())
            {
                string resVehiclePlateNumber = "";
                for (int i = 0; i < _lots!.Length; i++)
                {
                    var vehicleColor = _lots[i]?.ColorVehicle ?? "";

                    if (vehicleColor == "")
                    {
                        continue;
                    }

                    if (vehicleColor == color)
                    {
                        resVehiclePlateNumber += _lots[i]?.PlateNumber;

                        if (i < _lots.Length - 1)
                        {
                            resVehiclePlateNumber += ", ";
                        }
                    }
                }

                if (resVehiclePlateNumber != "")
                {
                    resVehiclePlateNumber = resVehiclePlateNumber.Trim();
                    if (resVehiclePlateNumber[resVehiclePlateNumber.Length - 1] == ',')
                    {
                        resVehiclePlateNumber = resVehiclePlateNumber.Substring(0, resVehiclePlateNumber.Length - 1);
                    }
                }

                Console.WriteLine(resVehiclePlateNumber + "\n");

            }
            else
            {
                Console.WriteLine("Parking space has not been created yet\n");
            }

        }

        public void SlotNumbersForVehiclesWithColour(string color)
        {
            if (IsParkingLotCreated())
            {
                string slotNumbersVehicle = "";
                for (int i = 0; i < _lots?.Length; i++)
                {
                    if (_lots[i]?.ColorVehicle == color)
                    {
                        slotNumbersVehicle += $"{i + 1}";
                        if (i < _lots.Length - 1)
                        {
                            slotNumbersVehicle += ", ";
                        }
                    }
                }

                if (slotNumbersVehicle != "")
                {
                    slotNumbersVehicle = slotNumbersVehicle.Trim();
                    if (slotNumbersVehicle[slotNumbersVehicle.Length - 1] == ',')
                    {
                        slotNumbersVehicle = slotNumbersVehicle.Substring(0, slotNumbersVehicle.Length - 1);
                    }

                }
                Console.WriteLine(slotNumbersVehicle + "\n");
            }
            else
            {
                Console.WriteLine("Parking space has not been created yet\n");
            }
        }


        public void SlotNumberForRegistrationNumber(string plateNumber)
        {
            if (IsParkingLotCreated())
            {
                for (int i = 0; i < _lots?.Length; i++)
                {
                    if (_lots[i]?.PlateNumber == plateNumber)
                    {
                        Console.WriteLine(i + 1 + "\n");
                        return;
                    }
                }

                Console.WriteLine("Not found\n");
            }
            else
            {
                Console.WriteLine("Parking space has not been created yet\n");
            }
        }

        private bool IsParkingLotCreated()
        {
            return _lots != null;
        }

        private bool IsVehicleHasRegistered(string plateNumber)
        {
            bool found = false;

            for (int i = 0; i < _lots?.Length; i++)
            {
                if (plateNumber == _lots[i]?.PlateNumber)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

    }
}