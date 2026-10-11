namespace HasznaltautoCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            using (StreamReader o = new StreamReader("../../../forras/autok1.txt"))
            {
                o.ReadLine();
                while (!o.EndOfStream)
                {
                    string line = o.ReadLine();
                    cars.Add(new Car(line));
                }
            }
            Console.WriteLine("5. feladat");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(cars[i].ToString());
            }
            Console.WriteLine("6. feladat");
            var f6 = cars.Where(x => x.Sold == "Nem"
            && x.Fuel.FuelName == "Dízel"
            && x.Transmission == "Automata"
            && x.Condition == "Jó"
            && !x.EngineSize.Contains("Unknown")
            && !x.EngineSize.Contains("Under")
            && !x.EngineSize.Contains("Above"));


            if (f6.Any())
            {
                var maxHengerurtartalom = f6.Select(x => {
                    var engine = x.EngineSize.Split(" to ");
                    int kisebb = int.Parse(engine[0]);
                    int nagyobb = int.Parse(engine[1]);
                    return nagyobb;
                }).Max();
                foreach(var auto in f6)
                {
                    Console.WriteLine(auto.ToString());
                }
                Console.WriteLine($"\nA leszűrt autók hengerűrtartalmának legnagyobb felső határa: {maxHengerurtartalom} cm3");
                Console.WriteLine($"A leszűrt, ismert árú autók átlagára: {Math.Round(f6.Where(x => x.Price != 0).Average(x => x.Price))} Ft");
            }
            Console.WriteLine($"7. feladat: Fájlba írás");

            using(StreamWriter iro = new StreamWriter("../../../forras/budapest.txt"))
            {
                var f7 = cars.Where(x => x.Year >= 2018 && x.Year <= 2021
                && x.County == "Budapest"
                && x.Sold == "Nem").OrderByDescending(x => x.Year).ThenBy(x => x.Brand.BrandName);


                foreach(var auto in f7)
                {
                    iro.WriteLine($"{auto.Year} {auto.Brand.BrandName} {auto.Model}");
                }
            }
        }
    }
}
