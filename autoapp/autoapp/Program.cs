using autoapp.Models;

namespace autoapp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AutoDataProvider autoDataProvider = new AutoDataProvider();

            // 4.
            autoDataProvider.LoadFromCSV("Data/autok.csv");

            // 5.
            Console.WriteLine($"5. feladat: {autoDataProvider.CarCount()} autó található a listában");

            // 6.
            Console.WriteLine($"6. feladat: Az autók esetében az átlagosan eladott darabszám {autoDataProvider.AvgSell()}");

            // 7.
            Console.WriteLine("7. feladat: Az elmúlt 5 évben gyártott autók:");
            autoDataProvider.CVCarsInXYears(5);

            // 8.
            Console.WriteLine("8. feladat: Legsikeresebb márkák listája az eladott darabszám alapján:");
            autoDataProvider.SuccessfulBrands();
        }
    }
}
