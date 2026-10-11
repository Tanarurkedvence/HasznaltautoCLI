using System;
using System.Collections.Generic;
using System.Text;

namespace HasznaltautoCLI
{

    internal class Car
    {
        static int counter = 1;
        public Car(string l)
        {
            var r = l.Split(";");
            Brand = new Brand()
            {
                BrandID = int.Parse(r[0]),
                BrandName = r[1]
            };
            Model = r[2];
            Year = int.Parse(r[3]);
            Mileage = r[4] == "NA" ? 0 : int.Parse(r[4]);
            Price = r[5] == "NA" ? 0 : int.Parse(r[5]);
            Fuel = new Fuel()
            {
                FuelID = int.Parse(r[6]),
                FuelName = r[7]
            };
            EngineSize = r[8];
            Transmission = r[9];
            Condition = r[10];
            County = r[11];
            Sold = r[12];
            CarId = counter++;
        }

        public Brand Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int Price { get; set; }
        public Fuel Fuel { get; set; }
        public string EngineSize { get; set; }
        public string Transmission { get; set; }
        public string Condition { get; set; }
        public string County { get; set; }
        public int CarId { get; set; }
        public string Sold { get; set; }

        public override string ToString()
        {
            return $"\tCar ID: {CarId}\n" +
                $"\tBrand: {Brand.BrandName}\n" +
                $"\tModel: {Model}\n" +
                $"\tYear: {Year}\n" +
                $"\tMileage: {(Mileage != 0 ? Mileage.ToString() : "NA")}\n" +
                $"\tPrice: {(Price != 0 ? Price.ToString() : "NA")}\n" +
                $"\tFuel: {Fuel.FuelName}\n" +
                $"\tEngine Size: {EngineSize}\n" +
                $"\tTransmission: {Transmission}\n" +
                $"\tCondition: {Condition}\n" +
                $"\tCounty: {County}\n" +
                $"\tSold: {Sold}\n" +
                $"\tKm per year: {KmPerYear(Mileage, Year)}\n";
        }

        public static object KmPerYear(int Mileage, int Year)
        {
            int kor = 2025 - Year;
            double atlag = Math.Round((double)Mileage / kor, 2);
            if (atlag == 0)
            {
                return ("NaN");
            }
            else
            {
                return atlag;
            }
                 

        }
    }
}
