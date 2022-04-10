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
            File.CreateText($"{accName}.txt");
        }

        private static FileStream LoadFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                return new FileStream(fileName,FileMode.Open);
            }
            else
            {
                throw new FileLoadException("Файл не найден");
            }

        }

        public static async void CreateLog(string accName)
        {
            await Task.Run(() => CreateFile(accName));
        }

        public static async Task<FileStream> LoadLog(string fileName)
        {
           return await Task.Run(() => LoadFile(fileName));
        }
    }
}
