namespace class_struct_record
{
    internal class Program
    {
        unsafe static void Main(string[] args)
        {
            // *********************************************************
            // *                                                       *
            // *                      Class                            *
            // *                                                       *
            // *********************************************************

            var classBeer1 = new BeerClass(12345678, "Quilmes", 5.3f);
            Console.WriteLine(classBeer1.Name);

            var classBeer2 = classBeer1;
            classBeer2.Name = "Isenbek";
            Console.WriteLine(classBeer2.Name);
            Console.WriteLine(classBeer1.Name);

            // *********************************************************
            // *                                                       *
            // *                      Struct                           *
            // *                                                       *
            // *********************************************************

            var structBeer1 = new BeerStruct(9876543, "Patagonia", 4.5f);
            Console.WriteLine(structBeer1.Name);
            var structBeer2 = structBeer1; // Copy the value
            structBeer2.Name = "Andes";
            Console.WriteLine(structBeer2.Name);
            Console.WriteLine(structBeer1.Name);

            var structBeer3 = new BeerStruct();
            Console.WriteLine(structBeer3);
            structBeer3.Name = "Peñon del Aguila"; // Como es una variable local se actualiza directamente en la memoria del stack
            Console.WriteLine(structBeer3);

            var structBeer4 = new BeerStruct(9876543, "Patagonia", 4.5f);
            var copyOfstructBeer4 = new BeerStruct(9876543, "Patagonia", 4.5f);
            Console.WriteLine(structBeer4.Equals(copyOfstructBeer4));
            //if (structBeer4 == copyOfstructBeer4)  // you cannot use the == operator with a struct type unless the type explicitly overloads that operator.

            // *********************************************************
            // *                                                       *
            // *                  Record (El primo trabado de Class)   *
            // *                                                       *
            // *********************************************************

            var recordBeer1 = new BeerRecord(5555, "Estrella de Galicia", 3.9f);
            Console.WriteLine(recordBeer1.Name);
            // son propiedades inmutables por diseño, por lo que, para modificar su valor, debemos crear una nueva instancia del record
            // el with permite crear una nueva instancia del record con los valores de la instancia anterior modificados
            var recordBeer2 = recordBeer1 with { Name = "Warsteiner" };
            Console.WriteLine(recordBeer1.Name);
            Console.WriteLine(recordBeer2.Name);

            var recordBeer3 = new BeerRecord();
            recordBeer3.Name = "Antares";
            Console.WriteLine(recordBeer3.Name);

            //agregar comparación para cada tipo
        }

        public class BaseClass();
        public class BeerClass : BaseClass, IDisposable
        {
            public BeerClass()
            {
                SerialNumber = 0;
                Name = "Unknown";
                Alcohol = 0.0f;
            }

            public BeerClass(int serialNumber, string name, float alcohol)
            {
                SerialNumber = serialNumber;
                Name = name;
                Alcohol = alcohol;
            }

            public int SerialNumber { get; set; }
            public string Name { get; set; }
            public float Alcohol { get; set; }

            public void Drink()
            {
                Console.WriteLine("Drinking beer...");
            }

            public static void Drink(BeerClass beer)
            {
                Console.WriteLine($"Drinking {beer.Name}...");
            }

            ~BeerClass()
            {
                Dispose();
            }

            public void Dispose()
            {
                Console.WriteLine("Disposing class beer...");
            }
        }

        public struct BeerStruct : IDisposable
        {
            public BeerStruct()
            {
                SerialNumber = 0;
                Name = "Unknown";
                Alcohol = 0.0f;
            }

            public BeerStruct(int serialNumber, string name, float alcohol)
            {
                SerialNumber = serialNumber;
                Name = name;
                Alcohol = alcohol;
            }

            public int SerialNumber { get; set; }
            public string Name { get; set; }
            public float Alcohol { get; set; }

            public void Drink()
            {
                Console.WriteLine("Drinking beer...");
            }

            public static void Drink(BeerStruct beer)
            {
                Console.WriteLine($"Drinking {beer.Name}...");
            }

            //Only Class can have destructor
            //~BeerStruct() 
            //{
            //    Dispose();
            //}

            public void Dispose()
            {
                Console.WriteLine("Disposing struct beer...");
            }
        }

        public record BaseRecord();
        public record BeerRecord : BaseRecord, IDisposable
        {
            public BeerRecord()
            {
                SerialNumber = 0;
                Name = "Unknown";
                Alcohol = 0.0f;
            }

            public BeerRecord(int serialNumber, string name, float alcohol)
            {
                SerialNumber = serialNumber;
                Name = name;
                Alcohol = alcohol;
            }

            public int SerialNumber { get; set; }
            public string Name { get; set; }
            public float Alcohol { get; set; }

            public void Drink()
            {
                Console.WriteLine("Drinking beer...");
            }

            public static void Drink(BeerRecord beer)
            {
                Console.WriteLine($"Drinking {beer.Name}...");
            }

            ~BeerRecord()
            {
                Dispose();
            }

            public void Dispose()
            {
                Console.WriteLine("Disposing struct beer...");
            }
        }
        public record BeerRecordPositional(int SerialNumber, string Name, float Alcohol)
        {
            public void Drink()
            {
                Console.WriteLine("Drinking beer...");
            }

            public static void Drink(BeerRecordPositional beer)
            {
                Console.WriteLine($"Drinking {beer.Name}...");
            }

            ~BeerRecordPositional()
            {
                Dispose();
            }

            public void Dispose()
            {
                Console.WriteLine("Disposing struct beer...");
            }
        }
    }
}
