using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoapp.Models
{
    public class AutoDataProvider
    {
        public List<Auto> autos = new List<Auto>();

        public void LoadFromCSV(string path)
        {
            File.ReadAllLines(path).Skip(1).ToList().ForEach(x =>
            {
                autos.Add(new Auto(x));
            });
        }

        public int CarCount()
        {
            return autos.Count;
        }

        public double AvgSell()
        {
            return Math.Round(autos.Average(x => x.eladottDB), 1);
        }

        public void CVCarsInXYears(int year)
        {
            autos.Where(x => x.gyartasiEv >= DateTime.Now.Year - 5).ToList().ForEach(x => Console.WriteLine($"\t- {x.marka} {x.modell}: {x.gyartasiEv}"));
        }

        public void SuccessfulBrands()
        {
            var stat = autos.GroupBy(x => x.marka).Select(group => new {Brand = group.Key, TotalSold = group.Sum(x => x.eladottDB)}).OrderByDescending(x => x.TotalSold).ToList();

            foreach (var item in stat)
            {
                Console.WriteLine($"\t- {item.Brand}: {item.TotalSold} darab");
            }
        }
    }
}
