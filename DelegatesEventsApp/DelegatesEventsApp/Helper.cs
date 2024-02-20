using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace DelegatesEventsApp
{
    /// <summary>
    /// общий хелпер для всего проекта, не хочется дроибить, проект не большой
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// тестовый набор данных
        /// </summary>
        public static List<string> Data = new List<string>
        {
            "Федор Достоевский",
            "Михаил Булгаков",
            "Александр Пушкин",
            "Николай Гоголь",
            "Александр Дюма",
            "Лев Толстой",
            "Антон Чехов",
            "Илья Ильф, Евгений Петров",
            "Иван Тургенев",
            "Эрих Мария Ремарк",
            "Артур Конан Дойль",
            "Виктор Гюго",
            "Жюль Верн",
            "Аркадий и Борис Стругацкие",
            "Джек Лондон",
            "Эрнест Хемингуэй",
            "Михаил Шолохов",
            "Агата Кристи",
            "Алексей Толстой",
            "Михаил Лермонтов",
            "Александр Грибоедов",
            "Валентин Пикуль",
            "Борис Васильев",
            "Марк Твен",
            "Николай Лесков",
            "Уильям Шекспир",
            "Станислав Лем",
            "Максим Горький",
            "Василий Шукшин",
            "Иван Гончаров",
            "Шарлотта Бронте",
            "Александр Грин",
            "Александр Волков",
            "Даниель Дефо",
            "Василь Быков",
            "Николай Носов",
            "Юрий Поляков",
            "Александр Беляев",
            "Пауло Коэльо",
            "Юлиан Семенов",
            "Джордж Оруэлл",
            "Александр Островский",
            "Иван Ефремов",
            "Александр Куприн"
        };

        /// <summary>
        /// Расширение IEnumerable: поиск максимального значения
        /// </summary>
        /// <typeparam name="T">Универсальный тип</typeparam>
        /// <param name="collection">Коллекция</param>
        /// <param name="convertToNumber">Делегат конвертация экземпляра класса в число</param>
        /// <returns></returns>
        public static T GetMax<T>(this IEnumerable collection, Func<T, float> convertToNumber) where T : class
        {
            Dictionary<float, T> dict = new Dictionary<float, T>();

            foreach (var item in collection)
            {
                var id = convertToNumber((T)item);

                if (!dict.ContainsKey(id))
                    dict.Add(id, (T)item);
            }

            return dict.OrderBy(x => x.Key).Last().Value;
        }

        /// <summary>
        /// Расширение IEnumerable: поиск минимального значения
        /// </summary>
        /// <typeparam name="T">Универсальный тип</typeparam>
        /// <param name="collection">Коллекция</param>
        /// <param name="convertToNumber">Делегат конвертация экземпляра класса в число</param>
        /// <returns></returns>
        public static T GetMin<T>(this IEnumerable collection, Func<T, float> convertToNumber) where T : class
        {
            Dictionary<float, T> dict = new Dictionary<float, T>();

            foreach (var item in collection)
            {
                var id = convertToNumber((T)item);

                if (!dict.ContainsKey(id))
                    dict.Add(id, (T)item);
            }

            return dict.OrderBy(x => x.Key).First().Value;
        }

        /// <summary>
        /// Была ли нажата клавиша Escape
        /// </summary>
        public static Func<bool> isCancel = () =>
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Escape)
                    return true;
                else
                    return false;
            }
            return false;
        };

        /// <summary>
        /// Обработчик события 'Найден файл'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void FileFoundEventHandler(object? sender, EventArgs e)
        {
            if (e is FileArgs args)
                Console.WriteLine($"Найден файл {args.FileName}");
        }
    }
}
