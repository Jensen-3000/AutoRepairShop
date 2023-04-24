using AutoRepairShop.Logic.Factories.Implementation;
using AutoRepairShop.Logic.Factories.Interfaces;
using AutoRepairShop.Logic.Models.Implementation;
using AutoRepairShop.Logic.Models.Interfaces;
using AutoRepairShop.Logic.Utilities;
using AutoRepairShop.UI.Prompts;

namespace AutoRepairShop.ConsoleUI
{
    public class ConsoleFlow
    {
        // Fields
        private readonly ICarInspectionCheckerFactory _carInspectionCheckerFactory;
        private readonly ICarFactory _carFactory;
        private readonly IRecallCheckerFactory _recallCheckerFactory;
        private readonly ICarModelYearValidatorFactory _carModelYearValidatorFactory;
        private readonly ILastInspectionDateValidatorFactory _lastInspectionDateValidatorFactory;
        private readonly IRecalledCarsDataFactory _recalledCarsDataFactory;

        // Constructor 
        public ConsoleFlow()
        {
            _carInspectionCheckerFactory = new CarInspectionCheckerFactory();
            _carFactory = new CarFactory();
            _recallCheckerFactory = new RecallCheckerFactory();
            _carModelYearValidatorFactory = new CarModelYearValidatorFactory(new DateTimeProvider());
            _lastInspectionDateValidatorFactory = new LastInspectionDateValidatorFactory(new DateTimeProvider());
            _recalledCarsDataFactory = new RecalledCarsDataFactory();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    // Opretter car objekt
                    Car car = GetUserInputsAndCreateCar();

                    // Kontrollere om bilen skal til syn
                    CheckCarInspection(car);

                    // Kontrollere om bilen har en defekt/skal tilbagekaldes 
                    CheckCarRecall(car);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl: {ex.Message}");
                }

                // Spørger brugeren om de vil afslutte programmet
                Console.WriteLine(UserPrompts.PressToQuitProgram);
                if (Console.ReadKey().Key == ConsoleKey.Q) break;
                Console.Clear();
            }
        }

        // Retunere et car objekt når user har givet inputs
        private Car GetUserInputsAndCreateCar()
        {
            string brand = GetValidCarBrand(UserPrompts.CarBrand);
            string model = GetValidCarModel(UserPrompts.CarModel);
            DateTime modelYear = GetValidCarModelYear(UserPrompts.CarYear);
            DateTime lastInspectionDate = GetValidLastInspectionDate(UserPrompts.CarLastInspectionDate);

            return _carFactory.Create(brand, model, modelYear, lastInspectionDate);
        }


        #region Methods for inputs from user
        // Tager input fra user og retunere en clean string
        // Til bil mærke fx. Fiat
        private string GetValidCarBrand(string prompt)
        {
            string brandInput;
            do
            {
                Console.Write(prompt);
                brandInput = Console.ReadLine().CleanString();
            } while (string.IsNullOrEmpty(brandInput));

            return brandInput;
        }
        // Tager input fra user og retunere en clean string
        // Til bil model fx. Punto
        private string GetValidCarModel(string prompt)
        {
            string modelInput;
            do
            {
                Console.Write(prompt);
                modelInput = Console.ReadLine().CleanString();
            } while (string.IsNullOrEmpty(modelInput));
            return modelInput;
        }
        /// <summary>
        /// Spørger user om at indtaste et gyldigt bil årgang og returnerer det som et DateTime objekt
        /// </summary>
        /// 
        /// <remarks>
        /// Input bliver valideret af <see cref="CarModelYearValidator.ValidateCarModelYear(string)"/>
        /// </remarks>
        /// 
        /// <param name="prompt">Prompt til at vise hvad brugeren skal indtaste</param>
        /// <returns>Valideret årgang for bilen</returns>
        private DateTime GetValidCarModelYear(string prompt)
        {
            ICarModelYearValidator carModelYearValidator = _carModelYearValidatorFactory.Create();
            DateTime modelYear;
            string yearInput;
            do
            {
                Console.Write(prompt);
                yearInput = Console.ReadLine();
                try
                {
                    modelYear = carModelYearValidator.ValidateCarModelYear(yearInput);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl: {ex.Message}");
                }
            } while (true);
            return modelYear;
        }

        /// <summary>
        /// Spørger user om at indtaste hvornår bilen sidst er synet
        /// og returnerer det som et DateTime objekt
        /// </summary>
        /// 
        /// <remarks>
        /// Input bliver valideret af <see cref="LastInspectionDateValidator.ValidateLastInspectionDate(string)"/>
        /// og giver en fejl bedsked hvis brugeren indtaster forkert format
        /// </remarks>
        /// 
        /// <param name="prompt">Prompt til at vise hvad brugeren skal indtaste</param>
        /// <returns>Valideret sidste syns dato for bilen</returns>
        private DateTime GetValidLastInspectionDate(string prompt)
        {
            ILastInspectionDateValidator lastInspectionDateValidator = _lastInspectionDateValidatorFactory.Create();
            DateTime lastInspectionDate;
            string inspectionDateInput;
            do
            {
                Console.Write(prompt);
                inspectionDateInput = Console.ReadLine();
                try
                {
                    lastInspectionDate = lastInspectionDateValidator.ValidateLastInspectionDate(inspectionDateInput);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl: {ex.Message}");
                }
            } while (true);
            return lastInspectionDate;
        }
        #endregion


        #region Car inspection from car object

        /// <summary>
        /// Kontrollere om bilen skal til syn eller ej og udskriver til brugeren, 
        /// baseret på Årgang, Sidste syns dato og Nuværende dato
        /// </summary>
        /// 
        /// <remarks>
        /// Beregning bliver fortaget i struct <see cref="CarInspectionChecker.IsInspectionRequired(DateTime, DateTime, DateTime)"/>
        /// </remarks>
        /// 
        /// <param name="car">Bilen der skal kontrolleres</param>
        private void CheckCarInspection(Car car)
        {
            CarInspectionChecker carInspectionChecker = _carInspectionCheckerFactory.Create();
            bool needsInspection = carInspectionChecker.IsInspectionRequired(car.ModelYear, car.LastInspectionDate, DateTime.Now);
            if (needsInspection)
            {
                Console.WriteLine(UserPrompts.NeedsInspection);
            }
            else
            {
                Console.WriteLine(UserPrompts.DoesntNeedsInspection);
            }
        }
        #endregion


        #region Checks recall from car object
        /// <summary>
        /// Kontrollere om bilen er blevet 'recalled' pga en defekt baseret på alderen,
        /// og om den findes i <see cref="RecalledCarsData"/> 
        /// </summary>
        /// <param name="car">Bilen der skal kontrolleres</param>
        private void CheckCarRecall(Car car)
        {
            IRecalledCarsData recalledCarsDatabase = _recalledCarsDataFactory.Create();
            IRecallChecker carRecallChecker = _recallCheckerFactory.Create(recalledCarsDatabase);
            RecalledCar matchingRecalledCar = carRecallChecker.FindRecalledCar(car);

            if (matchingRecalledCar != null)
            {
                Console.WriteLine($"{UserPrompts.Defect}: {matchingRecalledCar.FactoryDefect}");
            }
        }
        #endregion
    }
}