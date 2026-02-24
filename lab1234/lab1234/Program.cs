namespace lab1234
{
	class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Демонстрация работы класса Printer LAB1\n");
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

            Console.WriteLine("Демонстрация работы LAB2");
            List<IConnectable> devices = new List<IConnectable>
            {
                new Printer2("HP", "Laser"),
                new Scanner("Canon", 1200),
                new NetworkRouter("TP-Link", "802.11ac")
            };

            Console.WriteLine("Подключение устройств");
            foreach (var device in devices)
            {
                device.Connect(); 
                Console.WriteLine();
            }

            Console.WriteLine("Информация об устройствах");
            foreach (var device in devices)
            {
                if (device is Device d)
                {
                    Console.WriteLine(d.GetInfo());
                }
            }

            Console.WriteLine("Отключение устройств");
            foreach (var device in devices)
            {
                device.Disconnect();
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}