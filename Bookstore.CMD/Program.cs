using System;
using Bookstrore.MControl.Control;
using Microsoft.Data.Sqlite;

namespace Bookstore.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите логин: ");
            var login = Console.ReadLine();
            Console.WriteLine("Введите пароль: ");
            var pass = Console.ReadLine();
            Console.WriteLine("Введите мейл: ");
            var mail = Console.ReadLine();
            try
            {
                AccountManager.Registration(login,pass,mail);
            }
            catch (SqliteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.SqliteErrorCode);
            }

        }
    }
}
