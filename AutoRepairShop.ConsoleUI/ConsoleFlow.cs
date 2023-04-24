using AutoRepairShop.Logic.Factories.Implementation;
using AutoRepairShop.Logic.Factories.Interfaces;
using AutoRepairShop.Logic.Models.Implementation;
using AutoRepairShop.Logic.Utilities;
using AutoRepairShop.UI.Prompts;

namespace AutoRepairShop.ConsoleUI
{
    public class ConsoleFlow
    {
        public void Run()
        {
            while (true)
            {
                var (dateValidatorFactory, carInspectionCheckerFactory, carFactory, recallCheckerFactory) = InitializeFactories();

                try
                {
                    Car car = GetUserInputsAndCreateCar(dateValidatorFactory, carFactory);

                    CheckCarInspectionAndRecall(car, carInspectionCheckerFactory, recallCheckerFactory);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl: {ex.Message}");
                }

                Console.WriteLine(UserPrompts.PressToQuitProgram);
                if (Console.ReadKey().Key == ConsoleKey.Q) break;
                Console.Clear();
            }
        }

        private (IDateValidatorFactory, ICarInspectionCheckerFactory, ICarFactory, IRecallCheckerFactory) InitializeFactories()
        {
            IDateValidatorFactory dateValidatorFactory = new DateValidatorFactory();
            ICarInspectionCheckerFactory carInspectionCheckerFactory = new CarInspectionCheckerFactory();
            ICarFactory carFactory = new CarFactory();
            IRecallCheckerFactory recallCheckerFactory = new RecallCheckerFactory();

            return (dateValidatorFactory, carInspectionCheckerFactory, carFactory, recallCheckerFactory);
        }

        private Car GetUserInputsAndCreateCar(IDateValidatorFactory dateValidatorFactory, ICarFactory carFactory)
        {
            Console.Write(UserPrompts.CarBrand);
            string brandInput = Console.ReadLine();
            brandInput = brandInput.CleanString();

            Console.Write(UserPrompts.CarModel);
            string modelInput = Console.ReadLine();
            modelInput = modelInput.CleanString(); ;

            Console.Write(UserPrompts.CarYear);
            string yearInput = Console.ReadLine();
            DateTime modelYear = dateValidatorFactory.Create().GetCarModelYear(yearInput);

            Console.Write(UserPrompts.CarLastInspectionDate);
            string inspectionDateInput = Console.ReadLine();
            DateTime lastInspectionDate = dateValidatorFactory.Create().GetLastInspectionDate(inspectionDateInput);

            return carFactory.Create(brandInput, modelInput, modelYear, lastInspectionDate);
        }

        private void CheckCarInspectionAndRecall(Car car, ICarInspectionCheckerFactory carInspectionCheckerFactory, IRecallCheckerFactory recallCheckerFactory)
        {
            CarInspectionChecker carInspectionChecker = carInspectionCheckerFactory.Create();
            bool needsInspection = carInspectionChecker.IsInspectionRequired(car.ModelYear, car.LastInspectionDate, DateTime.Now);

            if (needsInspection)
            {
                Console.WriteLine($"{UserPrompts.NeedsInspection}");
            }
            else
            {
                Console.WriteLine($"{UserPrompts.DoesntNeedsInspection}");
            }
            // todo move this #lol
            RecalledCarsData recalledCarsDatabase = new RecalledCarsData();
            RecallChecker carRecallChecker = recallCheckerFactory.Create(recalledCarsDatabase);
            RecalledCar matchingRecalledCar = carRecallChecker.FindRecalledCar(car);

            if (matchingRecalledCar != null)
            {
                Console.WriteLine($"{UserPrompts.Defect}: {matchingRecalledCar.FactoryDefect}");
            }
        }
    }
}