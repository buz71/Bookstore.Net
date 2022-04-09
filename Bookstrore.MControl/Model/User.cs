using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.MControl;

namespace Bookstrore.MControl.Model
{
    internal class User
    {
        private BookstoreDb _db;
        private SMTP _smtp;
        private string _log;

        public BookstoreDb DB
        {
            get { return _db;}
            set { _db = value; }
        }

        public string Log
        {
            get { return _log;}
            set { _log = value; }
        }
    }
}
