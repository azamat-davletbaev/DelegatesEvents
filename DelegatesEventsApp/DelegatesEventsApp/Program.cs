using DelegatesEventsApp;

Console.WriteLine("Домашнее задание по теме 'Делегаты и события'");
Console.WriteLine("--------------------------------------------------------------------");
// вывод тестовых данных на экран
for (int i = 0; i < Helper.Data.Count; i++)
{
    Console.WriteLine($"{i} : {Helper.Data[i]} ({Helper.Data[i].Length})");
}
Console.WriteLine("--------------------------------------------------------------------");

var maxItem = Helper.Data.GetMax<string>(x => x.Length);
Console.WriteLine($"Максимальное значение массива: {maxItem} ({maxItem.Length})");

Console.WriteLine("--------------------------------------------------------------------");

var minItem = Helper.Data.GetMin<string>(x => x.Length);
Console.WriteLine($"Минимальное значение массива: {minItem} ({minItem.Length})");

Console.WriteLine("--------------------------------------------------------------------");
Console.WriteLine($"Поиск файлов:");

// выносим логгер и делегат отмены за пределы класса. 
// Класс FileFinder не должен ничего знать о консоли, вспоминаем ДЗ по SOLID
var fileFinder = new FileFinder(@"C:\Windows\Fonts", Console.WriteLine, Helper.isCancel);

//подписка на событие 'Найден файл'
fileFinder.FileFoundEvent += Helper.FileFoundEventHandler;

fileFinder.GetFiles(); //поиск файлов

// после всех необходимых действий не забыть отписаться от события
fileFinder.FileFoundEvent -= Helper.FileFoundEventHandler;

Console.ReadLine();