using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bookstore.MControl;
using Microsoft.Data.Sqlite;

namespace Bookstrore.MControl.Control
{
    public static class AccountManager 
    {
        public static void Registration(string login, string pass, string mail, string surname, string name)
        {
            BookstoreDb db = new BookstoreDb();
            var existsByLogin = (from e in db.Accounts where e.Name == name select e).FirstOrDefault();
            var existsByMail = (from e in db.Accounts where e.Mail == mail select e).FirstOrDefault();

            if (existsByMail is not null || existsByLogin is not null)
            {
                throw new SqliteException("Пользователь с таким именем уже зарегистрирован",4);
            }
            else
            {
                db.Accounts.Add(new Account { Name = login, Password = pass, Mail = mail });
                db.Clients.Add(new Client {Name = name+" "+surname, Mail = mail});
                db.SaveChanges();
            }
        }

        public static BookstoreDb Autorization(string name, string pass)
        {
            BookstoreDb db = new BookstoreDb();
            var exist = (from e in db.Accounts where e.Name == name && e.Password == pass select e).FirstOrDefault();
            if (exist is not null)
            {
                return db;
            }
            else
            {
                throw new SqliteException("Ошибка авторизации",4);
            }
        }
    }
}
