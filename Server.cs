﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaDeArchivos
{
    public class Server
    {
        public string Name { get; set; }

        public string DataBase { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public Server()
        {
            Name = "";
            DataBase = "";
            User = "";
            Password = "";
        }
    }
}