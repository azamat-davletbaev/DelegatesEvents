using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;


namespace DelegatesEventsApp
{
    /// <summary>
    /// Класс поиска файлов
    /// </summary>
    public class FileFinder
    {
        /// <summary>
        /// Событие 'Найден файл'
        /// </summary>
        public event EventHandler FileFoundEvent;
        /// <summary>
        /// Каталог в котором ищем файлы
        /// </summary>
        private string path { get; set; }
        /// <summary>
        /// Делегат вывода данных на консоль
        /// </summary>
        private Action<string> logger;
        /// <summary>
        /// Делегат отмены поиска
        /// </summary>
        private Func<bool> isCancel;

        /// <summary>
        /// заполняем все необходимое в конструкторе
        /// </summary>        
        public FileFinder(string path, Action<string> logger, Func<bool> isCancel)
        {
            this.path = path;
            this.logger = logger;
            this.isCancel = isCancel;
        }

        /// <summary>
        /// поиск файлов
        /// </summary>
        public void GetFiles()
        {
            if (!Directory.Exists(path))
            {                
                logger?.Invoke($"Каталог {path} не существует!");
                return;
            }

            var d = new DirectoryInfo(path);

            var files = d.GetFiles();

            if (files.Length == 0)
            {                
                logger?.Invoke($"В папке {path} нет файлов !!");
                return;
            }
                                                
            logger?.Invoke("\n Нажмите 'Escape' чтобы остановить поиск файлов.");
                        
            foreach (var file in files)
            {
                var args = new FileArgs { FileName = file.Name };
                Thread.Sleep(400);

                if (isCancel.Invoke())
                {
                    logger?.Invoke("Отмена поиска файлов...");
                    break;
                }
                
                FileFoundEvent?.Invoke(this, args);
            }

            logger?.Invoke("Поиск файлов закончен..");                        
        }
    }

    internal class FileArgs : EventArgs
    {
        public string FileName { get; set; }
    }
}
