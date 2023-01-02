using Objects.Models;
using Objects;
using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using CodeFirstDB;
using CodeFirstDB.Services.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Migrations;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Xml.Linq;
using System.Text;
using System.Collections;
using ArrayToPdf;
using System.IO;


namespace Main {
    internal class Program {
        static void Main(string[] args) {
            Console.ForegroundColor = ConsoleColor.Green;
            Menu.Program.Main(null);

            //Objects contains Candidates and Certificates Classes
            //CodeFirstDB connects the program to the DB
            //Menu contains the Menu that the user will see 
        }
    }
}
