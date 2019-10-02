using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AduLib
{
    /// <summary>
    /// Исключение, которое выдается, если, при вызове утилиты, произошла необработанная ошибка.
    /// </summary>
    public class UnhandledErrorException : Exception
    {
        /// <summary>
        /// Получает аргументы, переданные утилите.
        /// </summary>
        public string Arguments { get; }

        /// <summary>
        /// Получает экземпляр класса System.Exception, который вызвал текущее исключение.
        /// </summary>
        public new Exception InnerException { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UnhandledErrorException"/>
        /// с аргументами, переданные утилите.
        /// </summary>
        /// <param name="args">
        /// Аргументы, которые были переданы утилите.
        /// </param>
        public UnhandledErrorException(string args) : base($"Invalid Arguments: '{ args }'.")
        { Arguments = args; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UnhandledErrorException"/>
        /// с экземпляром исключения, вызвавшего данное исключение.
        /// </summary>
        /// <param name="innerException">
        /// Исключение, вызвавшее текущее исключение.
        /// </param>
        public UnhandledErrorException(Exception innerException) :
            base($"An exception was raised: { innerException }.")
        { InnerException = innerException; }
    }

    /// <summary>
    /// Исключение, которое выдается, при попытке преобразовать синтаксически некорректный путь.
    /// </summary>
    public class PathInvalidException : Exception
    {
        /// <summary>
        /// Получает путь.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Получает экземпляр класса System.Exception, который вызвал текущее исключение.
        /// </summary>
        public new Exception InnerException { get; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PathInvalidException"/> c путем.
        /// </summary>
        /// <param name="path">
        /// Путь.
        /// </param>
        public PathInvalidException(string path) : base($"Path Invalid : '{ path }'.")
        { Path = path; }

        /// <summary>
        /// Инициализирует новый экземпляр класса Adu.PathInvalidException c путем
        /// и экземпляром исключения, вызвавшего данное исключение.
        /// </summary>
        /// <param name="path">
        /// Путь.
        /// </param>
        /// <param name="innerException">
        /// Исключение, вызвавшее текущее исключение.
        /// </param>
        public PathInvalidException(string path, Exception innerException)
            : base($"Path Invalid : '{ path }'. An exception was raised: { innerException }.", innerException)
        {
            Path = path;
            InnerException = innerException;
        }
    }

    /// <summary>
    /// Предоставляет статические методы для создания и удаления виртуального диска. Получаемый
    /// виртуальный диск предоставляет информацию из заданной директории. Все действия производятся,
    /// при помощи вызовов к встроенной утилите "Subst". Этот класс не наследуется.
    /// </summary>
    public static class Function
    {
        /// <summary>
        /// Предоставляет доступ для создания и запуска процесса, вызывающего утилиту.
        /// </summary>
        static readonly Process proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "Subst.exe",
                RedirectStandardOutput = true,

                /* Для того, чтобы не мешать основному процессу.
                 * Например, без этих настроек, вызов API мешает основному процессу в Windows Forms.
                 */
                CreateNoWindow = true,
                UseShellExecute = false
            }
        };

        /// <summary>
        /// Вызывает утилиту с заданными аргументами, возвращает ее выходные данные.
        /// </summary>
        /// <param name="args">
        /// Аргументы, передающиеся утилите.
        /// </param>
        /// <exception cref="UnhandledErrorException">
        /// Eсли утилита вернула значение отличное 0, <see cref="UnhandledErrorException.Arguments"/>
        /// получает переданные аргументы. Иначе <see cref="UnhandledErrorException.InnerException"/>
        /// содержит экземпляр исключения вызвавший ошибку.
        /// </exception>
        /// <returns>
        /// Список строк текстовых выходных данных. Каждый элемент отдельная строка.
        /// </returns>
        static List<string> Call(string args = "")
        {
            proc.StartInfo.Arguments = args;

            try
            {
                proc.Start();
                proc.WaitForExit();

                if (proc.ExitCode != 0)
                    throw new UnhandledErrorException(args);

                var rows = new List<string>();

                var row = proc.StandardOutput.ReadLine();
                while (row != null)
                {
                    rows.Add(row);
                    row = proc.StandardOutput.ReadLine();
                }
                return rows;
            }
            catch (Exception e) { throw new UnhandledErrorException(e); }
        }

        /// <summary>
        /// Преобразует путь в форму, понятную утилите. Например: «C:» в «C:\» и «C:\Users \» в
        /// «C:\Users» и переводит букву диска в верхний регистр.
        /// </summary>
        /// <param name="path">
        /// Путь.
        /// </param>
        /// <exception cref="PathInvalidException">
        /// При преобразовании была выдана одна из исключений:
        /// System.ArgumentException: path представляет собой строку нулевой длины, содержит только
        /// пробелы или содержит недопустимые символы.
        /// System.Security.SecurityException: У вызывающего объекта отсутствуют необходимые
        /// разрешения.
        /// System.ArgumentNullException: path имеет значение null.
        /// System.NotSupportedException: path содержит двоеточие «:», которое не является частью
        /// идентификатора тома (например, «c: \»).
        /// System.IO.PathTooLongException: path превышает максимальную длину пути.
        /// </exception>
        /// <returns>
        /// Строка преобразованного пути.
        /// </returns>
        public static string NormalizesPath(string path)
        {
            try { path = Path.GetFullPath(path); }

            catch (Exception e) { throw new PathInvalidException(path, e); }

            if (path.Length > 3)
                path = path.TrimEnd(@"\ /".ToCharArray());

            return path;
        }

        /// <summary>
        /// Возвращает пары ключ/значение где, ключ - диск; значение - директория.
        /// </summary>
        /// <exception cref="UnhandledErrorException">
        /// Необработанная ошибка.
        /// </exception>
        /// <returns>
        /// Пары ключ/значение. Диск, формата: C, D, E. Директория - абсолютный путь к директории.
        /// </returns>
        public static Dictionary<char, string> GetMounted()
        {
            var mounteds = new Dictionary<char, string>();

            foreach (var row in Call())
                if (row.Length != 0)
                    mounteds.Add(row[0], row.Substring(8));

            return mounteds;
        }

        /// <summary>
        /// Возвращает список созданных дисков.
        /// </summary>
        /// <exception cref="UnhandledErrorException">
        /// Необработанная ошибка.
        /// </exception>
        /// <returns>
        /// Список дисков. Формата: C, D, E. 
        /// </returns>
        public static List<char> GetMountedDrives()
        {
            var drives = new List<char>();

            foreach (var row in Call())
                drives.Add(row[0]);

            return drives;
        }

        /// <summary>
        /// Проверяет корректно ли работает утилита.
        /// </summary>
        /// <returns>
        /// true, утилита работает корректно; иначе false.
        /// </returns>
        public static bool IsWorks()
        {
            try { Call(); }

            catch (UnhandledErrorException) { return false; }

            return true;
        }

        /// <summary>
        /// Монтирует заданную директорию под заданным диском.
        /// </summary>
        /// <param name="drive">
        /// Диск. Формата: C, D, E.
        /// </param>
        /// <param name="path">
        /// Абсолютный путь к директории.
        /// </param>
        /// <exception cref="DriveNotFoundException">
        /// Диск уже используется.
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">
        /// Путь не указывает на директорию.
        /// </exception>
        /// <exception cref="PathInvalidException">
        /// Ошибка при преобразовании пути.
        /// </exception>
        /// <exception cref="UnhandledErrorException">
        /// Необработанная ошибка.
        /// </exception>
        public static void Mount(char drive, string path)
        {
            if (Array.Exists(System.IO.DriveInfo.GetDrives(), i => i.Name[0] == drive))
                throw new DriveNotFoundException($"Drive Used: '{ drive }'.");

            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException($"Invalid Directory Path: '{ path }'.");

            path = NormalizesPath(path);

            Call($"{ drive }: \"{ path }\"");
        }

        /// <summary>
        /// Удаляет заданный диск.
        /// </summary>
        /// <param name="drive">
        /// Диск. Формата: C, D, E.
        /// </param>
        /// <exception cref="DriveNotFoundException">
        /// Диск не был создан.
        /// </exception>
        /// <exception cref="UnhandledErrorException">
        /// Необработанная ошибка.
        /// </exception>
        public static void Unmount(char drive)
        {
            if (!GetMountedDrives().Contains(drive))
                throw new DriveNotFoundException($"Drive not mounted: '{ drive }'.");

            Call($"{ drive }: /d");
        }

        public static char[] GetFreeDrives()
        {
            var rangeInt = new int[26]; // A, B, C, == 65, 66, 67.
            for (int i = 65, j = 0; i < 91; i++, j++)
                rangeInt[j] = i;

            var drives = new List<char>();
            foreach (int i in rangeInt)
                if (!Directory.Exists($"{ (char)i }:"))
                    drives.Add((char)i);

            return drives.ToArray();
        }

        public static Dictionary<char, string> GetDrivesStatus()
        {
            var couple = new Dictionary<char, string>();

            foreach (var mount in GetMounted())
                couple.Add(mount.Key, mount.Value);

            foreach (var drive in GetFreeDrives())
                couple.Add(drive, "");

            return couple;
        }
    }
}