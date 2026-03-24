using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1234
{
    public class Printer2 : Device
    {
        private string _printType;
        private string _status;
        private int _queuePages;
        private static int _totalPrintedPages = 0;

        public Printer2() : base("Unknown")
        {
            _printType = "Laser";
            _status = "Ready";
            _queuePages = 0;
        }

        public Printer2(string model, string printType) : base(model)
        {
            _printType = printType;
            _status = "Ready";
            _queuePages = 0;
        }

        public Printer2(string model, string printType, string status) : base(model)
        {
            _printType = printType;
            _status = status;
            _queuePages = 0;
        }

        public string Model
        {
            get => Name;
            set => Name = value;
        }

        public string PrintType
        {
            get => _printType;
            set => _printType = value;
        }

        public string Status
        {
            get => _status;
            private set => _status = value;
        }

        public int QueuePages
        {
            get => _queuePages;
            private set => _queuePages = value;
        }

        public void PrintDocument(string documentName, int pages, ref int totalPrinted, out bool success)
        {
            success = false;
            if (_status != "Ready")
            {
                Console.WriteLine($"Невозможно напечатать '{documentName}': принтер не готов (статус: {_status})");
                return;
            }
            if (pages <= 0)
            {
                Console.WriteLine("Количество страниц должно быть положительным.");
                return;
            }
            _queuePages += pages;
            totalPrinted += pages;
            _totalPrintedPages += pages;
            Console.WriteLine($"Документ '{documentName}' добавлен в очередь ({pages} стр.). Всего в очереди: {_queuePages} стр.");
            if (_queuePages > 100)
            {
                _status = "Error";
                Console.WriteLine("Слишком много страниц в очереди. Ошибка принтера.");
            }
            success = true;
        }

        public void PrintMultipleDocuments(params int[] pagesList)
        {
            if (pagesList.Length == 0)
            {
                Console.WriteLine("Нет документов для печати.");
                return;
            }
            int tempTotal = 0;
            for (int i = 0; i < pagesList.Length; i++)
            {
                string docName = $"Документ{i + 1}";
                if (_status == "Ready" && pagesList[i] > 0)
                {
                    _queuePages += pagesList[i];
                    tempTotal += pagesList[i];
                    Console.WriteLine($"'{docName}' добавлен ({pagesList[i]} стр.)");
                }
                else
                {
                    Console.WriteLine($"'{docName}' не добавлен: статус {_status}");
                }
            }
            _totalPrintedPages += tempTotal;
            Console.WriteLine($"Всего страниц в очереди после пакетной печати: {_queuePages}");
        }

        public string CheckStatus(out string statusDescription)
        {
            statusDescription = _status switch
            {
                "Ready" => "Принтер готов к работе.",
                "Error" => "Обнаружена ошибка.",
                "NoPaper" => "Закончилась бумага.",
                _ => "Неизвестный статус."
            };
            return _status;
        }

        public void ClearQueue(out int clearedCount)
        {
            clearedCount = _queuePages;
            _queuePages = 0;
            Console.WriteLine($"Очередь очищена. Удалено страниц: {clearedCount}");
            if (_status == "Error")
                _status = "Ready";
        }

        public override string ToString()
        {
            return $"Принтер: {Model}, Тип: {PrintType}, Статус: {Status}, Очередь: {QueuePages} стр.";
        }

        public override string GetInfo() => ToString();

        public override void Connect()
        {
            base.Connect();
            if (_status == "Error" || _status == "NoPaper")
                Console.WriteLine("Внимание: принтер подключён, но есть проблемы с состоянием.");
        }
    }
}
