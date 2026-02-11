using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Printer
{
	public class Printer
	{
		public const string TypeLaser = "Лазерный";
		public const string TypeInkjet = "Струйный";
		public const string StatusReady = "Готов";
		public const string StatusError = "Ошибка";
		public const string StatusNoPaper = "Нет бумаги";

		//Поля (приватные, инкапсуляция)
		private string _model;
		private string _printType;
		private string _status;
		private int _pagesInQueue;

		//Свойства
		public string Model
		{
			get { return _model; }
			set { _model = value; }
		}

		public string PrintType
		{
			get { return _printType; }
			set { _printType = value; }
		}

		//Статус доступен только для чтения (изменяется внутри методов)
		public string Status
		{
			get { return _status; }
			private set { _status = value; }
		}

		//Количество страниц в очереди — только чтение
		public int PagesInQueue
		{
			get { return _pagesInQueue; }
			private set { _pagesInQueue = value; }
		}

		//Конструкторы
		//Конструктор по умолчанию
		public Printer()
		{
			_model = "Unknown";
			_printType = TypeLaser;
			_status = StatusReady;
			_pagesInQueue = 0;
		}

		//Конструктор с параметрами (модель и тип печати)
		public Printer(string model, string printType)
		{
			_model = model;
			_printType = printType;
			_status = StatusReady;
			_pagesInQueue = 0;
		}

		//Конструктор с полным набором параметров
		public Printer(string model, string printType, string status)
		{
			_model = model;
			_printType = printType;
			_status = status;
			_pagesInQueue = 0;
		}

		//Методы

		//Обычный параметр: добавить документ
		public void AddDocument(int pages)
		{
			if (pages <= 0)
			{
				Console.WriteLine("Количество страниц должно быть положительным.");
				return;
			}

			if (_status != StatusReady)
			{
				Console.WriteLine($"Невозможно добавить документ. Принтер не готов (статус: {_status}).");
				return;
			}

			_pagesInQueue += pages;
			Console.WriteLine($"Добавлено {pages} стр. в очередь. Всего в очереди: {_pagesInQueue} стр.");
		}

		//Параметр params: добавить несколько документов (список страниц)
		public void AddDocuments(params int[] pagesList)
		{
			if (pagesList == null || pagesList.Length == 0)
			{
				Console.WriteLine("Не указано ни одного документа.");
				return;
			}

			int total = 0;
			foreach (int p in pagesList)
				total += p;

			AddDocument(total);
		}

		//Метод с out-параметром, проверить статус и получить описание
		public void CheckStatus(out string statusDescription)
		{
			switch (_status)
			{
				case StatusReady:
					statusDescription = "Принтер готов к работе.";
					break;
				case StatusError:
					statusDescription = "Ошибка принтера. Требуется обслуживание.";
					break;
				case StatusNoPaper:
					statusDescription = "Нет бумаги. Добавьте бумагу.";
					break;
				default:
					statusDescription = "Неизвестный статус.";
					break;
			}
		}
		//Метод с ref-параметром: очистить очередь и вернуть предыдущее значение
		public void ClearQueue(ref int previousPages)
		{
			previousPages = _pagesInQueue;
			_pagesInQueue = 0;
			Console.WriteLine($"Очередь очищена. Ранее в очереди было: {previousPages} стр.");
		}

		//Распечатать один документ (уменьшает очередь на 1 страницу)
		public void PrintDocument()
		{
			if (_pagesInQueue == 0)
			{
				Console.WriteLine("Очередь печати пуста.");
				return;
			}

			if (_status != StatusReady)
			{
				Console.WriteLine($"Невозможно печатать. Статус: {_status}");
				return;
			}

			_pagesInQueue--;
			Console.WriteLine($"Напечатана 1 стр. Осталось в очереди: {_pagesInQueue} стр.");
		}
	}
}