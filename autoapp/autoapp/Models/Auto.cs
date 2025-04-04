using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoapp.Models
{
    public class Auto
    {
        public int sorszam { get; set; }
        public string? marka { get; set; }
        public string? modell { get; set; }
        public int gyartasiEv { get; set; }
        public string? szin { get; set; }
        public int eladottDB { get; set; }
        public int atlagAr { get; set; }

        public Auto(string csvSor)
        {
            var split = csvSor.Split(";");

            this.sorszam = int.Parse(split[0]);
            this.marka = split[1];
            this.modell = split[2];
            this.gyartasiEv = int.Parse(split[3]);
            this.szin = split[4];
            this.eladottDB = int.Parse(split[5]);
            this.atlagAr = int.Parse(split[6]);
        }
        
    }
}
