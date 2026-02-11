
namespace Lab1_Printer
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Демонстрация работы класса Printer\n");

			//Конструктор по умолчанию
			Printer printer1 = new Printer();
			printer1.Model = "HP LaserJet";
			printer1.PrintType = Printer.TypeLaser;
			Console.WriteLine($"Принтер 1: {printer1.Model}, тип: {printer1.PrintType}, статус: {printer1.Status}");

			//Конструктор с параметрами
			Printer printer2 = new Printer("Canon Pixma", Printer.TypeInkjet);
			Console.WriteLine($"Принтер 2: {printer2.Model}, тип: {printer2.PrintType}, статус: {printer2.Status}");

			Console.WriteLine("\n--- Работа с принтером 2 ---");

			//Добавление документа (обычный параметр)
			printer2.AddDocument(10);
			printer2.AddDocument(5);
			printer2.AddDocuments(7, 3, 2);
			printer2.AddDocuments();

			//Использование out
			printer2.CheckStatus(out string statusDesc);
			Console.WriteLine($"Статус: {statusDesc}");

			//Печать документа
			printer2.PrintDocument();
			printer2.PrintDocument();

			//Очистка очереди с ref
			int oldQueueSize = 0;
			printer2.ClearQueue(ref oldQueueSize);
			Console.WriteLine($"После очистки в очереди: {printer2.PagesInQueue} стр.");

			//Конструктор с заданным статусом
			Printer printer3 = new Printer("Brother DCP-L2520DWR", Printer.TypeLaser, Printer.StatusNoPaper);
			Console.WriteLine($"\nПринтер 3: {printer3.Model}, статус: {printer3.Status}");

			//Попытка добавить документ при статусе "Нет бумаги"
			printer3.AddDocument(15); // не должно добавиться
			printer3.CheckStatus(out string errStatus);
			Console.WriteLine($"Статус: {errStatus}");

		}
	}
}