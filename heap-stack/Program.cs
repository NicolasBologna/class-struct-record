namespace HeapExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio del programa");

            // List para consumir memoria en el heap
            List<string> bigData = new List<string>();

            Console.WriteLine("Creando objetos grandes en el heap...");

            // Crear 100,000 objetos grandes
            for (int i = 0; i < 100000; i++)
            {
                bigData.Add(new string('A', 1000)); // Cadena de 1000 caracteres
            }

            Console.WriteLine("Objetos creados. Presiona una tecla para continuar...");

            //bigData.Any(a => a == ""); //to comment
            IsEmpty(bigData); //to uncomment

            // Liberar referencia a los objetos
            bigData = null;

            Console.WriteLine("Referencia a los objetos eliminada. Presiona una tecla para forzar Garbage Collection...");

            // Forzar Garbage Collection
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Garbage Collection ejecutado. Fin del programa.");
        }

        static bool IsEmpty(List<string> a)
        {
            return a.Any(a => a == "");
        }
    }
}