using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstrore.MControl.Control
{
    public static class Logger
    {
        private static void CreateFile(string accName)
        {
            using StreamWriter writer = new StreamWriter($"{accName}.txt", true);
            writer.WriteLine($"{DateTime.Now}==> Аккаунт зарегистрирован");
        }

        private static bool CheckFile(string fileName)
        {
            if (File.Exists($"{fileName}.txt"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void WriteMess(string path, string message)
        {
            using StreamWriter writer = new StreamWriter($"{path}.txt", true);
            writer.WriteLine($"{DateTime.Now}::{message}");
        }

        public static async void CreateLog(string accName)
        {
            await Task.Run(() => CreateFile(accName));
        }

        public static async void WriteLog(string path, string message)
        {
            if (CheckFile(path))
            {
                await Task.Run(() => WriteMess(path, message));
            }
            else
            {
                throw new FileNotFoundException("Файл не найден");
            }

        }
    }
}
