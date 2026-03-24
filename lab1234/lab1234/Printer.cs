using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1234
{
	public class Printer
	{
		// Свойства
		private string _model;
		private string _printType;
		private string _status;
		private int _pageInQueue;
        private static int _totalPrintedPages = 0;

		public string Model
		{
			get { return _model; }
			set { _model = value ?? "Unknown"; }
		}
		public string PrintType
		{
			get { return _printType; }
			set 
			{
				if (value == "Laser" || value == "Inkjet")
					_printType = value;
				else
					_printType = "Unknown";
			}
		}
		public string Status
		{
			get { return _status; }
			private set { _status = value; }
		}
        public int PageInQueue
        {
            get { return _pageInQueue; }
            private set { _pageInQueue = value; }
        }

		public Printer()
		{
			_model = "Unknown";
			_printType = "Laser";
			_status = "Ready";
			_pageInQueue = 0;
		}
		public Printer(string model, string printType)
		{
			_model = model;
			_printType = printType;
			_status = "Ready";
            _pageInQueue = 0;
        }
		public Printer(string model, string printType, string status)
		{
			_model = model;
			_printType = printType;
			_status = status;
			_pageInQueue = 0;
		}

		public void PrintDocument(string documentName, int pages, ref int totalPrinted, out bool success)
		{
			success = false;
			if (_status != "Ready")
			{
				Console.WriteLine("Невозможно напечатать документ, принтер не готов к работе");
				return;
			}
			if (pages <= 0)
			{
				Console.WriteLine("Количество страниц должно быть положительным");
				return;
			}
			_pageInQueue += pages;
			totalPrinted += pages;
			_totalPrintedPages += pages;
			Console.WriteLine($"Документ '{documentName}' добавлен в очередь ({pages} стр.). Всего в очереди: {_pageInQueue} стр.");
            if (_pageInQueue > 100)
            {
                _status = "Error";
                Console.WriteLine("Слишком много страниц в очереди. Ошибка принтера.");
            }
            success = true;
        }
        public string CheckStatus(out string statusDescription)
        {
            switch (_status)
            {
                case "Ready":
                    statusDescription = "Принтер готов к работе.";
                    break;
                case "Error":
                    statusDescription = "Обнаружена ошибка. Требуется вмешательство.";
                    break;
                case "NoPaper":
                    statusDescription = "Закончилась бумага. Добавьте бумагу.";
                    break;
                default:
                    statusDescription = "Неизвестный статус.";
                    break;
            }
            return _status;
        }
        public void ClearQueue(out int clearedCount)
        {
            if (_status == "Error" && _pageInQueue > 100)
                _status = "Ready";

            clearedCount = _pageInQueue;
            _pageInQueue = 0;
            Console.WriteLine($"Очередь очищена. Удалено страниц: {clearedCount}");
        }
        public override string ToString()
        {
            return $"Принтер: {_model}, Тип: {_printType}, Статус: {_status}, Очередь: {_pageInQueue} стр.";
        }
    }
}