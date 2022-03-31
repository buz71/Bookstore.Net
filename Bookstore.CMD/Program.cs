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
            Console.Write("Введите пароль: ");
            var pass = Console.ReadLine();
            try
            {
                var db = AccountManager.Autorization(login, pass);
            }
            catch (SqliteException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.SqliteErrorCode);
            }

        }
    }
}
