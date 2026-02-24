namespace Lab1_Printer
{
	class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Демонстрация работы класса Printer\n");
            Printer printer1 = new Printer();
            Printer printer2 = new Printer("HP", "Laser");
            Printer printer3 = new Printer("MS90", "Inkjet", "NoPaper");

            Console.WriteLine("Созданные принтеры:");
            Console.WriteLine(printer1);
            Console.WriteLine(printer2);
            Console.WriteLine(printer3);
            Console.WriteLine();

            int totalPrintedGlobal = 0;

            Console.WriteLine("Печать на printer2 (готов)");
            printer2.PrintDocument("Отчёт", 10, ref totalPrintedGlobal, out bool success);
            Console.WriteLine($"Успех: {success}, Всего напечатано страниц (global): {totalPrintedGlobal}");
            Console.WriteLine(printer2);
            Console.WriteLine();

            Console.WriteLine("Печать на printer3 (нет бумаги)");
            printer3.PrintDocument("Фото", 5, ref totalPrintedGlobal, out success);
            Console.WriteLine($"Успех: {success}, Всего напечатано страниц (global): {totalPrintedGlobal}");
            Console.WriteLine(printer3);
            Console.WriteLine();

            Console.WriteLine("Проверка статуса printer3");
            string status = printer3.CheckStatus(out string description);
            Console.WriteLine($"Статус: {status}, Описание: {description}");
            Console.WriteLine();

            Console.WriteLine("Очистка очереди printer2");
            printer2.ClearQueue(out int cleared);
            Console.WriteLine(printer2);
            Console.WriteLine();
        }
    }
}